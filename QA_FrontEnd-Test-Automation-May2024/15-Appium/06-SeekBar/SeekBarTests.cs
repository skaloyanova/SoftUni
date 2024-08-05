using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace _06_SeekBar;

public class SeekBarTests
{
    private AppiumLocalService _LocalService;
    private AndroidDriver _driver;

    [OneTimeSetUp]
    public void Setup()
    {
        _LocalService = new AppiumServiceBuilder()
            .WithIPAddress("127.0.0.1")
            .UsingPort(4723)
            .Build();
        _LocalService.Start();

        AppiumOptions options = new AppiumOptions()
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            App = @"D:\_Coding\SoftUni\QA_FrontEnd-Test-Automation-May2024\15-Appium\ApiDemos-debug.apk",
        };

        _driver = new AndroidDriver(_LocalService, options);

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _LocalService?.Dispose();
    }

    [Test]
    public void SlideTest()
    {
        // Tap on Views
        _driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

        // Scroll down to Seek Bar Option
        ScrollToText("Seek Bar");

        // Tap on Seek Bar Option
        _driver.FindElement(MobileBy.AccessibilityId("Seek Bar")).Click();

        // Move Seek Bar with Inspector's Coordinates.
        MoveSeekBarWithInspectorCoordinates(542, 235, 1036, 235);

        // Find the element displaying the slider position text and assert that it shows the expected value.
        var resultMessage = _driver.FindElement(MobileBy.Id("progress"));
        Assert.That(resultMessage.Text, Is.EqualTo("100 from touch=true"), "Seek bar did not move to the expected value");
    }

    private void ScrollToText(string text)
    {
        _driver.FindElement(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"{text}\"))"));
    }

    private void MoveSeekBarWithInspectorCoordinates(int startX, int startY, int endX, int endY)
    {
        var finger = new PointerInputDevice(PointerKind.Touch);

        var swipe = new ActionSequence(finger);

        swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, startY, TimeSpan.Zero));
        swipe.AddAction(finger.CreatePointerDown(MouseButton.Left));
        swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, endX, endY, TimeSpan.FromSeconds(1)));
        swipe.AddAction(finger.CreatePointerUp(MouseButton.Left));

        _driver.PerformActions(new List<ActionSequence> { swipe });
    }
}