using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _01_Calculator_POM;

public class CalculatorPOMTests
{
    public IWebDriver driver;
    SumNumbersPage page;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument(@"user-data-dir=C:\SeleniumChromeProfile");
        driver = new ChromeDriver(options);
        page = new SumNumbersPage(driver);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void TestResetAndIsEmptyFormMethods()
    {
        page.OpenPage();
        Assert.IsTrue(page.IsFormEmpty());

        string result = page.SumNumbers("1", "2");
        Assert.IsFalse(page.IsFormEmpty());

        page.ResetForm();
        Assert.IsTrue(page.IsFormEmpty());
    }

    [Test]
    public void Test_AddTwoNumbers_ValidInput()
    {
        page.OpenPage();
        string result = page.SumNumbers("-5", "3");
        Assert.That(result, Is.EqualTo("Sum: -2"));
    }

    [Test]
    public void Test_AddTwoNumbers_InvalidInput()
    {
        page.OpenPage();
        string result = page.SumNumbers("", "3");
        Assert.That(result, Is.EqualTo("Sum: invalid input"));
    }
}