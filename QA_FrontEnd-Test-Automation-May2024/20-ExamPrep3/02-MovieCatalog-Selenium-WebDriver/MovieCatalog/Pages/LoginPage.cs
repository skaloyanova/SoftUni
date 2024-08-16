using OpenQA.Selenium;

namespace MovieCatalog.Pages;

public class LoginPage : BasePage
{
    protected override string PageUrl => base.PageUrl + "/User/Login";

    protected IWebElement EmailField => FindElement(By.XPath("//input[@name='Email']"));
    protected IWebElement PasswordField => FindElement(By.XPath("//input[@name='Password']"));
    protected IWebElement LoginButton => FindElement(By.XPath("//button[text()='Login']"));

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public void Login(string email, string password)
    {
        OpenPage();
        Type(EmailField, email);
        Type(PasswordField, password);
        LoginButton.Click();
    }
}
