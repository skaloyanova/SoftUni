using IdeaCenter.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IdeaCenter.Tests;

public class BaseTest
{
    protected IWebDriver driver;
    protected BasePage page;
    protected LoginPage loginPage;
    protected CreateIdeaPage createIdeaPage;
    protected MyIdeasPage myIdeasPage;
    protected ViewIdeaPage viewIdeaPage;
    protected EditIdeaPage editIdeaPage;

    [OneTimeSetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("disable-search-engine-choice-screen");
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        driver = new ChromeDriver(options);

        page = new BasePage(driver);
        loginPage = new LoginPage(driver);
        createIdeaPage = new CreateIdeaPage(driver);
        myIdeasPage = new MyIdeasPage(driver);
        viewIdeaPage = new ViewIdeaPage(driver);
        editIdeaPage = new EditIdeaPage(driver);

        loginPage.openPage();
        loginPage.Login("stanislava@example.com", "123456");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }

    protected int GetRandomNumber()
    {
        Random random = new Random();
        return random.Next(1000, 9999);
    }

    protected string GetRandomTitle()
    {
        return "Title-" + GetRandomNumber();
    }

    protected string GetRandomDescription()
    {
        return "Description-" + GetRandomNumber();
    }
}