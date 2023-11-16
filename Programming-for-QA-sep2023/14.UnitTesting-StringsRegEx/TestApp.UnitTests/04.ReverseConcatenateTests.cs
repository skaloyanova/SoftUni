using NUnit.Framework;

using System;
using System.Linq;

namespace TestApp.UnitTests;

public class ReverseConcatenateTests
{

    [Test]
    public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
    {
        string[] input = Array.Empty<string>();

        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);
        string expected = string.Empty;

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
    {
        string[] input = { "single text" };

        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);
        string expected = "single text";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
    {
        string[] input = { ".", "twinkle"," ", "stars" , " night, ", "Silent" };

        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);
        string expected = "Silent night, stars twinkle.";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
    {
        string[]? input = null;

        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);
        string expected = "";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
    {
        string[] input = { "a", "   "};

        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);
        string expected = "   a";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
    {
        string[] input = { "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", "ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc"};

        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);
        string expected = "cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        Assert.That(result, Is.EqualTo(expected));
    }
}
