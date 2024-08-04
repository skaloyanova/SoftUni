using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Internal;

namespace _01_SummatorApp;

public class SummatorAppTests
{
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

        var androidOptions = new AppiumOptions
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            App = @"D:\_Coding\SoftUni\QA_FrontEnd-Test-Automation-May2024\15-Appium\com.example.androidappsummator.apk"
        };

        _driver = new AndroidDriver(_appiumLocalService, androidOptions);
    }

    [OneTimeTearDown]
    public void TearDown() {
        _driver?.Quit();
        _driver?.Dispose();
        _appiumLocalService?.Dispose();
    }

    [Test]
    public void TestWithValidData()
    {
        IWebElement num1 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
        IWebElement num2 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
        IWebElement calcButton = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
        IWebElement result = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

        num1.Clear();
        num1.SendKeys("2");
        num2.Clear();
        num2.SendKeys("3");
        calcButton.Click();

        Assert.That(result.Text, Is.EqualTo("5"));
    }

    [Test]
    public void TestWithInvalidData_num1AndNum2AreEmpty()
    {
        IWebElement num1 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
        IWebElement num2 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
        IWebElement calcButton = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
        IWebElement result = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

        num1.Clear();
        num2.Clear();
        calcButton.Click();

        Assert.That(result.Text, Is.EqualTo("error"));
    }

    [Test]
    public void TestWithInvalidData_num1IsEmpty()
    {
        IWebElement num1 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
        IWebElement num2 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
        IWebElement calcButton = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
        IWebElement result = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

        num1.Clear();
        num2.Clear();
        num2.SendKeys("5");
        calcButton.Click();

        Assert.That(result.Text, Is.EqualTo("error"));
    }

    [Test]
    public void TestWithInvalidData_num2IsEmpty()
    {
        IWebElement num1 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
        IWebElement num2 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
        IWebElement calcButton = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
        IWebElement result = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

        num1.Clear();
        num1.SendKeys("2");
        num2.Clear();
        calcButton.Click();

        Assert.That(result.Text, Is.EqualTo("error"));
    }

    [TestCase("1", "4", "5")]
    [TestCase("0", "4", "4")]
    [TestCase("-1", "-4", "-5")]
    [TestCase("1", "-4", "-3")]
    [TestCase("0", "0", "0")]
    [TestCase("0.9", "2.56", "3.46")]
    public void TestWithValidData_Paramtarized(string number1, string number2, string expectedResult)
    {
        IWebElement num1 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
        IWebElement num2 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
        IWebElement calcButton = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
        IWebElement result = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

        num1.Clear();
        num1.SendKeys(number1);
        num2.Clear();
        num2.SendKeys(number2);
        calcButton.Click();

        Assert.That(result.Text, Is.EqualTo(expectedResult));
    }
}