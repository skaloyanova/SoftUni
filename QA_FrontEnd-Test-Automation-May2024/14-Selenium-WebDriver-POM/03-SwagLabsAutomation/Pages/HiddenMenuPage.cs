using OpenQA.Selenium;

namespace _03_SwagLabsAutomation.Pages;

public class HiddenMenuPage : BasePage
{
    private readonly By hamburgerMenu = By.XPath("//button[@id='react-burger-menu-btn']");
    private readonly By menuAllItems = By.LinkText("All Items");
    private readonly By menuLogout = By.LinkText("Logout");
    private readonly By menuResetAppState = By.LinkText("Reset App State");

    public HiddenMenuPage(IWebDriver driver) : base(driver)
    {
    }

    public void ClickMenuButton()
    {
        Click(hamburgerMenu);
    }
    public void ClickLogoutLink()
    {
        ClickMenuButton();
        Click(menuLogout);
    }

    public bool IsMenuOpen()
    {
        return FindSingleElement(menuLogout).Displayed;
    }

    // Additional methods
    public void ClickAllItemsLink()
    {
        ClickMenuButton();
        Click(menuAllItems);
    }

    public void ClickResetAppStateLink()
    {
        ClickMenuButton();
        Click(menuResetAppState);
    }
}
