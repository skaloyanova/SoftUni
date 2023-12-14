using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class SubstringExtractorTests
{
    [Test]
    public void Test_ExtractSubstringBetweenMarkers_SubstringFound_ReturnsExtractedSubstring()
    {
        //Arrange
        string input = "I am living in Sofia!";
        string startMarker = "am ";
        string endMarker = " in";

        string expected = "living";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartMarkerNotFound_ReturnsNotFoundMessage()
    {
        //Arrange
        string input = "I am living in Sofia!";
        string startMarker = "as";
        string endMarker = " in";

        string expected = "Substring not found";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EndMarkerNotFound_ReturnsNotFoundMessage()
    {
        //Arrange
        string input = "I am living in Sofia!";
        string startMarker = " am";
        string endMarker = " innn";

        string expected = "Substring not found";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersNotFound_ReturnsNotFoundMessage()
    {
        //Arrange
        string input = "I am living in Sofia!";
        string startMarker = "not";
        string endMarker = " found";

        string expected = "Substring not found";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EmptyInput_ReturnsNotFoundMessage()
    {
        //Arrange
        string input = string.Empty;
        string startMarker = "not";
        string endMarker = " found";

        string expected = "Substring not found";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_NullInput_ReturnsNotFoundMessage()
    {
        //Arrange
        string? input = null;
        string startMarker = "not";
        string endMarker = " found";

        string expected = "Substring not found";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersOverlapping_ReturnsNotFoundMessage()
    {
        //Arrange
        string input = "I am living in Sofia!";
        string startMarker = "am li";
        string endMarker = "liv";

        string expected = "Substring not found";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersConcurrent_ReturnsNotFoundMessage()
    {
        //Arrange
        string input = "I am living in Sofia!";
        string startMarker = "am ";
        string endMarker = "li";

        string expected = string.Empty;

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EndMarkerOverLapAndFoundAlso_ReturnsNotFoundMessage()
    {
        //Arrange
        string input = "I am living in li Sofia!";
        string startMarker = "am ";
        string endMarker = " li";

        string expected = "living in";

        //Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
