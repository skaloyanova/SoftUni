using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace _07_Zoom;

public class ZoomTests
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

    [Test, Order(1)]
    public void ZoomInTest()
    {
        // Tap on Views
        _driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

        // Scroll down to Seek Bar Option
        ScrollToText("WebView");

        // Tap on Seek Bar Option
        _driver.FindElement(MobileBy.AccessibilityId("WebView")).Click();

        // Perform zoom in action
        PerformZoom(400, 400, 200, 400, 600, 400, 800, 400);
    }

    [Test, Order(2)]
    public void ZoomOutTest()
    {
        // Perform zoom out action
        PerformZoom(200, 400, 400, 400, 800, 400, 600, 400);
    }

    private void ScrollToText(string text)
    {
        _driver.FindElement(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"{text}\"))"));
    }

    private void PerformZoom(int startX1, int startY1, int endX1, int endY1, int startX2, int startY2, int endX2, int endY2)
    {
        var finger1 = new PointerInputDevice(PointerKind.Touch);
        var finger2 = new PointerInputDevice(PointerKind.Touch);

        var zoomFinger1 = new ActionSequence(finger1);
        zoomFinger1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startX1, startY1, TimeSpan.Zero));
        zoomFinger1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
        zoomFinger1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endX1, endY1, TimeSpan.FromMilliseconds(1500)));
        zoomFinger1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

        var zoomFinger2 = new ActionSequence(finger2);
        zoomFinger2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startX2, startY2, TimeSpan.Zero));
        zoomFinger2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
        zoomFinger2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endX2, endY2, TimeSpan.FromMilliseconds(1500)));
        zoomFinger2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

        _driver.PerformActions(new List<ActionSequence> { zoomFinger1, zoomFinger2 });
    }
}