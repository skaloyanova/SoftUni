using Microsoft.EntityFrameworkCore;
using ProductConsoleAPI.Business;
using ProductConsoleAPI.Business.Contracts;
using ProductConsoleAPI.Data.Models;
using ProductConsoleAPI.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ProductConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestProductsDbContext dbContext;
        private IProductsManager productsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestProductsDbContext();
            this.productsManager = new ProductsManager(new ProductsRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }

        public static void AssertPropertiesEqual<T>(T expected, T actual)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var expectedValue = property.GetValue(expected, null);
                var actualValue = property.GetValue(actual, null);
                Assert.That(expectedValue, Is.EqualTo(actualValue));
            }
        }

        //positive test
        [Test]
        public async Task AddProductAsync_ShouldAddNewProduct()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            var dbProduct = await this.dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == newProduct.ProductCode);

            Assert.NotNull(dbProduct);
            Assert.AreEqual(newProduct.ProductName, dbProduct.ProductName);
            Assert.AreEqual(newProduct.Description, dbProduct.Description);
            Assert.AreEqual(newProduct.Price, dbProduct.Price);
            Assert.AreEqual(newProduct.Quantity, dbProduct.Quantity);
            Assert.AreEqual(newProduct.OriginCountry, dbProduct.OriginCountry);
            Assert.AreEqual(newProduct.ProductCode, dbProduct.ProductCode);
        }

        //Negative test
        [Test]
        public async Task AddProductAsync_TryToAddProductWithInvalidCredentials_ShouldThrowException()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = -1m,
                Quantity = 100,
                Description = "Anything for description"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await productsManager.AddAsync(newProduct));
            var actual = await dbContext.Products.FirstOrDefaultAsync(c => c.ProductCode == newProduct.ProductCode);

            Assert.IsNull(actual);
            Assert.That(ex.Message, Is.EqualTo("Invalid product!"));

        }

        // Validation:
        // product code [5..26]
        // product name [1..40]
        // quantity     [0..int.Max]
        // price        [0..79228162514264337593543950334]
        // country name [1..60]
        // description  [1..255]
        [Test]
        public async Task AddProductAsync_ValidationMaxBorder_ShouldAddNewProduct()
        {
            // Arrange
            var product = new Product
            {
                ProductCode = "a".PadRight(26, 'a'),
                ProductName = "p".PadRight(40, 'p'),
                Quantity = int.MaxValue,
                Price = 79228162514264337593543950334m,
                OriginCountry = "c".PadRight(60, 'c'),
                Description = "d".PadRight(255, 'd')
            };

            // Act
            await productsManager.AddAsync(product);

            // Assert
            var productInDb = await dbContext.Products.FirstOrDefaultAsync();

            Assert.That(productInDb, Is.Not.Null);
            AssertPropertiesEqual(product, productInDb);
        }

        [Test]
        public async Task AddProductAsync_ValidationMinBorder_ShouldAddNewProduct()
        {
            // Arrange
            var product = new Product
            {
                ProductCode = "a".PadRight(5, 'a'),
                ProductName = "p",
                Quantity = 0,
                Price = 0,
                OriginCountry = "c",
                Description = "d"
            };

            // Act
            await productsManager.AddAsync(product);

            // Assert
            var productInDb = await dbContext.Products.FirstOrDefaultAsync();

            Assert.That(productInDb, Is.Not.Null);
            AssertPropertiesEqual(product, productInDb);
        }

        [Test]
        public async Task AddProductAsync_ValidationAboveMaxBorder_ShouldThrowValidationException()
        {
            // Arrange
            var product = new Product
            {
                ProductCode = "a".PadRight(27, 'a'),
                ProductName = "p".PadRight(41, 'p'),
                Quantity = int.MaxValue,
                Price = 79228162514264337593543950335m,
                OriginCountry = "c".PadRight(61, 'c'),
                Description = "d".PadRight(256, 'd')
            };

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => productsManager.AddAsync(product));
            Assert.That(ex.Message, Is.EqualTo("Invalid product!"));

            var productInDb = await dbContext.Products.FirstOrDefaultAsync();
            Assert.That(productInDb, Is.Null);
        }

        [Test]
        public async Task AddProductAsync_ValidationBelowMinBorder_ShouldThrowValidationException()
        {
            // Arrange
            var product = new Product
            {
                ProductCode = "a".PadRight(4, 'a'),
                ProductName = "",
                Quantity = -1,
                Price = -0.9999m,
                OriginCountry = "",
                Description = ""
            };

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => productsManager.AddAsync(product));
            Assert.That(ex.Message, Is.EqualTo("Invalid product!"));

            var productInDb = await dbContext.Products.FirstOrDefaultAsync();
            Assert.That(productInDb, Is.Null);
        }

        [Test]
        public async Task AddProductAsync_TryToAddNullProduct_ShouldThrowValidationException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => productsManager.AddAsync(null));
            Assert.That(ex.Message, Is.EqualTo("Invalid product!"));

            var productInDb = await dbContext.Products.FirstOrDefaultAsync();
            Assert.That(productInDb, Is.Null);
        }

        [Test]
        public async Task DeleteProductAsync_WithValidProductCode_ShouldRemoveProductFromDb()
        {
            // Arrange
            var product = new Product
            {
                ProductCode = "PCode01",
                ProductName = "Product 1",
                Quantity = 5,
                Price = 15.5m,
                OriginCountry = "BG",
                Description = "Some description here"
            };

            await productsManager.AddAsync(product);
            //Verify the product is added in DB
            var productAddedInDb = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == product.ProductCode);
            Assert.That(productAddedInDb, Is.Not.Null);

            // Act
            await productsManager.DeleteAsync(product.ProductCode);

            // Assert
            var productInDb = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == product.ProductCode);
            Assert.That(productInDb, Is.Null);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public async Task DeleteProductAsync_TryToDeleteWithNullOrWhiteSpaceProductCode_ShouldThrowException(string productCode)
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => productsManager.DeleteAsync(productCode));
            Assert.That(ex.Message, Is.EqualTo("Product code cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenProductsExist_ShouldReturnAllProducts()
        {
            // Arrange
            var product1 = new Product
            {
                ProductCode = "PCode01",
                ProductName = "Product 1",
                Quantity = 5,
                Price = 15.5m,
                OriginCountry = "BG1",
                Description = "Some description here"
            };

            var product2 = new Product
            {
                ProductCode = "PCode02",
                ProductName = "Product 2",
                Quantity = 15,
                Price = 215.5m,
                OriginCountry = "BG2",
                Description = "Some description here again"
            };

            await productsManager.AddAsync(product1);
            await productsManager.AddAsync(product2);

            // Act
            var result = await productsManager.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var resultList = result.ToList();
            AssertPropertiesEqual(product1, resultList[0]);
            AssertPropertiesEqual(product2, resultList[1]);
        }

        [Test]
        public async Task GetAllAsync_WhenNoProductsExist_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.GetAllAsync());
            Assert.That(ex.Message, Is.EqualTo("No product found."));
        }

        [Test]
        public async Task SearchByOriginCountry_WithExistingOriginCountry_ShouldReturnMatchingProducts()
        {
            // Arrange
            var product1 = new Product
            {
                ProductCode = "PCode01",
                ProductName = "Product 1",
                Quantity = 5,
                Price = 15.5m,
                OriginCountry = "BG",
                Description = "Some description here"
            };

            var product2 = new Product
            {
                ProductCode = "PCode02",
                ProductName = "Product 2",
                Quantity = 15,
                Price = 215.5m,
                OriginCountry = "BG",
                Description = "Some description here again"
            };

            await productsManager.AddAsync(product1);
            await productsManager.AddAsync(product2);

            // Act
            var result = await productsManager.SearchByOriginCountry(product1.OriginCountry);


            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var resultList = result.ToList();
            AssertPropertiesEqual(product1, resultList[0]);
            AssertPropertiesEqual(product2, resultList[1]);
        }

        [Test]
        public async Task SearchByOriginCountryAsync_WithNonExistingOriginCountry_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.SearchByOriginCountry("invalid"));
            Assert.That(ex.Message, Is.EqualTo("No product found with the given country of origin."));
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public async Task SearchByOriginCountryAsync_WithWithNullOrWhiteSpaceOriginCountry_ShouldThrowKeyArgumentException(string country)
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => productsManager.SearchByOriginCountry(country));
            Assert.That(ex.Message, Is.EqualTo("Country name cannot be empty."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidProductCode_ShouldReturnProduct()
        {
            // Arrange
            var product1 = new Product
            {
                ProductCode = "PCode01",
                ProductName = "Product 1",
                Quantity = 5,
                Price = 15.5m,
                OriginCountry = "BG",
                Description = "Some description here"
            };

            var product2 = new Product
            {
                ProductCode = "PCode02",
                ProductName = "Product 2",
                Quantity = 15,
                Price = 215.5m,
                OriginCountry = "BG",
                Description = "Some description here again"
            };

            await productsManager.AddAsync(product1);
            await productsManager.AddAsync(product2);

            // Act
            var result = await productsManager.GetSpecificAsync(product2.ProductCode);

            // Assert
            Assert.That(result, Is.Not.Null);
            AssertPropertiesEqual(product2, result);
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidProductCode_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var productCode = "P-code-not-valid";
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.GetSpecificAsync(productCode));
            Assert.That(ex.Message, Is.EqualTo($"No product found with product code: {productCode}"));
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [Test]
        public async Task GetSpecificAsync_WithNullOrWhiteSpaceProductCode_ShouldThrowKeyArgumentException(string productCode)
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => productsManager.GetSpecificAsync(productCode));
            Assert.That(ex.Message, Is.EqualTo("Product code cannot be empty."));
        }

        [Test]
        public async Task UpdateAsync_WithValidProduct_ShouldUpdateProduct()
        {
            // Arrange
            var product = new Product
            {
                ProductCode = "PCode01",
                ProductName = "Product 1",
                Quantity = 5,
                Price = 15.5m,
                OriginCountry = "BG",
                Description = "Some description here"
            };

            await productsManager.AddAsync(product);

            // Act
            var productToUpdate = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == product.ProductCode);

            productToUpdate.ProductName = "updated name";
            productToUpdate.Quantity = 50;
            productToUpdate.Price = 10;
            productToUpdate.OriginCountry = "update";
            productToUpdate.Description = "updated desc";

            await productsManager.UpdateAsync(productToUpdate);

            // Assert
            var productInDb = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == productToUpdate.ProductCode);
            Assert.That(productInDb, Is.Not.Null);
            AssertPropertiesEqual(productToUpdate, productInDb);
        }

        [Test]
        public async Task UpdateAsync_WithInvalidProduct_ShouldThrowValidationException()
        {
            // Arrange
            var product = new Product
            {
                ProductCode = "PCode01",
                ProductName = "Product 1",
                Quantity = 5,
                Price = 15.5m,
                OriginCountry = "BG",
                Description = "Some description here"
            };

            await productsManager.AddAsync(product);

            // Act
            var productToUpdate = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == product.ProductCode);

            productToUpdate = new Product();

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => productsManager.UpdateAsync(productToUpdate));
            Assert.That(ex.Message, Is.EqualTo("Invalid product!"));
        }
    }
}
