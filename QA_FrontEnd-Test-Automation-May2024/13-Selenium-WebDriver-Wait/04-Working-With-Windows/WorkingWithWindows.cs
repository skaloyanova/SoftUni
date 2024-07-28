using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace _04_Working_With_Windows;

public class WorkingWithWindows
{
    ChromeDriver driver;
    IWebElement clickHereButton;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("no-first-run");
        options.AddArgument("no-default-browser-check");

        // Set the user-data-dir to use the pre-configured profile
        options.AddArgument(@"user-data-dir=C:\SeleniumChromeProfile");

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        clickHereButton = driver.FindElement(By.XPath("//div[@class='example']/a"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test, Order(1)]
    public void HandlingMultipleWindows()
    {
        // get all windows handles - should be only the opened url
        ReadOnlyCollection<string> handles = driver.WindowHandles;
        Assert.That(handles.Count, Is.EqualTo(1));

        // click to open new window and verify there are 2 handles
        clickHereButton.Click();
        handles = driver.WindowHandles;
        Assert.That(handles.Count, Is.EqualTo(2), "There should be 2 windows opened");

        // verify Titles of the new windows
        Assert.Multiple(() =>
        {
            driver.SwitchTo().Window(handles[0]);
            Assert.That(driver.Title, Is.EqualTo("The Internet"), "Title of the new initial window is not as expected");

            driver.SwitchTo().Window(handles[1]);
            Assert.That(driver.Title, Is.EqualTo("New Window"), "Title of the new window is not as expected");
        });

        // close the new window and verify only the initially opened window is present
        driver.Close();
        handles = driver.WindowHandles;
        Assert.That(handles.Count, Is.EqualTo(1));

        driver.SwitchTo().Window(handles[0]);
        Assert.That(driver.Title, Is.EqualTo("The Internet"), "Title of the new initial window is not as expected");
    }

    [Test, Order(2)]
    public void LogHandlesInFile()
    {
        string targetDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..", @"..", @".."));
        string path = targetDir + "/windowHandles.txt";

        if (File.Exists(path)) File.Delete(path);

        clickHereButton.Click();

        ReadOnlyCollection<string> handles = driver.WindowHandles;
        Assert.That(handles.Count, Is.EqualTo(2), "There should be 2 windows opened");

        driver.SwitchTo().Window(handles[1]);
        File.AppendAllText(path, "Windows handle for new window: " + driver.CurrentWindowHandle + "\n\n");
        File.AppendAllText(path, "Page content: " + driver.PageSource + "\n\n");

        driver.Close();
        driver.SwitchTo().Window(handles[0]);
        File.AppendAllText(path, "Windows handle for original window: " + driver.CurrentWindowHandle + "\n\n");
        File.AppendAllText(path, "Page content: " + driver.PageSource + "\n\n");
    }

    [Test, Order(3)]
    public void HandlingNoSuchWindowException()
    {
        clickHereButton.Click();

        ReadOnlyCollection<string> handles = driver.WindowHandles;

        driver.SwitchTo().Window(handles[1]);

        driver.Close();
        
        /* option 1 */
        Assert.Throws<NoSuchWindowException>(() => driver.SwitchTo().Window(handles[1]));

        /* option 2 */
        try
        {
            driver.SwitchTo().Window(handles[1]);
            Assert.Fail("Second window should be closed");
        }
        catch (NoSuchWindowException ex)
        {
            string targetDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..", @"..", @".."));
            string path = targetDir + "/windowHandles.txt";
            File.AppendAllText(path, "NoSuchWindowException exception is caught: " + ex.Message + "\n\n");

            Assert.Pass("NoSuchWindowException exception received as expected");
        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception is thrown - " + ex.Message);
        }
        finally
        {
            driver.SwitchTo().Window(handles[0]);
        }
    }

    [Test, Order(3)]
    public void PlaySwichingWindows()
    {
        string targetDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..", @"..", @".."));
        string path = targetDir + "/switchingWindows.txt";

        if (File.Exists(path)) File.Delete(path);

        File.AppendAllText(path, "* original window handle: " + driver.CurrentWindowHandle + "\n");

        clickHereButton.Click();

        ReadOnlyCollection<string> handles = driver.WindowHandles;
        File.AppendAllText(path, "* new window opened; handles list: " + string.Join(", ", handles) + "\n");
        File.AppendAllText(path, "* current handle is: " + driver.CurrentWindowHandle + "\n");

        driver.SwitchTo().Window(handles[1]);
        File.AppendAllText(path, "* switched to new window; current handle is: " + driver.CurrentWindowHandle + "\n");

        driver.Close();
        // if we close window, we should switch to another one, else "driver.CurrentWindowHandle" throws NoSuchWindowException : no such window: target window already closed
        //File.AppendAllText(path, "* new window closed; current handle is: " + driver.CurrentWindowHandle + "\n");

        handles = driver.WindowHandles;
        File.AppendAllText(path, "* new window closed; handles list: " + string.Join(", ", handles) + "\n");

        driver.SwitchTo().Window(handles[0]);
        File.AppendAllText(path, "* switched to original window; current handle is: " + driver.CurrentWindowHandle + "\n");
    }
}