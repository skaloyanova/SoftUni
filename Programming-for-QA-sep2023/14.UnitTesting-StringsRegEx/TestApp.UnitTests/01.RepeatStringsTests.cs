using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        string[] input = Array.Empty<string>();

        string result = RepeatStrings.Repeat(input);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        string[] input = { "H3ll@" };

        string result = RepeatStrings.Repeat(input);
        string expected = "H3ll@H3ll@H3ll@H3ll@H3ll@";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        string[] input = { "1", "ab", "123", "!@#$"};

        string result = RepeatStrings.Repeat(input);
        string expected = "1abab123123123!@#$!@#$!@#$!@#$";

        Assert.That(result, Is.EqualTo(expected));

    }
}
