using _03_SwagLabsAutomation.Pages;

namespace _03_SwagLabsAutomation.Tests;

public class InventoryTests : BaseTest
{
    [Test]
    public void TestInventoryDisplay()
    {
        Login("standard_user", "secret_sauce");
        var inventoryPage = new InventoryPage(driver);
        Assert.That(inventoryPage.IsInventoryDisplayed, Is.True);
    }

    public void TestAddToCartByIndex()
    {
        Login("standard_user", "secret_sauce");
        var inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartByIndex(1);
    }

    public void TestAddToCartByName()
    {
        Login("standard_user", "secret_sauce");
        var inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartByName("Sauce Labs Bike Light");
    }

    public void TestPageTitle()
    {
        Login("standard_user", "secret_sauce");
        var inventoryPage = new InventoryPage(driver);
        Assert.That(inventoryPage.IsPageLoaded(), Is.True);
    }
}
