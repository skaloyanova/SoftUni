using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class NumberFrequencyTests
{
    [Test]
    public void Test_CountDigits_ZeroNumber_ReturnsEmptyDictionary()
    {
        //Arrange
        int input = 0;

        //Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_CountDigits_SingleDigitNumber_ReturnsDictionaryWithSingleEntry()
    {
        //Arrange
        int input = 7;
        Dictionary<int, int> expected = new()
        {
            { 7, 1 },
        };

        //Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CountDigits_MultipleDigitNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        //Arrange
        int input = 1502602152;
        Dictionary<int, int> expected = new()
        {
            { 1, 2 },
            { 5, 2 },
            { 0, 2 },
            { 2, 3 },
            { 6, 1 },
        };

        //Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CountDigits_NegativeNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        //Arrange
        int input = -150260212;
        Dictionary<int, int> expected = new()
        {
            { 1, 2 },
            { 5, 1 },
            { 0, 2 },
            { 2, 3 },
            { 6, 1 },
        };

        //Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
