using OpenQA.Selenium;

namespace RevueCrafters.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    protected IWebElement GreetingElement => driver.FindElement(By.XPath("//div[@class='col-md-6 gx-5 mb-4']//h4"));

    public string GetGreetingMessage()
    {
        return GreetingElement.Text;
    }
}
