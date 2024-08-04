namespace _03_SwagLabsAutomation.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public void TestLoginWithValidCredentials()
    {
        Login("standard_user", "secret_sauce");
        Assert.That(inventoryPage.IsPageLoaded(), Is.True, "Inventory page is not loaded after sucessful login");
    }

    [Test]
    public void TestLoginWithInvalidCredentials()
    {
        Login("standard_user", "invalid_pass");
        Assert.That(loginPage.GetErrorMessage().Contains("Username and password do not match any user in this service"), "Error message is not correct");
    }

    [Test]
    public void TestLoginWithLockedOutUser()
    {
        Login("locked_out_user", "secret_sauce");
        Assert.That(loginPage.GetErrorMessage().Contains("Sorry, this user has been locked out"));
    }
}
