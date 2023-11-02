using NUnit.Framework;

using System;
using System.Linq;

namespace TestApp.UnitTests;

public class PatternTests
{
    [Test]
    public void Test_SortInPattern_NullInput_ThrowsException()
    {
        // Arrange
        int[]? input = null;

        // Act + Assert
        Assert.That(() => Pattern.SortInPattern(input), Throws.ArgumentException);

    }

    [TestCase("1 2 3 4", "1 4 2 3")]
    [TestCase("1 2 1 3 4 10 12 15", "1 15 2 12 3 10 4")]
    [TestCase("1 1 2 2 2 2 3 3 4 4", "1 4 2 3")]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly(string inputString, string expectedString)
    {
        int[] input = inputString.Split(" ").Select(int.Parse).ToArray();
        int[] expected = expectedString.Split(" ").Select(int.Parse).ToArray();

        int[] result = Pattern.SortInPattern(input);

        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        int[] input = Array.Empty<int>();

        int[] result = Pattern.SortInPattern(input);

        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        int[] input = { 555 };

        int[] result = Pattern.SortInPattern(input);

        CollectionAssert.AreEqual(input, result);
    }
}
