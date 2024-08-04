namespace _03_SwagLabsAutomation.Tests;

public class InventoryTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Login("standard_user", "secret_sauce");
    }

    [TearDown]
    public void Teardown()
    {
        hiddenMenuPage.ClickResetAppStateLink();
    }


    [Test]
    public void TestInventoryDisplay()
    {
        Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True, "Inventory page has no items displayed");
    }

    [Test]
    public void TestAddToCartByIndex()
    {
        inventoryPage.AddToCartByIndex(4);
        inventoryPage.ClickCartLink();
        Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "Cart is empty");
        Assert.That(cartPage.IsProductInCart("Sauce Labs Fleece Jacket"), "Product is missing in the cart");
    }

    [Test]
    public void TestAddToCartByName()
    {
        string productName = "Sauce Labs Bike Light";
        
        inventoryPage.AddToCartByName(productName);
        inventoryPage.ClickCartLink();
        Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "Cart is empty");
        Assert.That(cartPage.IsProductInCart(productName), "Product is missing in the cart");
    }

    [Test]
    public void TestPageTitle()
    {
        Assert.That(inventoryPage.IsPageLoaded(), Is.True);
    }
}
