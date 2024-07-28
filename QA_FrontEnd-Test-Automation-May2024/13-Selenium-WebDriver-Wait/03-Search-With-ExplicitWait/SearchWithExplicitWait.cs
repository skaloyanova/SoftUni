using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _03_Search_With_ExplicitWait;

public class SearchWithExplicitWait
{
    ChromeDriver driver;
    IWebElement searchBox;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl("http://practice.bpbonline.com/");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        searchBox = driver.FindElement(By.XPath("//form[@name='quick_find']//input[@name='keywords']"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Close();
    }

    /*
     * Implement a test method to search for the product "keyboard".
     * Set the implicit wait to zero before using explicit wait
     * Set explicit wait for the "Buy Now" button to appear
     * Use assertions to verify that the product is found and can be added to the cart.
     */

    [Test]
    public void Search_keyboard_ShouldBeAddedToCart()
    {
        searchBox.SendKeys("keyboard" + Keys.Enter);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Buy Now"))).Click();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        Assert.That(driver.PageSource.Contains("keyboard"), Is.True, "Product keyboard should be present in the cart");
        Console.WriteLine("Success");
    }


    /*
     * Implement a test method to search for a non-existing product "junk".
     * Set the implicit wait to zero before using explicit wait.
     * Set explicit wait for the "Buy Now" button, which will not appear, leading to a TimeoutException.
     * Use assertions to verify that the correct exception is thrown.
     */

    [Test]
    public void Search_junk_ShouldThrowNoSuchElementException()
    {
        searchBox.SendKeys("junk" + Keys.Enter);

        Assert.That(driver.PageSource.Contains("There is no product that matches the search criteria."));

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

        try
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(a => a.FindElement(By.LinkText("Buy Now")));

            Assert.Fail("'Buy Now' button found on the page");

        } catch (WebDriverTimeoutException)
        {
            Assert.Pass("'WebDriverTimeoutException' thrown as expected");
        } catch (Exception ex)
        {
            Assert.Fail("Unexpected exception - " + ex.Message);
        } finally
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}