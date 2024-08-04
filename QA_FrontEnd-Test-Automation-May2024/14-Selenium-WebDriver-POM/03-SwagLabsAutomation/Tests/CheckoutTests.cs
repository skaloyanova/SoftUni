namespace _03_SwagLabsAutomation.Tests;

public class CheckoutTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Login("standard_user", "secret_sauce");
        inventoryPage.AddToCartByIndex(1);
        inventoryPage.ClickCartLink();
        cartPage.ClickCheckout();
    }

    [TearDown]
    public void Teardown()
    {
        hiddenMenuPage.ClickResetAppStateLink();
    }

    [Test]
    public void TestCheckoutPageLoaded()
    {
        Assert.That(checkoutPage.IsPageLoadedFirstScreen(), "Checkout page is not loaded");
    }

    [Test]
    public void TestContinueToNextStep()
    {
        checkoutPage.EnterFirstName("Ali");
        checkoutPage.EnterLastName("Baba");
        checkoutPage.EnterPostalCode("1000");
        checkoutPage.ClickContinue();

        Assert.That(checkoutPage.IsPageLoadedSecondScreen(), "Checkout overview is not loaded");
    }

    [Test]
    public void TestCompleteOrder()
    {
        checkoutPage.EnterFirstName("Ali");
        checkoutPage.EnterLastName("Baba");
        checkoutPage.EnterPostalCode("1000");
        checkoutPage.ClickContinue();
        Assert.That(checkoutPage.IsPageLoadedSecondScreen(), "Checkout overview is not loaded");
        checkoutPage.ClickFinish();

        Assert.That(checkoutPage.IsCheckoutComplete(), Is.True, "Checkout is not finished");
    }
}
