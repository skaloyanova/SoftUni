using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace RevueCrafters.Pages;

public class BasePage
{ 
    protected readonly IWebDriver driver;
    protected Actions actions;
    protected virtual string PageUrl => "https://d3s5nxhwblsjbi.cloudfront.net";

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        actions = new Actions(driver);
    }

    //protected IWebElement RegisterLink => driver.FindElement(By.XPath("//div[@id='navbarSupportedContent']//a[text()='Register']"));
    //protected IWebElement LoginLink => driver.FindElement(By.XPath("//div[@id='navbarSupportedContent']//a[text()='Login']"));
    //protected IWebElement MyRevuesLink => driver.FindElement(By.XPath("//div[@id='navbarSupportedContent']//a[text()='My Revues']"));
    //protected IWebElement CreateRevuesLink => driver.FindElement(By.XPath("//div[@id='navbarSupportedContent']//a[text()='Create Revue']"));
    //protected IWebElement ProfileLink => driver.FindElement(By.XPath("//div[@id='navbarSupportedContent']//a[text()='Profile']"));
    //protected IWebElement LogoutLink => driver.FindElement(By.XPath("//div[@id='navbarSupportedContent']//a[text()='Logout']"));

    public void Type(IWebElement element, string text)
    {
        element.Clear();
        element.SendKeys(text);
    }

    public virtual void OpenPage()
    {
        driver.Navigate().GoToUrl(PageUrl);
    }

    public bool IsPageOpen()
    {
        return driver.Url == PageUrl;
    }
}
