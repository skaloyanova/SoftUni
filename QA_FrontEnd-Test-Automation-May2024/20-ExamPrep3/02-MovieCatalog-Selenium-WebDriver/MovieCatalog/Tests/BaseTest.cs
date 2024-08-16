using MovieCatalog.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MovieCatalog.Tests;

public class BaseTest
{
    protected IWebDriver driver;
    protected LoginPage loginPage;
    protected MainPage mainPage;
    protected AddMoviePage addMoviePage;
    protected AllMoviesPage allMoviesPage;
    protected WatchedMoviesPage watchedMoviesPage;
    protected EditMoviePage editMoviePage;
    protected DeleteMoviePage deleteMoviePage;

    [OneTimeSetUp]
    public void Setup()
    {
        // Configure Chrome options and initialize the WebDriver
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("disable-search-engine-choice-screen");
        options.AddArgument("start-maximized");
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        driver = new ChromeDriver(options);

        // Initialize the Page objects
        loginPage = new LoginPage(driver);
        mainPage = new MainPage(driver);
        addMoviePage = new AddMoviePage(driver);
        allMoviesPage = new AllMoviesPage(driver);
        watchedMoviesPage = new WatchedMoviesPage(driver);
        editMoviePage = new EditMoviePage(driver);
        deleteMoviePage = new DeleteMoviePage(driver);

        // Login to the App, and verify login is sucessful
        loginPage.Login("testuser100@example.com", "123123");
        Assert.That(mainPage.IsPageOpen());
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    public string[] GetRandomTitleAndDescription()
    {
        int random = new Random().Next(1000, 9999);
        string title = "Title - " + random;
        string description = "Description - " + random;

        return [title, description];
    }
}