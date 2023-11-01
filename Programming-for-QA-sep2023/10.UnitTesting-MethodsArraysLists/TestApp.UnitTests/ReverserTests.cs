using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverserTests
{
    [Test]
    public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        string[] inputArray = Array.Empty<string>();

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
    {
        // Arrange
        string[] input = { "single" };

        // Act
        string[] result = Reverser.ReverseStrings(input);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "elgnis" }));
    }

    [Test]
    public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
    {
        // Arrange
        string[] input = { "single", "stun", "Hello" };

        // Act
        string[] result = Reverser.ReverseStrings(input);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "elgnis", "nuts", "olleH" }));
    }

    [Test]
    public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
    {
        // Arrange
        string[] input = { "P@ss", "N~^t", "a+b=C" };

        // Act
        string[] result = Reverser.ReverseStrings(input);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "ss@P", "t^~N", "C=b+a" }));
    }
}
