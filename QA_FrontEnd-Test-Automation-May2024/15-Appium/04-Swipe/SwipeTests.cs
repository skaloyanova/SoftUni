using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace _04_Swipe;

public class SwipeTests
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
    public void SwipeTest()
    {
        // Tap on Views
        _driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

        // Tap on Gallery
        _driver.FindElement(MobileBy.AccessibilityId("Gallery")).Click();

        // Tap on Photos
        _driver.FindElement(MobileBy.AccessibilityId("1. Photos")).Click();

        // Locate first image in the gallery
        var image1 = _driver.FindElements(By.ClassName("android.widget.ImageView"))[0];

        // Swipe Left with 200 pixels to see the third picture
        Actions action = new Actions(_driver);
        var swipe = action.ClickAndHold(image1)
                            .MoveByOffset(-200, 0)
                            .Release()
                            .Build();

        swipe.Perform();

        // Assert the third picture is visible
        var image3 = _driver.FindElements(By.ClassName("android.widget.ImageView"))[2];
        Assert.That(image3, Is.Not.EqualTo(null), "Third picture not found after swiping.");
    }
}