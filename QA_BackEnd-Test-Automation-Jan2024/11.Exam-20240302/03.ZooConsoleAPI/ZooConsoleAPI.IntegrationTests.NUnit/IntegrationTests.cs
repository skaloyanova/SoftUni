using NUnit.Framework;
using ZooConsoleAPI.Business;
using ZooConsoleAPI.Business.Contracts;
using ZooConsoleAPI.DataAccess;

//additional usings added
using ZooConsoleAPI.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZooConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestAnimalDbContext dbContext;
        private IAnimalsManager animalsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestAnimalDbContext();
            this.animalsManager = new AnimalsManager(new AnimalRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }

        // Added Helper method for asserting all properties of 2 objects
        public static void AssertPropertiesEqual<T>(T actual, T expected)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var actualValue = property.GetValue(actual);
                var expectedValue = property.GetValue(expected);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
        }

        //positive test
        [Test]
        public async Task AddAnimalAsync_ShouldAddNewAnimal()
        {
            // Arrange
            var animal = new Animal
            {
                CatalogNumber = "DOG000000001",
                Name = "Hristiana",
                Breed = "Shepherd dog",
                Type = "Mammal",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            // Act
            await animalsManager.AddAsync(animal);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == animal.CatalogNumber);

            Assert.That(animalInDb, Is.Not.Null);
            AssertPropertiesEqual(animalInDb, animal);
        }

        //Negative test
        [Test]
        public async Task AddAnimalAsync_TryToAddAnimalWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var animal = new Animal();

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => animalsManager.AddAsync(animal));
            Assert.That(ex.Message, Is.EqualTo("Invalid animal!"));
        }

        // Validation (5 additional test added below for validation):
        // CatalogNumber - RegEx [0-9A-Z]{12}
        // Name     [1..40]
        // Breed    [1..60]
        // Type     [1..30]
        // Age      [0..120]
        // Gender   [1..10]

        //Additional Validation test added - MAX border - possitive
        [Test]
        public async Task AddAnimalAsync_ValidationMaxBorder_ShouldAddNewAnimal()
        {
            //Arrange
            var validAnimal = new Animal
            {
                CatalogNumber = "DOG".PadRight(12, '1'),
                Name = "max name".PadRight(40, 'n'),
                Breed = "max breed".PadRight(60, 'b'),
                Type = "max type".PadRight(30, 't'),
                Age = 120,
                Gender = "gender".PadRight(10, 'g'),
                IsHealthy = true
            };

            // Act
            await animalsManager.AddAsync(validAnimal);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == validAnimal.CatalogNumber);

            Assert.That(animalInDb, Is.Not.Null);
            AssertPropertiesEqual(animalInDb, validAnimal);
        }

        //Additional Validation test added - MAX border - negative
        [Test]
        public async Task AddAnimalAsync_ValidationAboveMaxBorder_ShouldThrowValidationException()
        {
            //Arrange
            var invalidAnimal = new Animal
            {
                CatalogNumber = "DOG".PadRight(13, '1'),
                Name = "max name".PadRight(41, 'n'),
                Breed = "max breed".PadRight(61, 'b'),
                Type = "max type".PadRight(31, 't'),
                Age = 121,
                Gender = "gender".PadRight(11, 'g'),
                IsHealthy = false
            };

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => animalsManager.AddAsync(invalidAnimal));
            Assert.That(ex.Message, Is.EqualTo("Invalid animal!"));
        }

        //Additional Validation test added - MIN border - possitive
        [Test]
        public async Task AddAnimalAsync_ValidationMinBorder_ShouldAddNewAnimal()
        {
            //Arrange
            var validAnimal = new Animal
            {
                CatalogNumber = "DOG".PadRight(12, '1'),
                Name = "n",
                Breed = "b",
                Type = "t",
                Age = 0,
                Gender = "g",
                IsHealthy = true
            };

            // Act
            await animalsManager.AddAsync(validAnimal);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == validAnimal.CatalogNumber);

            Assert.That(animalInDb, Is.Not.Null);
            AssertPropertiesEqual(animalInDb, validAnimal);
        }

        //Additional Validation test added - MIN border - negative
        [Test]
        public async Task AddAnimalAsync_ValidationBelowMinBorder_ShouldThrowValidationException()
        {
            //Arrange
            var invalidAnimal = new Animal
            {
                CatalogNumber = "DOG".PadRight(11, '1'),
                Name = "",
                Breed = "",
                Type = "",
                Age = -1,
                Gender = "",
                IsHealthy = true
            };

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => animalsManager.AddAsync(invalidAnimal));
            Assert.That(ex.Message, Is.EqualTo("Invalid animal!"));
        }

        //Additional Validation test added - negative
        [Test]
        public async Task AddAnimalAsync_TryToAddNullAnimal_ShouldThrowValidationException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => animalsManager.AddAsync(null));
            Assert.That(ex.Message, Is.EqualTo("Invalid animal!"));
        }


        [Test]
        public async Task DeleteAnimalAsync_WithValidCatalogNumber_ShouldRemoveAnimalFromDb()
        {
            // Arrange
            var animal = new Animal
            {
                CatalogNumber = "DOG000000001",
                Name = "Hristiana",
                Breed = "Shepherd dog",
                Type = "Mammal",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            await animalsManager.AddAsync(animal);

            //Verify that animal is added in DB
            var animalAddedInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == animal.CatalogNumber);
            Assert.That(animalAddedInDb, Is.Not.Null);

            // Act
            await animalsManager.DeleteAsync(animal.CatalogNumber);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == animal.CatalogNumber);
            Assert.That(animalInDb, Is.Null);
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task DeleteAnimalAsync_TryToDeleteWithNullOrWhiteSpaceCatalogNumber_ShouldThrowException(string invalidCatalogNumber)
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => animalsManager.DeleteAsync(invalidCatalogNumber));
            Assert.That(ex.Message, Is.EqualTo("Catalog number cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenAnimalsExist_ShouldReturnAllAnimals()
        {
            // Arrange
            var animal1 = new Animal
            {
                CatalogNumber = "DOG000000001",
                Name = "Hristiana",
                Breed = "Shepherd dog",
                Type = "Mammal",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            var animal2 = new Animal
            {
                CatalogNumber = "DOG000000002",
                Name = "Mikey",
                Breed = "Beagle",
                Type = "Mammal",
                Age = 12,
                Gender = "Male",
                IsHealthy = false
            };

            await animalsManager.AddAsync(animal1);
            await animalsManager.AddAsync(animal2);

            // Act
            var result = await animalsManager.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var resultList = result.ToList();
            AssertPropertiesEqual(resultList[0], animal1);
            AssertPropertiesEqual(resultList[1], animal2);
        }

        [Test]
        public async Task GetAllAsync_WhenNoAnimalsExist_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => animalsManager.GetAllAsync());
            Assert.That(ex.Message, Is.EqualTo("No animal found."));
        }

        [Test]
        public async Task SearchByTypeAsync_WithExistingType_ShouldReturnMatchingAnimals()
        {
            // Arrange
            var animal1 = new Animal
            {
                CatalogNumber = "DOG000000001",
                Name = "Hristiana",
                Breed = "Shepherd dog",
                Type = "Mammal",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            var animal2 = new Animal
            {
                CatalogNumber = "DOG000000002",
                Name = "Mikey",
                Breed = "Beagle",
                Type = "Mammal",
                Age = 12,
                Gender = "Male",
                IsHealthy = false
            };

            var animal3 = new Animal
            {
                CatalogNumber = "CAT000000001",
                Name = "Carry",
                Breed = "Cat",
                Type = "Other",
                Age = 5,
                Gender = "Female",
                IsHealthy = true
            };

            await animalsManager.AddAsync(animal1);
            await animalsManager.AddAsync(animal2);
            await animalsManager.AddAsync(animal3);

            // Act
            var result = await animalsManager.SearchByTypeAsync(animal1.Type);   //should return animal1 and animal2

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var resultList = result.ToList();
            AssertPropertiesEqual(resultList[0], animal1);
            AssertPropertiesEqual(resultList[1], animal2);
        }

        [Test]
        public async Task SearchByTypeAsync_WithNonExistingType_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => animalsManager.SearchByTypeAsync("invalid"));
            Assert.That(ex.Message, Is.EqualTo("No animal found with the given type."));
        }

        //Additional test added for searching by null or whiteSpace Type
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public async Task SearchByTypeAsync_WithNullOrWhiteSpaceType_ShouldThrowArgumentException(string invalidType)
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(() => animalsManager.SearchByTypeAsync(invalidType));
            Assert.That(ex.Message, Is.EqualTo("Animal type cannot be empty."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidCatalogNumber_ShouldReturnAnimal()
        {
            // Arrange
            var animal1 = new Animal
            {
                CatalogNumber = "DOG000000001",
                Name = "Hristiana",
                Breed = "Shepherd dog",
                Type = "Mammal",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            var animal2 = new Animal
            {
                CatalogNumber = "DOG000000002",
                Name = "Mikey",
                Breed = "Beagle",
                Type = "Mammal2",
                Age = 12,
                Gender = "Male",
                IsHealthy = false
            };

            await animalsManager.AddAsync(animal1);
            await animalsManager.AddAsync(animal2);

            // Act
            var result = await animalsManager.GetSpecificAsync(animal2.CatalogNumber);

            // Assert
            Assert.That(result, Is.Not.Null);
            AssertPropertiesEqual(result, animal2);
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidCatalogNumber_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var catalogNumber = "INVALID00012";

            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => animalsManager.GetSpecificAsync(catalogNumber));
            Assert.That(ex.Message, Is.EqualTo($"No animal found with catalog number: {catalogNumber}"));
        }

        //Additional test added to get specific animal by null or whiteSpace catalog number
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public async Task GetSpecificAsync_WithNullOrWhiteSpaceCatalogNumber_ShouldThrowArgumentException(string invalidCatalogNumber)
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => animalsManager.GetSpecificAsync(invalidCatalogNumber));
            Assert.That(ex.Message, Is.EqualTo("Catalog number cannot be empty."));
        }

        [Test]
        public async Task UpdateAsync_WithValidAnimal_ShouldUpdateAnimal()
        {
            // Arrange
            var animal = new Animal
            {
                CatalogNumber = "DOG000000001",
                Name = "Hristiana",
                Breed = "Shepherd dog",
                Type = "Mammal",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            await animalsManager.AddAsync(animal);

            var animalToUpdate = await dbContext.Animals.FirstOrDefaultAsync(a => a.Id == animal.Id);

            animalToUpdate.CatalogNumber = "DOG000000002";
            animalToUpdate.Name = "updated name";
            animalToUpdate.Breed = "updated breed";
            animalToUpdate.Type = "updated type";
            animalToUpdate.Age = 20;
            animalToUpdate.Gender = "updated g";
            animalToUpdate.IsHealthy = false;

            // Act
            await animalsManager.UpdateAsync(animalToUpdate);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.Id == animal.Id);

            Assert.That(animalInDb, Is.Not.Null);
            AssertPropertiesEqual(animalInDb, animalToUpdate);
        }

        [Test]
        public async Task UpdateAsync_WithInvalidAnimal_ShouldThrowValidationException()
        {
            // Arrange
            var invalidAnimal = new Animal();

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => animalsManager.UpdateAsync(invalidAnimal));
            Assert.That(ex.Message, Is.EqualTo("Invalid animal!"));
        }
    }
}

