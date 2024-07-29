using OpenQA.Selenium;

namespace _03_SwagLabsAutomation.Pages;

public class LoginPage : BasePage
{
    private readonly By usernameField = By.Id("user-name");
    private readonly By passwordField = By.Id("password");
    private readonly By loginBtn = By.Id("login-button");
    private readonly By errorMessage = By.XPath("//form/div[@class='error-message-container error']/h3");
    private readonly By pageHeading = By.CssSelector(".login_container .login_logo");

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public void InputUsername(string username)
    {
        Type(usernameField, username);
    }

    public void InputPassword(string password)
    {
        Type(passwordField, password);
    }

    public void ClickLoginButton()
    {
        Click(loginBtn);
    }

    public string GetErrorMessage()
    {
        return GetText(errorMessage);
    }

    public string GetPageHeading()
    {
        return GetText(pageHeading);
    }

    public void LoginUser( string username, string password)
    {
        Type(usernameField, username);
        Type(passwordField, password);
        ClickLoginButton();
    }
}
