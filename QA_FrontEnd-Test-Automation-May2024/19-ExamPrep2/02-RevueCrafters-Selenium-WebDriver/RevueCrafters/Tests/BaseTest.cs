using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RevueCrafters.Pages;

namespace RevueCrafters.Tests;

public class BaseTest
{
    protected IWebDriver driver;

    protected HomePage homePage;
    protected LoginPage loginPage;
    protected CreateRevuePage createRevuePage;
    protected MyRevuesPage myRevuePage;
    protected EditRevuePage editRevuePage;

    [OneTimeSetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("disable-search-engine-choice-screen");
        options.AddArgument("start-maximized");
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        homePage = new HomePage(driver);
        loginPage = new LoginPage(driver);
        createRevuePage = new CreateRevuePage(driver);
        myRevuePage = new MyRevuesPage(driver);
        editRevuePage = new EditRevuePage(driver);

        loginPage.OpenPage();
        loginPage.Login("stanislava@example.com", "123456", "testuser_stanislava");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }

    protected string[] GetRandomRevueData()
    {
        int random = new Random().Next(1000, 9999);
        string title = "Title-" + random;
        string imageUrl = "https://example.com/" + random + ".jpg";
        string description = "Description-" + random;

        return [title, imageUrl, description];
    }
}