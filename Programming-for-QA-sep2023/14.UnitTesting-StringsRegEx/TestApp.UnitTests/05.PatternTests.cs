using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{

    [TestCase("abc", 1, "aBc")]
    [TestCase("AlAbAlA ", 2, "aLaBaLa aLaBaLa ")]
    [TestCase("SpeciaL4@r", 3, "sPeCiAl4@RsPeCiAl4@RsPeCiAl4@R")]
    [TestCase(" ", 25, "                         ")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input, int repetitionFactor, string expected)
    {
        string result = Pattern.GeneratePatternedString(input, repetitionFactor);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
    {
        string input = string.Empty;
        int repetitionFactor = 5;

        Assert.That(() => Pattern.GeneratePatternedString(input, repetitionFactor), Throws.ArgumentException.With.Message.EqualTo("Input string cannot be empty, and repetition factor must be positive."));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        string input = "abc";
        int repetitionFactor = -1;

        Assert.That(() => Pattern.GeneratePatternedString(input, repetitionFactor), Throws.ArgumentException.With.Message.EqualTo("Input string cannot be empty, and repetition factor must be positive."));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {
        string input = "abc";
        int repetitionFactor = 0;

        Assert.That(() => Pattern.GeneratePatternedString(input, repetitionFactor), Throws.ArgumentException.With.Message.EqualTo("Input string cannot be empty, and repetition factor must be positive."));
    }

    // below testcases consolidate the above 3 separate tests for exceptions
    [TestCase("", 100)]
    [TestCase("abc", -1)]
    [TestCase("abc", 0)]
    public void Test_GeneratePatternedString_InvalidInput_ThrowsArgumentException(string input, int repetitionFactor)
    {
        Assert.That(() => Pattern.GeneratePatternedString(input, repetitionFactor), Throws.ArgumentException);
    }
}
