using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        //Arrange
        string input = string.Empty;

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        //Arrange
        string input = "stun";
        string[] expected = { "stun" };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        //Arrange
        string input = "stun,kalo";
        string[] expected = { "stun", "kalo" };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        //Arrange
        string input = "      ";
        string[] expected = { string.Empty};

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
