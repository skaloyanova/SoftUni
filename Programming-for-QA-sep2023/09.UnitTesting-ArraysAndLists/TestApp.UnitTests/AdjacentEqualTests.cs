using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class AdjacentEqualTests
{
    [Test]
    public void Test_Sum_InputIsNull_ShouldThrowArgumentException()
    {
        // Arrange
        List<int>? nullList = null;

        // Act & Assert
        Assert.That(() => AdjacentEqual.Sum(nullList), Throws.ArgumentException);
    }

    [Test]
    public void Test_Sum_InputIsEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        string result = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Sum_NoAdjacentEqualNumbers_ShouldReturnOriginalList()
    {
        // Arrange
        List<int> input = new() { 1, 2, 3, 4, 5 };

        // Act
        string result = AdjacentEqual.Sum(input);

        // Assert
        Assert.That(result, Is.EqualTo("1 2 3 4 5"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersExist_ShouldReturnSummedList()
    {
        List<int> input = new() { 1, 2, 2, -4, -4, -4, 5};

        string result = AdjacentEqual.Sum(input);

        Assert.That(result, Is.EqualTo("1 4 -8 -4 5"));
    }

    [Test]
    public void Test_Sum_AllNumbersAreAdjacentEqual_ShouldReturnSingleSummedNumber()
    {
        List<int> input = new() { 2, 2, 4, 8 };

        string result = AdjacentEqual.Sum(input);

        Assert.That(result, Is.EqualTo("16"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtBeginning_ShouldReturnSummedList()
    {
        List<int> input = new() { 2, 2, 4, 8, 20000 };

        string result = AdjacentEqual.Sum(input);

        Assert.That(result, Is.EqualTo("16 20000"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtEnd_ShouldReturnSummedList()
    {
        List<int> input = new() { -4, 5, 0, 2, 2, 2, 2 };

        string result = AdjacentEqual.Sum(input);

        Assert.That(result, Is.EqualTo("-4 5 0 8"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersInMiddle_ShouldReturnSummedList()
    {
        List<int> input = new() { -4, 5, 0, 2, 2, 2, 7, 2 };

        string result = AdjacentEqual.Sum(input);

        Assert.That(result, Is.EqualTo("-4 5 0 4 2 7 2"));
    }
}
