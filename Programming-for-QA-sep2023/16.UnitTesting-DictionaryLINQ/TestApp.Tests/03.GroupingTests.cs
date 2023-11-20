using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        List<int> input = new();

        string result = Grouping.GroupNumbers(input);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new() { 4, 0, 5, 2, 1, 3 };
        string expected = $"Even numbers: 4, 0, 2{Environment.NewLine}Odd numbers: 5, 1, 3";

        string result = Grouping.GroupNumbers(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new() { 4, 0, 1000, 2};
        string expected = "Even numbers: 4, 0, 1000, 2";

        string result = Grouping.GroupNumbers(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new() { 5, 1, 5555, 3 };
        string expected = "Odd numbers: 5, 1, 5555, 3";

        string result = Grouping.GroupNumbers(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new() { -5, -4, 0, -2, -1, -3 };
        string expected = $"Odd numbers: -5, -1, -3{Environment.NewLine}Even numbers: -4, 0, -2";

        string result = Grouping.GroupNumbers(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
