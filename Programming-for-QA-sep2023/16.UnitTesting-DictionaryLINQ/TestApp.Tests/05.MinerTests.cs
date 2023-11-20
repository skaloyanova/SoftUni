using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        string[] input = new string[0];

        string result = Miner.Mine(input);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        string[] input = new string[] { "gold 5", "Gold 1", "gOLd 2", "SilVeR 10", "silVER 20"};

        string nl = Environment.NewLine;
        string expected = $"gold -> 8{nl}silver -> 30";

        string result = Miner.Mine(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        string[] input = new string[] { "gold 5", "silver 0", "gold 1", "gold 2", "gold 30", "silver -5", "ore 1", "ore 15" };

        string nl = Environment.NewLine;
        string expected = $"gold -> 38{nl}silver -> -5{nl}ore -> 16";

        string result = Miner.Mine(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
