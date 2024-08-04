using _03_SwagLabsAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _03_SwagLabsAutomation.Tests;

public class BaseTest
{
    protected IWebDriver driver;
    protected LoginPage loginPage;
    protected InventoryPage inventoryPage;
    protected CartPage cartPage;
    protected CheckoutPage checkoutPage;
    protected HiddenMenuPage hiddenMenuPage;

    [SetUp]
    public void SetUp()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument(@"user-data-dir=C:\SeleniumChromeProfile");
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        driver = new ChromeDriver(options);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        inventoryPage = new InventoryPage(driver);
        loginPage = new LoginPage(driver);
        cartPage = new CartPage(driver);
        checkoutPage = new CheckoutPage(driver);
        hiddenMenuPage = new HiddenMenuPage(driver);
    }

    [TearDown]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }

    protected void Login(string username, string password)
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage.LoginUser(username, password);
    }
}