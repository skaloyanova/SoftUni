using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class EvenOddSubtractionTests
{
    [Test]
    public void Test_FindDifference_InputIsEmpty_ShouldReturnZero()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();

        // Act
        int result = EvenOddSubtraction.FindDifference(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    //Math.Abs(evenSum - oddSum)

    [TestCase(new int[] {-2, 0, -4}, 6)]
    [TestCase(new int[] {2, 20, 6, 4, 8}, 40)]
    [TestCase(new int[] {-10, 10, 2}, 2)]
    public void Test_FindDifference_InputHasOnlyEvenNumbers_ShouldReturnEvenSum(int[] input, int expected)
    {
        // Arrange

        // Act
        int result = EvenOddSubtraction.FindDifference(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
   
    [TestCase(new int[] { -7, -3, -1}, 11)]
    [TestCase(new int[] { 11, 21, 31, 7 }, 70)]
    [TestCase(new int[] { -7, 7, 5}, 5)]
    public void Test_FindDifference_InputHasOnlyOddNumbers_ShouldReturnOddSum(int[] input, int expected)
    {
        // Act
        int result = EvenOddSubtraction.FindDifference(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(new int[] { -2, -3, 0, 2, 3 }, 0)]
    [TestCase(new int[] { 2, 3, 11, 6, 9}, 15)]     //Math.Abs(8 - 23) = 15
    [TestCase(new int[] { 2, 4, -1, -5}, 12)]        //Math.Abs(6 - (-6)) = 12
    [TestCase(new int[] { -2, -4, 1, 5, 1}, 13)]        //Math.Abs(-6 - 7)) = 13
    public void Test_FindDifference_InputHasMixedNumbers_ShouldReturnDifference(int[] input, int expected)
    {
        int result = EvenOddSubtraction.FindDifference(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
