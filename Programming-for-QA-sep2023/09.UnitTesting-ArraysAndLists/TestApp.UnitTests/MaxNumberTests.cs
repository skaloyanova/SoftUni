using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MaxNumberTests
{
    [Test]
    public void Test_FindMax_InputIsNull_ShouldThrowArgumentException()
    {
        // Arrange
        List<int>? nullList = null;

        // Act & Assert
        Assert.That(() =>  MaxNumber.FindMax(nullList), Throws.ArgumentException.With.Message.EqualTo("Input list is empty or null."));
    }

    [Test]
    public void Test_FindMax_InputIsEmptyList_ShouldThrowArgumentException()
    {
        // Arrange
        List<int> emptyList = new();

        // Act & Assert
        Assert.That(() => MaxNumber.FindMax(emptyList), Throws.ArgumentException.With.Message.EqualTo("Input list is empty or null."));
    }

    [Test]
    public void Test_FindMax_InputHasOneElement_ShouldReturnTheElement()
    {
        List<int> input = new List<int>() { 5 };

        int result = MaxNumber.FindMax(input);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Test_FindMax_InputHasPositiveIntegers_ShouldReturnMaximum()
    {
        List<int> input = new List<int>() { 5, 1, 0, 9 };

        int result = MaxNumber.FindMax(input);

        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegers_ShouldReturnMaximum()
    {
        List<int> input = new List<int>() { -5, -17, -1, -4 };

        int result = MaxNumber.FindMax(input);

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegersAndZero_ShouldReturnMaximum()
    {
        List<int> input = new List<int>() { -5, -17, -1, -4, 0 };

        int result = MaxNumber.FindMax(input);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_FindMax_InputHasMixedIntegers_ShouldReturnMaximum()
    {
        List<int> input = new List<int>() { -5, 17, 0, -4 };

        int result = MaxNumber.FindMax(input);

        Assert.That(result, Is.EqualTo(17));
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateValue_ShouldReturnMaximum()
    {
        List<int> input = new List<int>() { -5, 17, -5, 0, -4 };

        int result = MaxNumber.FindMax(input);

        Assert.That(result, Is.EqualTo(17));
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateMaxValue_ShouldReturnMaximum()
    {
        List<int> input = new List<int>() { -5, 11, -5, 0, -4, 11 };

        int result = MaxNumber.FindMax(input);

        Assert.That(result, Is.EqualTo(11));
    }
}
