using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        string[] input = new string[] { };

        string result = OddOccurrences.FindOdd(input);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        string[] input = new string[] { "aa", "aa", "123", "123" };
        string expected = "";

        string result = OddOccurrences.FindOdd(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        string[] input = new string[] { "ab@-7." };
        string expected = "ab@-7.";

        string result = OddOccurrences.FindOdd(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        string[] input = new string[] { "abx", "adadff", "three", "adadff", "three", "spa ce", "three" };
        string expected = "abx three spa ce";

        string result = OddOccurrences.FindOdd(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        string[] input = new string[] { "aBx", "adadff", "ThreE", "adadff", "thRee", "spA ce", "thREe" };
        string expected = "abx three spa ce";

        string result = OddOccurrences.FindOdd(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
