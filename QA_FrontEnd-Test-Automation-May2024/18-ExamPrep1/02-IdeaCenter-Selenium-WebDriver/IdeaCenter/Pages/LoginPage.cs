
using OpenQA.Selenium;

namespace IdeaCenter.Pages;

public class LoginPage : BasePage
{
    private By emailField = By.XPath("//input[@name='Email']");
    private By passwordField = By.XPath("//input[@name='Password']");
    private By signInButton = By.XPath("//button[text()='Sign in']");

    private string url = baseUrl + "/Users/Login";

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public void openPage()
    {
        driver.Navigate().GoToUrl(url);
    }

    public void Login(string email, string password)
    {
        Type(emailField, email);
        Type(passwordField, password);
        Click(signInButton);
    }
}
