using OpenQA.Selenium;

namespace MovieCatalog.Pages;

public class MainPage : BasePage
{
    protected override string PageUrl => base.PageUrl + "/Main";

    public MainPage(IWebDriver driver) : base(driver)
    {
    }
}
