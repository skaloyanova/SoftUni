namespace _03_SwagLabsAutomation.Tests;

public class CartTests : BaseTest
{
    string productName;

    [SetUp]
    public void Setup()
    {
        Login("standard_user", "secret_sauce");
        productName = "Sauce Labs Bike Light";
        inventoryPage.AddToCartByName(productName);
        inventoryPage.ClickCartLink();
    }

    [TearDown]
    public void Teardown()
    {
        hiddenMenuPage.ClickResetAppStateLink();
    }

    [Test]
    public void TestCartItemDisplayed()
    {
        Assert.That(cartPage.IsPageLoaded, Is.True, "Cart Page is not loaded");
        Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "Cart is empty, but should contain 1 product");
        Assert.That(cartPage.IsProductInCart(productName), "Product is missing in the cart");
    }

    [Test]
    public void TestClickCheckout()
    {
        cartPage.ClickCheckout();
        Assert.That(checkoutPage.IsPageLoadedFirstScreen(), "Checkout page is not loaded");
    }

}
