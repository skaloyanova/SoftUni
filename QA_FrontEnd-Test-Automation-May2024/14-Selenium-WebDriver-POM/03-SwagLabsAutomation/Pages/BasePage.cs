using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace _03_SwagLabsAutomation.Pages;

public class BasePage
{
    protected readonly IWebDriver driver;
    protected WebDriverWait wait;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));        
    }

    protected IWebElement FindSingleElement(By by)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(by));
    }

    protected ReadOnlyCollection<IWebElement> FindAllElements(By by)
    {
        return driver.FindElements(by);
    }

    protected void Click(By by)
    {
        FindSingleElement(by).Click();
    }

    protected void Type(By by, string text)
    {
        var element = FindSingleElement(by);
        element.Clear();
        element.SendKeys(text);
    }

    protected string GetText(By by)
    {
        return FindSingleElement(by).Text;
    }
}
