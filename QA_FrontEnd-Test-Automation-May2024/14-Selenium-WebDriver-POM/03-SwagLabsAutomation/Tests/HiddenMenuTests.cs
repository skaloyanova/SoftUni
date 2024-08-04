namespace _03_SwagLabsAutomation.Tests;

public class HiddenMenuTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Login("standard_user", "secret_sauce");
    }

    [Test]
    public void TestOpenMenu()
    {
        hiddenMenuPage.ClickMenuButton();
        Assert.That(hiddenMenuPage.IsMenuOpen(), Is.True, "Hidded menu was not opened");
    }

    [Test]
    public void TestLogout()
    {
        hiddenMenuPage.ClickLogoutLink();
        Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"), "Logout was not successful");
    }
}
