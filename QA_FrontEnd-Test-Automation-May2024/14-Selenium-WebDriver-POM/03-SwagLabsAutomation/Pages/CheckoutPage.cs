using OpenQA.Selenium;

namespace _03_SwagLabsAutomation.Pages;

public class CheckoutPage : BasePage
{
    private readonly By firstNameField = By.XPath("//form//div[@class='checkout_info']//input[@id='first-name']");
    private readonly By lastNameField = By.XPath("//form//div[@class='checkout_info']//input[@id='last-name']");
    private readonly By postalCodeField = By.XPath("//form//div[@class='checkout_info']//input[@id='postal-code']");
    private readonly By continueButton = By.XPath("//input[@id='continue']");
    private readonly By finishButton = By.XPath("//button[@id='finish']");
    private readonly By completeHeader = By.ClassName("complete-header");

    public CheckoutPage(IWebDriver driver) : base(driver)
    {
    }

    public void EnterFirstName(string firstName)
    {
        Type(firstNameField, firstName);
    }

    public void EnterLastName(string lastName)
    {
        Type(lastNameField, lastName);
    }

    public void EnterPostalCode(string postalCode)
    {
        Type(postalCodeField, postalCode);
    }

    public void ClickContinue()
    {
        Click(continueButton);
    }

    public void ClickFinish()
    {
        Click(finishButton);
    }

    public bool IsPageLoadedFirstScreen()
    {
        return driver.Url.Contains("checkout-step-one.html");
    }

    public bool IsPageLoadedSecondScreen()
    {
        return driver.Url.Contains("checkout-step-two.html");
    }

    public bool IsCheckoutComplete()
    {
        return GetText(completeHeader) == "Thank you for your order!";
    }
}
