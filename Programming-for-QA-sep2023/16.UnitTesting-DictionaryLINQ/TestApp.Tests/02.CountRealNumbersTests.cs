using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        int[] input = new int[] { };

        string result = CountRealNumbers.Count(input);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        int[] input = new int[] { 123 };
        string expected = "123 -> 1";

        string result = CountRealNumbers.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        int[] input = new int[] { 555, 5, 55, 5 };
        string nl = Environment.NewLine;
        string expected = $"5 -> 2{nl}55 -> 1{nl}555 -> 1";

        string result = CountRealNumbers.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        int[] input = new int[] { -5, -50, -5, -12 };
        string nl = Environment.NewLine;
        string expected = $"-50 -> 1{nl}-12 -> 1{nl}-5 -> 2";

        string result = CountRealNumbers.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        int[] input = new int[] { 0, 0, 0 };
        string nl = Environment.NewLine;
        string expected = $"0 -> 3";

        string result = CountRealNumbers.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
