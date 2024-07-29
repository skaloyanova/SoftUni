using _03_SwagLabsAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _03_SwagLabsAutomation.Tests;

public class BaseTest
{
    protected IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument(@"user-data-dir=C:\SeleniumChromeProfile");
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        driver = new ChromeDriver(options);
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    protected void Login(string username, string password)
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        new LoginPage(driver).LoginUser(username, password);
    }
}