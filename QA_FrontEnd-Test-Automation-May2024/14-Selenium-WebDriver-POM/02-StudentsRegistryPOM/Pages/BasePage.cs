using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _02_StudentsRegistryPOM.Pages;

public class BasePage
{
    protected readonly IWebDriver driver;
    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public virtual string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82";

    public IWebElement LinkHomePage => driver.FindElement(By.LinkText("Home"));
    public IWebElement LinkViewStudentsPage => driver.FindElement(By.LinkText("View Students"));
    public IWebElement LinkAddStudentsPage => driver.FindElement(By.LinkText("Add Student"));
    protected IWebElement PageHeading => driver.FindElement(By.TagName("h1"));

    public void OpenPage()
    {
        driver.Navigate().GoToUrl(this.PageUrl);
    }

    public bool IsPageOpen()
    {
        return driver.Url == this.PageUrl;
    }

    public string GetPageTitle()
    {
        return driver.Title;
    }

    public string GetPageHeadingText()
    {
        return PageHeading.Text;
    }
}
