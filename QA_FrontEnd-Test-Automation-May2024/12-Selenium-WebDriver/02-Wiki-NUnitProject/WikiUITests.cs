using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _02_Wiki_NUnitProject;

public class WikiUITests
{
    private ChromeDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://wikipedia.org");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void CheckPageTitle()
    {
        Assert.That(driver.Title, Is.EqualTo("Wikipedia"));
    }

    [Test]
    public void CheckQAPageTitle()
    {
        driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance" + Keys.Enter);

        Assert.That(driver.Title, Is.EqualTo("Quality assurance - Wikipedia"));
    }
}