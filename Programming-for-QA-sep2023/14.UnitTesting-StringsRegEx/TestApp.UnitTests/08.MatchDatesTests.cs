using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchDatesTests
{
    // RegEx: \b(?<day>\d{2})(?<seperator>[-.\/])(?<month>[A-Z][a-z]+)\k<seperator>(?<year>\d{4})
    // Output: "Day: {day}, Month: {month}, Year: {year}"

    [TestCase("15-Nov-2023", "Day: 15, Month: Nov, Year: 2023")]
    [TestCase("15.Nove.2023", "Day: 15, Month: Nove, Year: 2023")]
    [TestCase("15/November/2023", "Day: 15, Month: November, Year: 2023")]
    //[TestCase(@"15\Novem\2023", "Day: 15, Month: Novem, Year: 2023")]
    public void Test_Match_ValidDate_ReturnsExpectedResult(string input, string expected)
    {
        string result = MatchDates.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("", "")]
    [TestCase("text only", "")]
    [TestCase("15.Nov-2023", "")]
    [TestCase("15-Nov.2023", "")]
    [TestCase("15/Nov-2023", "")]
    [TestCase(@"15\Nov-2023", "")]
    public void Test_Match_NoMatch_ReturnsEmptyString(string input, string expected)
    {
        string result = MatchDates.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_MultipleMatches_ReturnsFirstMatch()
    {
        string input = "15-Nov-2023 15.Nove.2023";
        string expected = "Day: 15, Month: Nov, Year: 2023";

        string result = MatchDates.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_EmptyString_ReturnsEmptyString()
    {
        string input = "";
        string expected = "";

        string result = MatchDates.Match(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_NullInput_ThrowsArgumentException()
    {
        string? input = null;

        Assert.That(() => MatchDates.Match(input), Throws.ArgumentException);
    }
}
