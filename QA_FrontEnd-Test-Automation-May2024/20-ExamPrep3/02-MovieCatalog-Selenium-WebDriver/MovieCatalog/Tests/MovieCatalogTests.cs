using OpenQA.Selenium;

namespace MovieCatalog.Tests
{
    public class MovieCatalogTests : BaseTest
    {
        private string randomMovieTitle = "";
        private string randomMovieDescription = "";
        private string editedMovieTitle = "";

        [Test, Order(1)]
        public void AddMovieWithoutTitleTest()
        {
            addMoviePage.OpenPage();
            addMoviePage.CreateMovie("", "some description");
            addMoviePage.AssertEmptyTitleMessage();
        }

        [Test, Order(2)]
        public void AddMovieWithoutDescriptionTest()
        {
            addMoviePage.OpenPage();
            addMoviePage.CreateMovie("some title", "");
            addMoviePage.AssertEmptyDescriptionMessage();
        }

        [Test, Order(3)]
        public void AddMovieWithRandomTitleTest()
        {
            string[] movieData = GetRandomTitleAndDescription();
            randomMovieTitle = movieData[0];
            randomMovieDescription = movieData[1];

            addMoviePage.OpenPage();
            addMoviePage.CreateMovie(randomMovieTitle, randomMovieDescription);

            allMoviesPage.OpenPage();
            var lastMovie = allMoviesPage.GetLastCreatedMovie();
            var lastMovieTitle = allMoviesPage.GetMovieTitle(lastMovie);

            // Print created title and title of last movie
            Console.WriteLine($"Random Title, Description => {randomMovieTitle} <> {randomMovieDescription}");
            Console.WriteLine($"lastMovieTitle            => {lastMovieTitle}");

            // Assert title
            Assert.That(lastMovieTitle, Is.EqualTo(randomMovieTitle.ToUpper()));
        }

        [Test, Order(4)]
        public void EditLastAddedMovieTest()
        {
            allMoviesPage.OpenPage();
            var lastMovie = allMoviesPage.GetLastCreatedMovie();

            editedMovieTitle = randomMovieTitle + " Updated";
            string editedDescription = randomMovieDescription + " Updated";

            // Edit Movie
            allMoviesPage.ClickEditButtonOnMovie(lastMovie);
            Assert.That(editMoviePage.IsPageOpen());

            editMoviePage.EditMovie(editedMovieTitle, editedDescription);

            // Assert success message
            editMoviePage.AssertEditSuccessfulMessage();

            // Assert title is edited
            allMoviesPage.OpenPage();
            lastMovie = allMoviesPage.GetLastCreatedMovie();
            string lastMovieTitle = allMoviesPage.GetMovieTitle(lastMovie);

            Assert.That(lastMovieTitle, Is.EqualTo(editedMovieTitle.ToUpper()));
        }

        [Test, Order(5)]
        public void MarkLastAddedMovieAsWatchedTest()
        {
            // Locate last movie and mark it as watched
            allMoviesPage.OpenPage();
            var lastMovie = allMoviesPage.GetLastCreatedMovie();
            allMoviesPage.ClickMarkMovieAsWatched(lastMovie);

            // Navigate to the Watched Movies Page and locate the last movie
            watchedMoviesPage.OpenPage();
            var lastWatchedMovie = watchedMoviesPage.GetLastWatchedMovie();
            var lastWatchedMovieTitle = watchedMoviesPage.GetMovieTitle(lastWatchedMovie);

            // Assert title of last movie
            Assert.That(lastWatchedMovieTitle, Is.EqualTo(editedMovieTitle.ToUpper()));
        }

        [Test, Order(6)]
        public void DeleteLastAddedMovieTest()
        {
            // Locate last movie and Delete it
            allMoviesPage.OpenPage();
            var lastMovie = allMoviesPage.GetLastCreatedMovie();
            allMoviesPage.ClickDeleteButtonOnMovie(lastMovie);

            // Assert that user is redirected to delete page and confirm deletion
            Assert.That(deleteMoviePage.IsPageOpen());
            deleteMoviePage.ConfirmMovieDeletion();

            // Assert success message
            deleteMoviePage.AssertDeleteSuccessfulMessage();
        }
    }
}
