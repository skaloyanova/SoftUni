using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetAllAsyncMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetAllAsyncMethodTests()
        { 
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            //Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            var isbnList = new List<string>
            {
                "9780385487256",
                "9780312857753",
                "9780330258644",
                "9780765316323",
                "9780062315007",
                "9780307743394",
                "9780140449276",
                "9780679601939",
                "9780099578082",
                "9780143039655"
            };

            //Act
            var result = await _bookManager.GetAllAsync();

            //Assert
            Assert.Equal(10, result.Count());

            int i = 0;
            foreach(var book in result)
            {
                Assert.Equal(isbnList[i++], book.ISBN);
            }
        }


        [Fact]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetAllAsync());
            Assert.Equal("No books found.", exception.Message);

        }

    }
}