using NUnit.Framework;

namespace TestApp.UnitTests;

public class StringReverseTests
{
    // TODO: finish test
    [Test]
    public void Test_Reverse_WhenGivenEmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";  // "" <=> string.Empty

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual(string.Empty, actual);
    }

    [Test]
    public void Test_Reverse_WhenGivenSingleCharacterString_ReturnsSameCharacter()
    {
        // Arrange
        string input = "s";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual("s", actual);
        Assert.AreEqual(1, actual.Length);
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalString_ReturnsReversedString()
    {
        // Arrange
        string input = "stun";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual("nuts", actual);
        Assert.AreEqual(input.Length, actual.Length);
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalStringWithMixedLetterCase_ReturnsReversedString()
    {
        // Arrange
        string input = "sTun!";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual("!nuTs", actual);
        Assert.AreEqual(input.Length, actual.Length);
    }
}
