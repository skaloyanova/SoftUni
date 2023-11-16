using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchNamesTests
{
    [Test]
    public void Test_Match_ValidNames_ReturnsMatchedNames()
    {
        string names = "John Smith and Alice Johnson";
        string expected = "John Smith Alice Johnson";

        string result = MatchNames.Match(names);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_NoValidNames_ReturnsEmptyString()
    {
        string names = "JOhn Smith and Alice JOhnson";
        string expected = "";

        string result = MatchNames.Match(names);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        string names = "";
        string expected = "";

        string result = MatchNames.Match(names);

        Assert.That(result, Is.EqualTo(expected));
    }
}
