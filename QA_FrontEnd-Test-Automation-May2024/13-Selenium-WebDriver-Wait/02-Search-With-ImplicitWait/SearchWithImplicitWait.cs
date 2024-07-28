using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace _02_Search_With_ImplicitWait;

public class SearchWithImplicitWait
{
    IWebDriver driver;
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
        driver.Quit();
        driver.Dispose();
    }

    // Implement a test method to search for the product "keyboard".
    // Verify the result using assertions to ensure the product is found and added to the cart.

    [Test]
    public void Search_keyboard_ShouldBeAddedToCart()
    {
        searchBox.SendKeys("keyboard" + Keys.Enter);

        try
        {
            driver.FindElement(By.LinkText("Buy Now")).Click();
            Assert.That(driver.PageSource.Contains("keyboard"), Is.True, "Product keyboard should be present in the cart");
            Console.WriteLine("Success");

        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception: " + ex.Message);            
        }
    }

    // Implement a test method to search for a non-existing product "junk".
    // The implicit wait will still apply, but since the product doesn't exist, the test should handle the No Such Element Exception.
    // Use assertions to verify that the correct exception is thrown.

    [Test]
    public void Search_junk_ShouldThrowNoSuchElementException()
    {
        searchBox.SendKeys("junk" + Keys.Enter);
        Assert.That(driver.PageSource.Contains("There is no product that matches the search criteria."));

        /* var 1 */
        //Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.LinkText("Buy Now")));

        /* var 2 */
        try
        {
            driver.FindElement(By.LinkText("Buy Now")).Click();
        }
        catch (NoSuchElementException ex)
        {
            Assert.Pass("NoSuchElementException is thrown as expected");
            Console.WriteLine("Timeout due to " + ex.Message);
        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception: " + ex.Message);
        }
    }
}