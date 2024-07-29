using OpenQA.Selenium;

namespace _02_StudentsRegistryPOM.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    public override string PageUrl => base.PageUrl + "/";

    protected IWebElement StudentsCount => driver.FindElement(By.XPath("//body/p/b"));

    public int GetStudentsCount()
    {
        return int.Parse(this.StudentsCount.Text);
    }
}
