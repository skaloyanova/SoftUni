using OpenQA.Selenium;

namespace _03_SwagLabsAutomation.Pages;

public class CartPage : BasePage
{
    private readonly By cartItem = By.ClassName(".cart_item");
    private readonly By checkoutButton = By.Id("checkout");

    public CartPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsCartItemDisplayed()
    {
        return FindAllElements(cartItem).Count() > 0;
    }

    public void ClickCheckout()
    {
        Click(checkoutButton);
    }
}
