using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace _03_SwagLabsAutomation.Pages;

public class CartPage : BasePage
{
    private readonly By cartItem = By.ClassName("cart_item");
    private readonly By checkoutButton = By.Id("checkout");

    public CartPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsCartItemDisplayed()
    {
        return FindAllElements(cartItem).Any();
    }

    public void ClickCheckout()
    {
        Click(checkoutButton);
    }

    // Additional methods below
    public bool IsPageLoaded()
    {
        return driver.Url.Contains("cart.html");
    }

    public ReadOnlyCollection<IWebElement> getCartItems()
    {
        return FindAllElements(cartItem);
    }

    public bool IsProductInCart(string productName)
    {
        Assert.That(IsPageLoaded(), "Cart page is not loaded");
        var cartItems = getCartItems().Select(i => i.Text).ToList();
        Console.WriteLine(String.Join(", ", cartItems));
        return cartItems.Any(e => e.Contains(productName));
    }
}
