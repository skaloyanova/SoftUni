using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverseTests
{
    [Test]
    public void Test_ReverseArray_InputIsEmpty_ShouldReturnEmptyString()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();

        // Act
        string result = Reverse.ReverseArray(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [TestCase(new int[] { 10 }, "10")]
    [TestCase(new int[] { -5 }, "-5")]
    public void Test_ReverseArray_InputHasOneElement_ShouldReturnTheSameElement(int[] input, string expected)
    {
        // Arrange

        // Act
        string actual = Reverse.ReverseArray(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new int[] { 1, 20, 305 }, "305 20 1")]
    [TestCase(new int[] { -5000, 0, -98 }, "-98 0 -5000")]
    public void Test_ReverseArray_InputHasMultipleElements_ShouldReturnReversedString(int[] input, string expected)
    {
        // Arrange

        // Act
        string actual = Reverse.ReverseArray(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
