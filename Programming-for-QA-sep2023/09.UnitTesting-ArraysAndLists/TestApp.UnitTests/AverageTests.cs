using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class AverageTests
{
    // return (double)sum / numbers.Length;

    [Test]
    public void Test_CalculateAverage_InputIsEmptyArray_ShouldThrowArgumentException()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();


        // Act & Assert
        //var 1
        Exception e = Assert.Throws<ArgumentException>(() => Average.CalculateAverage(emptyArray));
        Assert.AreEqual("Input array cannot be empty.", e.Message);

        //var 2
        Assert.That(() => Average.CalculateAverage(emptyArray), Throws.ArgumentException.With.Message.EqualTo("Input array cannot be empty."));
    }


    [Test]
    public void Test_CalculateAverage_InputHasOneElement_ShouldReturnSameElement()
    {
        // Arrange
        int[] arr = { 42 };

        // Act
        double result = Average.CalculateAverage(arr);

        // Assert
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void Test_CalculateAverage_InputHasPositiveIntegers_ShouldReturnCorrectAverage()
    {
        int[] arr = new int[] { 2, 0, 0, 0, 4, 0 };

        double result = Average.CalculateAverage(arr);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test_CalculateAverage_InputHasNegativeIntegers_ShouldReturnCorrectAverage()
    {
        int[] arr = new int[] { -2, -4, -5 };

        double result = Average.CalculateAverage(arr);

        Assert.That(result, Is.EqualTo((double)-11/3));
    }

    [Test]
    public void Test_CalculateAverage_InputHasMixedIntegers_ShouldReturnCorrectAverage()
    {
        int[] arr = new int[] { 2, -4, -5, 10 };

        double result = Average.CalculateAverage(arr);

        Assert.That(result, Is.EqualTo(0.75));
    }
}
