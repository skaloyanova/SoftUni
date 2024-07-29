using _03_SwagLabsAutomation.Pages;

namespace _03_SwagLabsAutomation.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public void TestLoginWithValidCredentials()
    {
        Login("standard_user", "secret_sauce");

        Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
    }

    [Test]
    public void TestLoginWithInvalidCredentials()
    {
        Login("standard_user", "invalid-pass");

        Assert.That(new LoginPage(driver).GetErrorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
    }

    [Test]
    public void TestLoginWithLockedOutUser()
    {
        Login("locked_out_user", "secret_sauce");

        Assert.That(new LoginPage(driver).GetErrorMessage, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }
}
