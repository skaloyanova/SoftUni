using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, "5 5 13 13")]
    [TestCase(new int[] { 1, 2, 3, 4 }, "3 7")]
    [TestCase(new int[] { 0, 0, 1, 2, 3, 4, 5, 1, 1, 2, 0, 1 }, "3 3 4 6 1 3")]
    [TestCase(new int[] { -1, -2, 2, 1, -4, -3, 3, 4,  }, "0 0 0 0")]
    [TestCase(new int[] { -1, -2, -3, -4 }, "-3 -7")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        string result = FoldSum.FoldArray(arr);

        Assert.AreEqual(expected, result);
    }
}
