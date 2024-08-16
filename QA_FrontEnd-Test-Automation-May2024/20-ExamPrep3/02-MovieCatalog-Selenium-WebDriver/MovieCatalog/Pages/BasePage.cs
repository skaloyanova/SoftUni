using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace MovieCatalog.Pages;

public class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    protected virtual string PageUrl => "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com";

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void OpenPage()
    {
        driver.Navigate().GoToUrl(PageUrl);
        Assert.That(IsPageOpen());
    }

    public virtual bool IsPageOpen()
    {
        return driver.Url == PageUrl;
    }

    public IWebElement FindElement(By by)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(by));
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return driver.FindElements(by);
    }

    public void Type(IWebElement element, string text)
    {
        element.Clear();
        element.SendKeys(text);
    }
}
