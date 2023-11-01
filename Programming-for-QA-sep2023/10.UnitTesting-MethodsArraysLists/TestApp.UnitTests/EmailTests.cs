using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailTests
{
    [Test]
    public void Test_IsValidEmail_ValidEmail()
    {
        // Arrange
        string validEmail = "test@example.com";

        // Act
        bool result = Email.IsValidEmail(validEmail);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_IsValidEmail_InvalidEmail()
    {
        string invalidEmail = "aaa.com";

        bool result = Email.IsValidEmail(invalidEmail);

        Assert.That(result, Is.False);

    }

    [Test]
    public void Test_IsValidEmail_NullInput()
    {
        string? nullEmail = null;

        bool result = Email.IsValidEmail(nullEmail);

        Assert.That(result, Is.False);
    }
}
