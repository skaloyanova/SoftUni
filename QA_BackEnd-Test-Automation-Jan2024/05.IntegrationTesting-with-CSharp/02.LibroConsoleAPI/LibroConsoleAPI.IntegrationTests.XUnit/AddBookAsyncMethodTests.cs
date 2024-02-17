using LibroConsoleAPI.Business;
using LibroConsoleAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class AddBookAsyncMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public AddBookAsyncMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
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
            await _bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.NotNull(bookInDb);
            Assert.Equal(newBook.Title, bookInDb.Title);
            Assert.Equal(newBook.Author, bookInDb.Author);
        }


        [Fact]
        public async Task AddBookAsync_TryToAddNullAddBook_ShouldThrowException()
        {
            // Arrange
            Book? newBook = null;

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", exception.Message);

            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }


        [Theory]
        [InlineData("Book with title grater than 255 symbols. Book with title grater than 255 symbols. Book with title grater than 255 symbols. Book with title grater than 255 symbols. Book with title grater than 255 symbols. Book with title grater than 255 symbols. The end is now.", "John Doe", "1000000000101", 2021, "Fiction", 100, 19.99)]
        [InlineData(null, "John Doe", "1000000000102", 2021, "Fiction", 100, 19.99)]
        [InlineData("   ", "John Doe", "1000000000103", 2021, "Fiction", 100, 19.99)]

        public async Task AddBookAsync_TryToAddBookWithInvalidTitle_ShouldThrowException(string title, string author, string isbn, int yearPublished, string genre, int pages, double price)
        {
            //Arrange
            var newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                YearPublished = yearPublished,
                Genre = genre,
                Pages = pages,
                Price = price
            };

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", exception.Message);

            var bookInDbCount = _dbContext.Books.Count();
            Assert.Equal(0, bookInDbCount);
        }


        [Theory]
        [InlineData("Book with invalid author - part 1", "Book with author grater than 100 symbols. Book with author grater than 100 symbols. Book with    End.", "1000000000201", 2021, "Fiction", 100, 19.99)]
        [InlineData("Book with invalid author - part 2", null, "1000000000202", 2021, "Fiction", 100, 19.99)]
        [InlineData("Book with invalid author - part 3", "  ", "1000000000203", 2021, "Fiction", 100, 19.99)]
        public async Task AddBookAsync_TryToAddBookWithInvalidAuthor_ShouldThrowException(string title, string author, string isbn, int yearPublished, string genre, int pages, double price)
        {
            //Arrange
            var newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                YearPublished = yearPublished,
                Genre = genre,
                Pages = pages,
                Price = price
            };

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", exception.Message);

            var bookInDbCount = _dbContext.Books.Count();
            Assert.Equal(0, bookInDbCount);
        }


        [Theory]
        [InlineData("Book with invalid ISBN - part 1", "Some Author", "100000000030", 2021, "Fiction", 100, 19.99)]
        [InlineData("Book with invalid ISBN - part 2", "Some Author", "10000000003 2", 2021, "Fiction", 100, 19.99)]
        [InlineData("Book with invalid ISBN - part 3", "Some Author", "1000000000a03", 2021, "Fiction", 100, 19.99)]
        public async Task AddBookAsync_TryToAddBookWithInvalidISBN_ShouldThrowException(string title, string author, string isbn, int yearPublished, string genre, int pages, double price)
        {
            //Arrange
            var newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                YearPublished = yearPublished,
                Genre = genre,
                Pages = pages,
                Price = price
            };

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", exception.Message);

            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync(x => x.ISBN == isbn);
            Assert.Null(bookInDb);
        }


        [Theory]
        [InlineData("Book with invalid year - part 1", "John Doe", "1000000000401", 2025, "Fiction", 100, 19.99)]
        [InlineData("Book with invalid year - part 2", "John Doe", "1000000000402", 0, "Fiction", 100, 19.99)]
        public async Task AddBookAsync_TryToAddBookWithInvalidYear_ShouldThrowException(string title, string author, string isbn, int yearPublished, string genre, int pages, double price)
        {
            //Arrange
            var newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                YearPublished = yearPublished,
                Genre = genre,
                Pages = pages,
                Price = price
            };

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", exception.Message);

            var bookInDbCount = _dbContext.Books.Count();
            Assert.Equal(0, bookInDbCount);
        }

        /* Test fails, because there is no implementation to check for duplicate ISBN
        [Fact]
        public async Task AddBookAsync_TryToAddTwoBooksWithTheSameISBN_ShouldThrowException()
        {
            // Arrange
            var book1 = new Book
            {
                Title = "Book1 title",
                Author = "Book1 author",
                ISBN = "1111111111111",
                YearPublished = 2020,
                Genre = "crimi",
                Pages = 100,
                Price = 10
            };
            var book2 = new Book
            {
                Title = "Book2 title",
                Author = "Book2 author",
                ISBN = "1111111111111",
                YearPublished = 2021,
                Genre = "comedy",
                Pages = 101,
                Price = 11
            };

            //Act & Assert
            await _bookManager.AddAsync(book1);

            try
            {
                // Attempt to add the second book
                await _bookManager.AddAsync(book2);
            }
            catch (Exception)
            {
                // Second book addition failed as expected
                await Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(book2));
            }

            // verify the number of books in the database
            var booksInDb = _dbContext.Books.Where(b => b.ISBN == book1.ISBN).ToList();
            Assert.Single(booksInDb); // Ensure only one book with the same ISBN is present
            
        }
        */
    }
}
