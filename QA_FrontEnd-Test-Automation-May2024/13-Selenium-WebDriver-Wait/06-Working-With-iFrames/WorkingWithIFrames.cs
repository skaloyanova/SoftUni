using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _06_Working_With_iFrames;

public class WorkingWithIFrames
{
    ChromeDriver driver;
    WebDriverWait wait;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("no-first-run");
        options.AddArgument("no-default-browser-check");

        // Set the user-data-dir to use the pre-configured profile
        options.AddArgument(@"user-data-dir=C:\SeleniumChromeProfile");

        driver = new ChromeDriver(options);
        //driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
        driver.Navigate().GoToUrl("https://parcelsapp.com/en/tracking/1ZB8B6650310554157");

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void HandlingIFrames_By_Index()
    {
        // wait until iframe is available and switch to it by finding the first iframe
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

        // click dropdown button
        IWebElement dropdownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
        dropdownButton.Click();

        // select the links in the dropdown list
        var links = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

        foreach (var link in links)
        {
            Console.WriteLine(link.Text);
            Assert.That(link.Displayed, Is.True, "Link in the dropdown menu is not visible");
        }

        driver.SwitchTo().DefaultContent();
    }

    [Test]
    public void HandlingIFrames_By_ID()
    {
        // wait until iframe is available and switch to it by finding the ID
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));

        // click dropdown button
        IWebElement dropdownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
        dropdownButton.Click();

        // select the links in the dropdown list
        var links = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

        foreach (var link in links)
        {
            Console.WriteLine(link.Text);
            Assert.That(link.Displayed, Is.True, "Link in the dropdown menu is not visible");
        }

        driver.SwitchTo().DefaultContent();
    }

    [Test]
    public void HandlingIFrames_By_WebElement()
    {
        // wait until iframe is available by finding the WebElement and switch to it
        IWebElement iframElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#result")));
        driver.SwitchTo().Frame(iframElement);

        // click dropdown button
        IWebElement dropdownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
        dropdownButton.Click();

        // select the links in the dropdown list
        var links = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

        foreach (var link in links)
        {
            Console.WriteLine(link.Text);
            Assert.That(link.Displayed, Is.True, "Link in the dropdown menu is not visible");
        }

        driver.SwitchTo().DefaultContent();
    }
}