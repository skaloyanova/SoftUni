using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace IdeaCenter.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        protected WebDriverWait wait;
        protected static readonly string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";

        protected By loginButton = By.XPath("//a[contains(text(),'Login')]");
        protected By homeLink = By.ClassName("rounded-circle");
        protected By myProfileLink = By.XPath("//a[text()='My Profile']");
        protected By myIdeasLink = By.XPath("//a[text()='My Ideas']");
        protected By createIdeaLink = By.XPath("//a[text()='Create Idea']");
        protected By logoutButton = By.XPath("//a[contains(text(),'Logout')]");

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement FindElement(By by)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        protected ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return this.driver.FindElements(by);
        }

        protected void Click(By by)
        {
            FindElement(by).Click();
        }

        protected void Type(By by, string text)
        {
            var element = FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        public void openHomePage()
        {
            this.driver.Navigate().GoToUrl(baseUrl);
        }

        public void ClickLoginButton()
        {
            Click(loginButton);
        }

        public void ClickMyProfileLink()
        {
            Click(myProfileLink);
        }

        public void ClickMyIdeasLink()
        {
            Click(myIdeasLink);
        }

        public void ClickCreateIdeaLink()
        {
            Click(createIdeaLink);
        }

        public void ClickLogoutButton()
        {
            Click(logoutButton);
        }
    }
}
