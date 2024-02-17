using LibroConsoleAPI.Business;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class DeleteBookAsyncMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public DeleteBookAsyncMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }


        [Fact]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            //Arrange
            var validBook1 = new Book
            {
                Title = "Valid book1 title",
                Author = "Valid book1 author",
                ISBN = "1200000000001",
                YearPublished = 2020,
                Genre = "mystery",
                Pages = 100,
                Price = 10.5
            };

            var validBook2 = new Book
            {
                Title = "Valid book2 title",
                Author = "Valid book2 author",
                ISBN = "1200000000002",
                YearPublished = 2022,
                Genre = "mystery",
                Pages = 200,
                Price = 20.5
            };

            await _bookManager.AddAsync(validBook1);
            await _bookManager.AddAsync(validBook2);

            var booksInDb = _dbContext.Books.ToList();
            Assert.Equal(2, booksInDb.Count);

            //Act - delete a book
            await _bookManager.DeleteAsync(validBook1.ISBN);

            //Assert
            booksInDb = _dbContext.Books.ToList();
            Assert.Single(booksInDb);
            Assert.StrictEqual(validBook2, booksInDb[0]);
        }


        [Fact]
        public async Task DeleteBookAsync_WithValidISBN_usingDataSeeder_ShouldRemoveBookFromDb()
        {
            //Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            var booksInDb = _dbContext.Books.ToList();
            Assert.Equal(10, booksInDb.Count());

            //Act - delete a book
            await _bookManager.DeleteAsync("9780330258644");

            //Assert
            booksInDb = _dbContext.Books.ToList();
            var deletedBookInDb = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == "9780330258644");
            Assert.Equal(9, booksInDb.Count());
            Assert.Null(deletedBookInDb);
        }


        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        //[InlineData("1200000900001")]
        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException(string invalidISBN)
        {
            //Arrange
            var validBook = new Book
            {
                Title = "Valid book1 title",
                Author = "Valid book1 author",
                ISBN = "1200000000001",
                YearPublished = 2020,
                Genre = "mystery",
                Pages = 100,
                Price = 10.5
            };

            await _bookManager.AddAsync(validBook);

            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.StrictEqual(validBook, bookInDb);

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _bookManager.DeleteAsync(invalidISBN));
            Assert.Equal("ISBN cannot be empty.", exception.Message);
        }
    }
}
