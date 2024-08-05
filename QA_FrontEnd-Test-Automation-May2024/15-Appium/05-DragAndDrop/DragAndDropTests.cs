using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;

namespace _05_DragAndDrop;

public class DragAndDropTests
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
    public void DragAndDropTest()
    {
        // tap 'Views'
        _driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

        // tap 'Drag and Drop'
        _driver.FindElement(MobileBy.AccessibilityId("Drag and Drop")).Click();

        // locate dot1 and dot2
        var dot1 = _driver.FindElement(By.Id("drag_dot_1"));
        var dot2 = _driver.FindElement(By.Id("drag_dot_2"));

        // drag and drop dot1 over dot2, using JavaScript method
        var scriptArgs = new Dictionary<string, object>
        {
            { "elementId", dot1.Id },
            { "endX", dot2.Location.X + (dot2.Size.Width / 2) },
            { "endY", dot2.Location.Y + (dot2.Size.Height / 2) },
            { "speed", 2500 }
        };

        _driver.ExecuteScript("mobile: dragGesture", scriptArgs);

        // Verify result message
        var result = _driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_result_text"));
        Assert.That(result.Text, Is.EqualTo("Dropped!"), "Drag and Drop action was not sucessful");
    }
}