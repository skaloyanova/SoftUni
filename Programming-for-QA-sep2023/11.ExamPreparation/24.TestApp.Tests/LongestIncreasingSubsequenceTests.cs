using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        int[]? input = null;

        Assert.That(() => LongestIncreasingSubsequence.GetLis(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        int[] input = Array.Empty<int>();

        string result = LongestIncreasingSubsequence.GetLis(input);

        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        int[] input = { 1 };

        string result = LongestIncreasingSubsequence.GetLis(input);

        Assert.That(result, Is.EqualTo("1"));
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        int[] input = { 1, 5, -5, 10, 7, -20 };

        string result = LongestIncreasingSubsequence.GetLis(input);

        Assert.That(result, Is.EqualTo("1 5 10"));
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        int[] input = { -20, -5, 0, 1, 3, 7 };

        string result = LongestIncreasingSubsequence.GetLis(input);

        Assert.That(result, Is.EqualTo("-20 -5 0 1 3 7"));
    }
}
