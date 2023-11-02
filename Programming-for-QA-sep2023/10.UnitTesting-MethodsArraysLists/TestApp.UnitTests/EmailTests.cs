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

    [TestCase("aaa.com")]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("asd d@gmail.com")]   //no spaces are allowed in an e-mail address
    [TestCase("asdd@gmail@com")]
    public void Test_IsValidEmail_InvalidEmail(string input)
    {
        bool result = Email.IsValidEmail(input);

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
