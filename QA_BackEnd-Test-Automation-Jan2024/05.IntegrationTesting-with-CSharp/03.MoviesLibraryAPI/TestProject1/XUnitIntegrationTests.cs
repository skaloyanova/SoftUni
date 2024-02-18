using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Data.Seed;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.XUnitTests
{
    public class XUnitIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly MoviesLibraryXUnitTestDbContext _dbContext;
        private readonly IMoviesLibraryController _controller;
        private readonly IMoviesRepository _repository;

        public XUnitIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);

            InitializeDatabaseAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeDatabaseAsync()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Fact]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Assert.NotNull(resultMovie);
            Assert.Equal("Test Movie", resultMovie.Title);
            Assert.Equal("Test Director", resultMovie.Director);
            Assert.Equal(2022, resultMovie.YearReleased);
            Assert.Equal("Action", resultMovie.Genre);
            Assert.Equal(120, resultMovie.Duration);
            Assert.Equal(7.5, resultMovie.Rating);
        }

        [Fact]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                Title = "",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act and Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.Equal("Movie is not valid.", exception.Message);
        }

        [Fact]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            await _controller.AddAsync(movie);

            // Act
            var movieExist = await _controller.GetByTitle(movie.Title);
            Assert.NotNull(movieExist);

            await _controller.DeleteAsync(movie.Title);

            // Assert
            //var result = await _controller.GetByTitle(movie.Title);
            var result = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException()
        {
            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(null));
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleIsEmpty_ShouldThrowArgumentException()
        {
            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(""));
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync("None existing title"));
        }

        [Fact]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Empty(result);

        }

        [Fact]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        {
            // Arrange - add 2 movies in DB
            var movie1 = new Movie
            {
                Title = "Test Movie 1",
                Director = "Test Director 1",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            var movie2 = new Movie
            {
                Title = "Test Movie 2",
                Director = "Test Director 2",
                YearReleased = 2021,
                Genre = "Comedy",
                Duration = 100,
                Rating = 8.5
            };

            await _controller.AddAsync(movie1);
            await _controller.AddAsync(movie2);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());

            var movie1FromDb = result.ToList()[0];
            var movie2FromDb = result.ToList()[1];
            //Assert.StrictEqual(movie1, movie1FromDb);
            //Assert.StrictEqual(movie2, movie2FromDb);
            Assert.Equal(movie1.Title, movie1FromDb.Title);
            Assert.Equal(movie1.Director, movie1FromDb.Director);
            Assert.Equal(movie1.YearReleased, movie1FromDb.YearReleased);
            Assert.Equal(movie1.Genre, movie1FromDb.Genre);
            Assert.Equal(movie1.Duration, movie1FromDb.Duration);
            Assert.Equal(movie1.Rating, movie1FromDb.Rating);

            Assert.Equal(movie2.Title, movie2FromDb.Title);
            Assert.Equal(movie2.Director, movie2FromDb.Director);
            Assert.Equal(movie2.YearReleased, movie2FromDb.YearReleased);
            Assert.Equal(movie2.Genre, movie2FromDb.Genre);
            Assert.Equal(movie2.Duration, movie2FromDb.Duration);
            Assert.Equal(movie2.Rating, movie2FromDb.Rating);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            await _controller.AddAsync(movie);

            // Act
            var result = await _controller.GetByTitle(movie.Title);

            // Assert
            Assert.NotNull(result);

            var movieFromDb = _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefault();
            Assert.Equal(movie.Title, movieFromDb.Title);
            Assert.Equal(movie.Director, movieFromDb.Director);
            Assert.Equal(movie.YearReleased, movieFromDb.YearReleased);
            Assert.Equal(movie.Genre, movieFromDb.Genre);
            Assert.Equal(movie.Duration, movieFromDb.Duration);
            Assert.Equal(movie.Rating, movieFromDb.Rating);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Act
            var result = await _controller.GetByTitle("Missing movie");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange - add 2 movies in DB
            var movie1 = new Movie
            {
                Title = "Test 1",
                Director = "Test Director 1",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            var movie2 = new Movie
            {
                Title = "Test Movie 2",
                Director = "Test Director 2",
                YearReleased = 2021,
                Genre = "Comedy",
                Duration = 100,
                Rating = 8.5
            };

            await _controller.AddAsync(movie1);
            await _controller.AddAsync(movie2);

            // Act
            var result = await _controller.SearchByTitleFragmentAsync("movie");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);

            Assert.Equal(movie2.Title, result.FirstOrDefault().Title);
            Assert.Equal(movie2.Director, result.FirstOrDefault().Director);
            Assert.Equal(movie2.YearReleased, result.FirstOrDefault().YearReleased);
            Assert.Equal(movie2.Genre, result.FirstOrDefault().Genre);
            Assert.Equal(movie2.Duration, result.FirstOrDefault().Duration);
            Assert.Equal(movie2.Rating, result.FirstOrDefault().Rating);
        }

        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync("invalid title"));
        }

        [Fact]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie 1",
                Director = "Test Director 1",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(movie);

            // Modify movie
            movie.Title = "Updated " + movie.Title;
            movie.Director = "Updated " + movie.Director;
            movie.YearReleased = 2020;
            movie.Genre = "Updated " + movie.Genre;
            movie.Duration = 100;
            movie.Rating = 8.3;

            // Act
            await _controller.UpdateAsync(movie);

            // Assert
            var updatedMovie = await _controller.GetByTitle(movie.Title);
            Assert.NotNull(updatedMovie);

            //Assert.Equal(movie.Title, updatedMovie.Title);
            //Assert.Equal(movie.Director, updatedMovie.Director);
            //Assert.Equal(movie.YearReleased, updatedMovie.YearReleased);
            //Assert.Equal(movie.Genre, updatedMovie.Genre);
            //Assert.Equal(movie.Duration, updatedMovie.Duration);
            //Assert.Equal(movie.Rating, updatedMovie.Rating);

            // Using Helper method to compare properties
            AssertHelper.AssertPropertiesEqual(movie, updatedMovie);
        }

        [Fact]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie 1",
                Director = "Test Director 1",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(movie);

            // Modify movie
            movie.Title = "Updated " + movie.Title;
            movie.Director = "";
            movie.YearReleased = 2020;
            movie.Genre = "Updated " + movie.Genre;
            movie.Duration = 100;
            movie.Rating = 8.3;

            // Act and Assert
            await Assert.ThrowsAsync<ValidationException>(() => _controller.UpdateAsync(movie));
        }
    }
}
