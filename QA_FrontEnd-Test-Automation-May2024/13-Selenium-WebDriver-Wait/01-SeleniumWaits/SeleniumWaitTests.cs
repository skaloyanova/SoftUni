using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _01_SeleniumWaits;

public class SeleniumWaitTests
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test, Order(1)]
    public void AddBoxWithoutWaitsFails()
    {
        driver.FindElement(By.Id("adder")).Click();

        //IWebElement redBox = driver.FindElement(By.ClassName("redbox"));
        //Assert.That(redBox.Displayed, Is.True);

        Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.ClassName("redbox")));
    }

    [Test, Order(2)]
    public void RevealInputWithoutWaitsFail()
    {
        driver.FindElement(By.Id("reveal")).Click();

        IWebElement inputField = driver.FindElement(By.Id("revealed"));

        //inputField.SendKeys("some text");
        //Assert.That(inputField.GetAttribute("value"), Is.EqualTo("some text"));

        Assert.Throws<ElementNotInteractableException>(() => inputField.SendKeys("some text"));
    }

    [Test, Order(3)]
    public void AddBoxWithThreadSleep()
    {
        driver.FindElement(By.Id("adder")).Click();

        Thread.Sleep(3000);

        IWebElement box = driver.FindElement(By.ClassName("redbox"));

        Assert.That(box.Displayed, Is.True);
    }

    [Test, Order(4)]
    public void AddBoxWithImplicitWait()
    {
        driver.FindElement(By.Id("adder")).Click();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        IWebElement box = driver.FindElement(By.ClassName("redbox"));

        Assert.That(box.Displayed, Is.True);
    }

    [Test, Order(5)]
    public void RevealInputWithImplicitWaits()
    {
        driver.FindElement(By.Id("reveal")).Click();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        IWebElement inputField = driver.FindElement(By.Id("revealed"));

        inputField.SendKeys("some text");

        Assert.That(inputField.GetAttribute("value"), Is.EqualTo("some text"));
        Assert.That(inputField.TagName, Is.EqualTo("input"));
    }

    [Test, Order(6)]
    public void RevealInputWithExplicitWaits()
    {
        driver.FindElement(By.Id("reveal")).Click();

        IWebElement inputField = driver.FindElement(By.Id("revealed"));

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("revealed")));
        wait.Until(e => inputField.Displayed);

        inputField.SendKeys("some text");

        Assert.That(inputField.GetAttribute("value"), Is.EqualTo("some text"));
    }

    [Test, Order(7)]
    public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
    {
        driver.FindElement(By.Id("adder")).Click();

        DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
        wait.Timeout = TimeSpan.FromSeconds(10);
        wait.PollingInterval = TimeSpan.FromMilliseconds(500);
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        IWebElement redBox = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("redbox")));

        Assert.That(redBox.Displayed, Is.True);
    }

    [Test, Order(8)]
    public void RevealInputWithCustomFluentWait()
    {
        driver.FindElement(By.Id("reveal")).Click();

        DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
        wait.Timeout = TimeSpan.FromSeconds(5);
        wait.PollingInterval = TimeSpan.FromMilliseconds(200);
        wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

        IWebElement inputField = driver.FindElement(By.Id("revealed"));

        wait.Until(e =>
        {
            inputField.SendKeys("some text");
            return true;
        });

        Assert.That(inputField.TagName, Is.EqualTo("input"));
        Assert.That(inputField.GetAttribute("value"), Is.EqualTo("some text"));
    }

}