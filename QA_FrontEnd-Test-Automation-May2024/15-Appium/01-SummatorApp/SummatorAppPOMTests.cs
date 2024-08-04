using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace _01_SummatorApp;

public class SummatorAppPOMTests
{
    private SummatorPage _summatorPage;
    private AndroidDriver _driver;
    private AppiumLocalService _appiumLocalService;

    [OneTimeSetUp]
    public void Setup()
    {
        _appiumLocalService = new AppiumServiceBuilder()
            .WithIPAddress("127.0.0.1")
            .UsingPort(4723)
            .Build();

        _appiumLocalService.Start();

        AppiumOptions options = new AppiumOptions
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            App = @"D:\_Coding\SoftUni\QA_FrontEnd-Test-Automation-May2024\15-Appium\com.example.androidappsummator.apk"
        };

        _driver = new AndroidDriver(_appiumLocalService, options);

        _summatorPage = new SummatorPage(_driver);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _appiumLocalService?.Dispose();
    }

    [Test]
    public void TestWithValidInput()
    {
        string result = _summatorPage.Calculate("1.4", "-0.4");
        Assert.That(result, Is.EqualTo("1.0"));
    }

    [Test]
    public void TestWithValidData()
    {
        string result = _summatorPage.Calculate("2", "3");
        Assert.That(result, Is.EqualTo("5"));
    }

    [Test]
    public void TestWithInvalidData_num1AndNum2AreEmpty()
    {
        string result = _summatorPage.Calculate("", "");
        Assert.That(result, Is.EqualTo("error"));
    }

    [Test]
    public void TestWithInvalidData_num1IsEmpty()
    {
        string result = _summatorPage.Calculate("", "5");
        Assert.That(result, Is.EqualTo("error"));
    }

    [Test]
    public void TestWithInvalidData_num2IsEmpty()
    {
        string result = _summatorPage.Calculate("2", "");
        Assert.That(result, Is.EqualTo("error"));
    }

    [TestCase("1", "4", "5")]
    [TestCase("0", "4", "4")]
    [TestCase("-1", "-4", "-5")]
    [TestCase("1", "-4", "-3")]
    [TestCase("0", "0", "0")]
    [TestCase("0.9", "2.56", "3.46")]
    public void TestWithValidData_Paramtarized(string number1, string number2, string expectedResult)
    {
        string result = _summatorPage.Calculate(number1, number2);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
