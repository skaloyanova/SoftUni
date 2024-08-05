using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace _03_Scroll;

public class ScrollTests
{
    private AndroidDriver _driver;
    private AppiumLocalService _localService;

    [OneTimeSetUp]
    public void Setup()
    {
        _localService = new AppiumServiceBuilder()
            .WithIPAddress("127.0.0.1")
            .UsingPort(4723)
            .Build();
        _localService.Start();

        AppiumOptions options = new AppiumOptions()
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            App = @"D:\_Coding\SoftUni\QA_FrontEnd-Test-Automation-May2024\15-Appium\ApiDemos-debug.apk",
        };
        _driver = new AndroidDriver(_localService, options);

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _localService.Dispose();
    }

    [Test]
    public void ScrollTest()
    {
        // Tap on "Views"
        var viewsButton = _driver.FindElement(MobileBy.AccessibilityId("Views"));
        viewsButton.Click();

        // Scroll until "Lists" is found
        ScrollToText("Lists");

        // Tap on "Lists"
        var listsButton = _driver.FindElement(MobileBy.AccessibilityId("Lists"));
        Assert.That(listsButton, Is.Not.Null, "'Lists' element is not found after scrolling");

        listsButton.Click();

        // Verify that expected element ("10. Single choice list") is found in the resulting view.
        var elementInList = _driver.FindElement(MobileBy.AccessibilityId("10. Single choice list"));
        Assert.That(elementInList, Is.Not.Null, "Element '10. Single choice list' is not found in the list");
    }

    // Helper methods
    private void ScrollToText(string text)
    {
        _driver.FindElement(MobileBy.AndroidUIAutomator(
            $"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"{text}\"))"));
    }
}