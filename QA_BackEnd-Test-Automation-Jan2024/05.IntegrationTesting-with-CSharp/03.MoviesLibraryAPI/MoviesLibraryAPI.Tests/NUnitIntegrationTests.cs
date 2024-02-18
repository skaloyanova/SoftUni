using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.Tests
{
    [TestFixture]
    public class NUnitIntegrationTests
    {
        private MoviesLibraryNUnitTestDbContext _dbContext;
        private IMoviesLibraryController _controller;
        private IMoviesRepository _repository;
        IConfiguration _configuration;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [SetUp]
        public async Task Setup()
        {
            string dbName = $"MoviesLibraryTestDb_{Guid.NewGuid()}";
            _dbContext = new MoviesLibraryNUnitTestDbContext(_configuration, dbName);

            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Test]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Assert.That(resultMovie, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(resultMovie.Title, Is.EqualTo(movie.Title));
                Assert.That(resultMovie.Director, Is.EqualTo(movie.Director));
                Assert.That(resultMovie.YearReleased, Is.EqualTo(movie.YearReleased));
                Assert.That(resultMovie.Genre, Is.EqualTo(movie.Genre));
                Assert.That(resultMovie.Duration, Is.EqualTo(movie.Duration));
                Assert.That(resultMovie.Rating, Is.EqualTo(movie.Rating));
            });
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange - empty Movie
            var invalidMovie = new Movie();

            // Act and Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.That(exception.Message, Is.EqualTo("Movie is not valid."));
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvidedMissingTitle_ShouldThrowValidationException()
        {
            // Arrange - skip required field 'Title'
            var invalidMovie = new Movie
            {
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act and Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.That(exception.Message, Is.EqualTo("Movie is not valid."));
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvidedMissingDirector_ShouldThrowValidationException()
        {
            // Arrange - skip required field 'Director'
            var invalidMovie = new Movie
            {
                Title = "Test Movie",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act and Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.That(exception.Message, Is.EqualTo("Movie is not valid."));
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvidedMissingYear_ShouldThrowValidationException()
        {
            // Arrange - skip required field 'Year'
            var invalidMovie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act and Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.That(exception.Message, Is.EqualTo("Movie is not valid."));
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvidedNullBook_ShouldThrowValidationException()
        {
            // Arrange - use null movie
            Movie? invalidMovie = null;

            // Act and Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.That(exception.Message, Is.EqualTo("Movie is not valid."));
        }

        [Test]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange            
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(movie);
            var movieExistInDb = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.That(movieExistInDb, Is.Not.Null);

            // Act
            await _controller.DeleteAsync(movie.Title);

            // Assert
            var movieDoesNotExistInDb = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.That(movieDoesNotExistInDb, Is.Null);
        }

        [Test]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(null));
        }

        [Test]
        public async Task DeleteAsync_WhenTitleIsEmpty_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(string.Empty));
        }

        [Test]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
            var movieTitle = "Missing movie";

            // Verify that movie with this title does not exist
            var movieDoesNotExistInDb = await _dbContext.Movies.Find(m => m.Title == movieTitle).FirstOrDefaultAsync();
            Assert.That(movieDoesNotExistInDb, Is.Null);

            //Try to delete movie
            Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync(movieTitle));
        }

        [Test]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
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

            // Act - get all movies in a list
            var result = _controller.GetAllAsync().Result.ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Title, Is.EqualTo(movie1.Title));
            Assert.That(result[1].Title, Is.EqualTo(movie2.Title));
        }

        [Test]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(movie);

            // Act
            var result = await _controller.GetByTitle(movie.Title);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Director, Is.EqualTo(movie.Director));
            Assert.That(result.YearReleased, Is.EqualTo(movie.YearReleased));
            Assert.That(result.Genre, Is.EqualTo(movie.Genre));
            Assert.That(result.Duration, Is.EqualTo(movie.Duration));
            Assert.That(result.Rating, Is.EqualTo(movie.Rating));
        }

        [Test]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Arrange - verify movie with specific title does not exist
            var movieTitle = "Some title";
            var movieCheck = await _dbContext.Movies.Find(m => m.Title == movieTitle).FirstOrDefaultAsync();
            Assert.That(movieCheck, Is.Null);

            // Act
            var result = await _controller.GetByTitle(movieTitle);

            // Assert
            Assert.IsNull(result);
        }


        [Test]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
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

            await _dbContext.Movies.InsertManyAsync(new[] { movie1, movie2 });

            // Act
            var result = _controller.SearchByTitleFragmentAsync("movie").Result.ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Title, Is.EqualTo(movie1.Title));
            Assert.That(result[1].Title, Is.EqualTo(movie2.Title));
        }

        [Test]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync("movies"));
            Assert.That(exception.Message, Is.EqualTo("No movies found."));
        }

        [Test]
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
            var updatedMovieInDb = await _controller.GetByTitle(movie.Title);

            Assert.That(updatedMovieInDb.Title, Is.EqualTo(movie.Title));
            Assert.That(updatedMovieInDb.Director, Is.EqualTo(movie.Director));
            Assert.That(updatedMovieInDb.YearReleased, Is.EqualTo(movie.YearReleased));
            Assert.That(updatedMovieInDb.Genre, Is.EqualTo(movie.Genre));
            Assert.That(updatedMovieInDb.Duration, Is.EqualTo(movie.Duration));
            Assert.That(updatedMovieInDb.Rating, Is.EqualTo(movie.Rating));
        }

        [Test]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange - movie without required fields
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

            // Act and Assert
            Assert.ThrowsAsync<ValidationException>(() => _controller.UpdateAsync(new Movie()));
        }


        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }
    }
}
