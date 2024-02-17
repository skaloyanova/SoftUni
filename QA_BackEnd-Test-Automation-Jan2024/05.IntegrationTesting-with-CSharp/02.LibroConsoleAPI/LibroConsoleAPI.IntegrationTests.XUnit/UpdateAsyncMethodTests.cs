using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class UpdateAsyncMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public UpdateAsyncMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }


        [Fact]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            //Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            //Act
            var bookToUpdate = await _dbContext.Books.FirstOrDefaultAsync();

            var updatedBook = new Book
            {
                ISBN = bookToUpdate.ISBN,   //keep the same ISBN
                Title = bookToUpdate.Title + " updated",
                Author = bookToUpdate.Author + " updated",
                YearPublished = bookToUpdate.YearPublished - 1,
                Genre = bookToUpdate.Genre + " updated",
                Pages = bookToUpdate.Pages + 1,
                Price = bookToUpdate.Price + 2
            };

            bookToUpdate.Title = updatedBook.Title;
            bookToUpdate.Author = updatedBook.Author;
            bookToUpdate.YearPublished = updatedBook.YearPublished;
            bookToUpdate.Genre = updatedBook.Genre;
            bookToUpdate.Pages = updatedBook.Pages;
            bookToUpdate.Price = updatedBook.Price;

            await _bookManager.UpdateAsync(bookToUpdate);

            //Assert
            var updatedBookInDb = await _bookManager.GetSpecificAsync(bookToUpdate.ISBN);

            Assert.Equal(updatedBook.Title, updatedBookInDb.Title);
            Assert.Equal(updatedBook.Author, updatedBookInDb.Author);
            Assert.Equal(updatedBook.YearPublished, updatedBookInDb.YearPublished);
            Assert.Equal(updatedBook.Genre, updatedBookInDb.Genre);
            Assert.Equal(updatedBook.Pages, updatedBookInDb.Pages);
            Assert.Equal(updatedBook.Price, updatedBookInDb.Price);


        }


        [Fact]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            //Arrange
            var book = new Book();  //invalid book - missing fields

            //Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _bookManager.UpdateAsync(book));
        }


    }
}
