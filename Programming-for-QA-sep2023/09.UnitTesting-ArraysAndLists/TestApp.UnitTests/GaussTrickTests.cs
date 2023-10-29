using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class GaussTrickTests
{
    [Test]
    public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        List<int> result = GaussTrick.SumPairs(emptyList);

        // Assert
        CollectionAssert.AreEqual(emptyList, result);
    }

    [Test]
    public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
    {
        // Arrange
        List<int> input = new() {4};

        // Act
        List<int> result = GaussTrick.SumPairs(input);

        // Assert
        CollectionAssert.AreEqual(input, result);
    }


    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> input = new() { 5, 7 };

        // Act
        List<int> result = GaussTrick.SumPairs(input);

        // Assert
        List<int> expected = new() { 12 };
        CollectionAssert.AreEqual (expected, result);

    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> input = new() { 5, 7, 9 };

        // Act
        List<int> result = GaussTrick.SumPairs(input);

        // Assert
        List<int> expected = new() { 14, 7 };
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> input = new() { 1, 2, 3, 4, 5, 6, 7, 7, 6, 5, 4, 3, 2, 1 };

        // Act
        List<int> result = GaussTrick.SumPairs(input);

        // Assert
        List<int> expected = new() { 2, 4, 6, 8, 10, 12, 14 };
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> input = new() { 1, 2, 3, 4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2, 1 };

        // Act
        List<int> result = GaussTrick.SumPairs(input);

        // Assert
        List<int> expected = new() { 2, 4, 6, 8, 10, 12, 14, 8 };
        CollectionAssert.AreEqual(expected, result);
    }
}
