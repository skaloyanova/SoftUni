using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace RevueCrafters.Pages;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string PageUrl => base.PageUrl + "/Users/Login";

    protected IWebElement EmailField => driver.FindElement(By.XPath("//input[@name='Email']"));
    protected IWebElement PasswordField => driver.FindElement(By.XPath("//input[@name='Password']"));
    protected IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(text(),'Log In')]"));
    protected IWebElement FormElement => driver.FindElement(By.Id("loginForm"));

    public override void OpenPage()
    {
        base.OpenPage();
        actions.ScrollToElement(FormElement).Perform();
    }

    public void Login(string email, string password, string username)
    {
        Type(EmailField, email);
        Type(PasswordField, password);
        LoginButton.Click();

        Assert.That(new HomePage(driver).GetGreetingMessage(), Is.EqualTo($"Dear, {username}"));
    }
}
