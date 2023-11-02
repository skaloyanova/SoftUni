using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PalindromeTests
{
    [Test]
    public void Test_IsPalindrome_ValidPalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new() { "alabala", "helleh", "aba" };

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_IsPalindrome_EmptyList_ReturnsTrue()
    {
        // Arrange
        List<string> input = new();

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_IsPalindrome_SingleWord_ReturnsTrue()
    {
        // Arrange
        List<string> input = new() { "alabala" };

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        // Arrange
        List<string> input = new() { "alabala", "alaba1a" };

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void Test_IsPalindrome_MixedCasePalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new() { "AlabAla" };

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }
}
