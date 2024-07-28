using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace _05_Working_With_Alerts;

public class WorkingWithAlerts
{
    ChromeDriver driver;
    IWebElement resultMessage;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("no-first-run");
        options.AddArgument("no-default-browser-check");

        // Set the user-data-dir to use the pre-configured profile
        options.AddArgument(@"user-data-dir=C:\SeleniumChromeProfile");

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        resultMessage = driver.FindElement(By.Id("result"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void HandlingBasicJavaScriptAlerts()
    {
        IWebElement jsBasicAlert = driver.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
        jsBasicAlert.Click();

        IAlert alert = driver.SwitchTo().Alert();
        Console.WriteLine(alert.GetType());
        Console.WriteLine(alert.Text);

        Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"), "Alert text is wrong");

        alert.Accept();
        Assert.That(resultMessage.Text, Is.EqualTo("You successfully clicked an alert"), "Result message is wrong");
    }

    [Test]
    public void HandlingBasicJavaScriptConfirmAlertsOK()
    {
        IWebElement jsConfirmAlert = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        jsConfirmAlert.Click();

        IAlert alert = driver.SwitchTo().Alert();
        Console.WriteLine(alert.GetType());
        Console.WriteLine(alert.Text);

        Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"), "Alert text is wrong");

        alert.Accept();
        Assert.That(resultMessage.Text, Is.EqualTo("You clicked: Ok"), "Result message is wrong");
    }

    [Test]
    public void HandlingBasicJavaScriptConfirmAlertsCancel()
    {
        IWebElement jsConfirmAlert = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        jsConfirmAlert.Click();

        IAlert alert = driver.SwitchTo().Alert();
        Console.WriteLine(alert.GetType());
        Console.WriteLine(alert.Text);

        Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"), "Alert text is wrong");

        alert.Dismiss();
        Assert.That(resultMessage.Text, Is.EqualTo("You clicked: Cancel"), "Result message is wrong");
    }

    [Test]
    public void HandlingBasicJavaScriptPromptAlertsOK()
    {
        IWebElement jsPromptAlert = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        jsPromptAlert.Click();

        IAlert alert = driver.SwitchTo().Alert();
        Console.WriteLine(alert.GetType());
        Console.WriteLine(alert.Text);

        Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"), "Alert text is wrong");

        alert.SendKeys("hola");
        alert.Accept();
        Assert.That(resultMessage.Text, Is.EqualTo("You entered: hola"), "Result message is wrong");
    }

    [Test]
    public void HandlingBasicJavaScriptPromptAlertsCancel()
    {
        IWebElement jsPromptAlert = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        jsPromptAlert.Click();

        IAlert alert = driver.SwitchTo().Alert();
        Console.WriteLine(alert.GetType());
        Console.WriteLine(alert.Text);

        Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"), "Alert text is wrong");

        alert.SendKeys("none");
        alert.Dismiss();
        Assert.That(resultMessage.Text, Is.EqualTo("You entered: null"), "Result message is wrong");
    }
}