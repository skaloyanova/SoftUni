using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _03_FirstTest;

public class FirstTest
{
    private ChromeDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://nakov.com";
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Test]
    public void VerifyPageTitle()
    {
        var pageTitle = _driver.Title;

        Assert.That(pageTitle.Contains("Svetlin Nakov – Official Web Site"));
        Console.WriteLine(pageTitle);
    }

    [Test]
    public void TestSearchFunctionality()
    {
        var searchButton = _driver.FindElement(By.ClassName("smoothScroll"));

        Assert.That(searchButton.Text, Does.Contain("SEARCH"));
        Console.WriteLine(searchButton.Text);

        searchButton.Click();

        var searchInputField = _driver.FindElement(By.Id("s"));
        var searchInputPlaceholder = searchInputField.GetAttribute("placeholder");

        Assert.That(searchInputPlaceholder, Is.EqualTo("Search this site"));
        Console.WriteLine(searchInputPlaceholder);
    }
}