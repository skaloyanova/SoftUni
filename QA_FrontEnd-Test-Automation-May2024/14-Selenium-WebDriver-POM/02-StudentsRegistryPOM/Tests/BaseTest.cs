using _02_StudentsRegistryPOM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _02_StudentsRegistryPOM.Tests;

public class BaseTest
{
    protected IWebDriver driver;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var options = new ChromeOptions();
        options.AddArgument(@"user-data-dir=C:\SeleniumChromeProfile");
        driver = new ChromeDriver(options);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

}