using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchPhoneNumbersTests
{
    // Regex: \+359(?<seperators>[ -])2\k<seperators>[0-9]{3}\k<seperators>[0-9]{4}\b

    [Test]
    public void Test_Match_ValidPhoneNumbers_ReturnsMatchedNumbers()
    {
        string input = "+359-2-124-5678, +359 2 986 5432, +359-2-555-5555";
        string expected = "+359-2-124-5678, +359 2 986 5432, +359-2-555-5555";

        string result = MatchPhoneNumbers.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_NoValidPhoneNumbers_ReturnsEmptyString()
    {
        string input = "+359-2 124-5678, +359 2 986-5432, +359/2/555/5555 aasd +359-22-123-1234 dddd +359 2 1234 1234 ddddddd +359 2 333 44445 a+359-0-124-5678 +359-2-124-5678a +359-1-124-5678 +359-3-124-5678 +359-4-124-5678 +359-5-124-5678 +359-6-124-5678 +359-7-124-5678 +359-8-124-5678 +359-9-124-5678";
        string expected = string.Empty;

        string result = MatchPhoneNumbers.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        string input = "";
        string expected = string.Empty;

        string result = MatchPhoneNumbers.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_MixedValidAndInvalidNumbers_ReturnsOnlyValidNumbers()
    {
        string input = "+359-2-124-5678, +359-3-124-5678 +359 2 986 5432, +359-2-555-5555   +359-2-555 5555 +359-3-124-56788";
        string expected = "+359-2-124-5678, +359 2 986 5432, +359-2-555-5555";

        string result = MatchPhoneNumbers.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
