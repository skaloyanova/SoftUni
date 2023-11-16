using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    // Regex: ^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$

    [TestCase("hello@abv.bg")]
    [TestCase("st.holla@abc.co.uk")]
    [TestCase("aha.aa_k1d-aa@sadsa.in")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("a@dd")]
    [TestCase("asdas.co.uk")]
    [TestCase("sdasa@asdas@sdasd.com")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
