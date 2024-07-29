using OpenQA.Selenium;

namespace _03_SwagLabsAutomation.Pages;

public class InventoryPage : BasePage
{
    private readonly By cartLink = By.CssSelector(".shopping_cart_link");
    private readonly By pageHeading = By.ClassName("title");
    private readonly By inventoryItems = By.CssSelector(".inventory_item");

    public InventoryPage(IWebDriver driver) : base(driver)
    {
    }

    public void AddToCartByIndex(int index)
    {
        //var itemAddToCartButton = By.CssSelector($".inventory_item:nth-child({index}) .btn_inventory");
        var itemAddToCartButton = By.XPath($"//div[@class='inventory_item'][{index}]//button");
        Click(itemAddToCartButton);
    }

    public void AddToCartByName(string name)
    {
        var itemAddToCartButton = By.XPath($"//div[text()='{name}']/ancestor::div[@class='inventory_item']//button[contains(@class, 'btn_inventory')]");
        Click(itemAddToCartButton);
    }

    public void ClickCartLink()
    {
        Click(cartLink);
    }

    public bool IsInventoryDisplayed()
    {
        return FindAllElements(inventoryItems).Count > 0;
    }

    public bool IsPageLoaded()
    {
        return driver.Url.Contains("inventory.html") && GetText(pageHeading) == "Products";
    }
}
