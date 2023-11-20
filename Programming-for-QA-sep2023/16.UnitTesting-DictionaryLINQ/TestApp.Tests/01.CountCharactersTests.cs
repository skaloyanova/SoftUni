using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        List<string> input = new() { "", "" };

        string result = CountCharacters.Count(input);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        List<string> input = new() { "a" };
        string expected = $"a -> 1";

        string result = CountCharacters.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        List<string> input = new() { "stun", "supper", "nut" };
        string nl = Environment.NewLine;
        string expected = $"s -> 2{nl}t -> 2{nl}u -> 3{nl}n -> 2{nl}p -> 2{nl}e -> 1{nl}r -> 1";

        string result = CountCharacters.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        List<string> input = new() { "!@#", "@@", "^&&&*(" };
        string nl = Environment.NewLine;
        string expected = $"! -> 1{nl}@ -> 3{nl}# -> 1{nl}^ -> 1{nl}& -> 3{nl}* -> 1{nl}( -> 1";

        string result = CountCharacters.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithCapitalAndDigitCharacters_ShouldReturnCountString()
    {
        List<string> input = new() { "Stun", "supp3r" };
        string nl = Environment.NewLine;
        string expected = $"S -> 1{nl}t -> 1{nl}u -> 2{nl}n -> 1{nl}s -> 1{nl}p -> 2{nl}3 -> 1{nl}r -> 1";

        string result = CountCharacters.Count(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
