using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetSpecificAsyncMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetSpecificAsyncMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }


        [Fact]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
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

            var result = await _bookManager.GetSpecificAsync("1111111111111");
            Assert.NotNull(result);
            Assert.StrictEqual(newBook, result);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task GetSpecificAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException(string isbn)
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

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _bookManager.GetSpecificAsync(isbn));
            Assert.Equal("ISBN cannot be empty.", exception.Message);
        }

        [Fact]
        public async Task GetSpecificAsync_WithValidNonExistentIsbn_ShouldThrowKeyNotFoundException()
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

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetSpecificAsync("2222211111111"));
            Assert.Equal("No book found with ISBN: 2222211111111", exception.Message);
        }

    }
}
