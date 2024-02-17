using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public  class IntegrationTests
    {
        private TestLibroDbContext dbContext;
        private IBookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            string dbName = $"TestDb_{Guid.NewGuid()}";
            this.dbContext = new TestLibroDbContext(dbName);
            this.bookManager = new BookManager(new BookRepository(this.dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            this.dbContext.Dispose();
        }

        [Test]
        public async Task AddBookAsync_ShouldAddBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            await bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.That(bookInDb, Is.Not.Null);
            Assert.That(bookInDb.Title, Is.EqualTo("Test Book"));
            Assert.That(bookInDb.Author, Is.EqualTo("John Doe"));
        }

        [TestCase(0)]
        [TestCase(-5)]
        public async Task AddBookAsync_TryToAddBookWithInvalidPages_ShouldThrowException(int pages)
        {
            //Arrange
            var newBook = new Book
            {
                Title = "Book with invalid pages",
                Author = "Some author",
                ISBN = "1100000009001",
                YearPublished = 2000,
                Genre = "comedy",
                Pages = pages,
                Price = 20.01
            };

            //Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));
            Assert.That(exception.Message, Is.EqualTo("Book is invalid."));
        }

        [TestCase(0.0)]
        [TestCase(-5.0)]
        public async Task AddBookAsync_TryToAddBookWithInvalidPrice_ShouldThrowException(double price)
        {
            //Arrange
            var newBook = new Book
            {
                Title = "Book with invalid pages",
                Author = "Some author",
                ISBN = "1100000009001",
                YearPublished = 2000,
                Genre = "comedy",
                Pages = 100,
                Price = price
            };

            //Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));
            Assert.That(exception.Message, Is.EqualTo("Book is invalid."));

            var bookInDb = await dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.Null(bookInDb);
        }

        [Test]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task SearchByTitleAsync_WithInvalidTitleFragment_ShouldThrowKeyNotFoundException()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task GetSpecificAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            throw new NotImplementedException();
        }


        [Test]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            throw new NotImplementedException();
        }

    }
}
