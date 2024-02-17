using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class SearchByTitleAsyncMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public SearchByTitleAsyncMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }


        [Fact]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            //Arrange
            var book1 = new Book { Title = "Book 1", Author = "John Doe", ISBN = "2200000000111", YearPublished = 2020, Genre = "Fiction", Pages = 100, Price = 19.99 };
            var book2 = new Book { Title = "Booking", Author = "John Doe", ISBN = "2200000000112", YearPublished = 2021, Genre = "Fiction", Pages = 100, Price = 19.99 };
            var book3 = new Book { Title = "Some title", Author = "John Doe", ISBN = "2200000000113", YearPublished = 2022, Genre = "Fiction", Pages = 100, Price = 19.99 };

            await _bookManager.AddAsync(book1);
            await _bookManager.AddAsync(book2);
            await _bookManager.AddAsync(book3);

            //Act
            var result = _bookManager.SearchByTitleAsync("book").Result.ToList();

            //Assert - should return book1 and book2
            Assert.Equal(2, result.Count);
            Assert.StrictEqual(book1, result[0]);
            Assert.StrictEqual(book2, result[1]);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task SearchByTitleAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException(string title)
        {
            var newBook = new Book
            {
                Title = "Book 1",
                Author = "Author 1",
                ISBN = "1111111111111",
                YearPublished = 2021,
                Genre = "comedy",
                Pages = 250,
                Price = 19.5
            };

            await _bookManager.AddAsync(newBook);

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _bookManager.SearchByTitleAsync(title));
            Assert.Equal("Title fragment cannot be empty.", exception.Message);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithValidNonExistentIsbn_ShouldThrowKeyNotFoundException()
        {
            var newBook = new Book
            {
                Title = "Book 1",
                Author = "Author 1",
                ISBN = "1111111111111",
                YearPublished = 2021,
                Genre = "comedy",
                Pages = 250,
                Price = 19.5
            };

            await _bookManager.AddAsync(newBook);

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.SearchByTitleAsync("hello"));
            Assert.Equal("No books found with the given title fragment.", exception.Message);
        }
    }
}
