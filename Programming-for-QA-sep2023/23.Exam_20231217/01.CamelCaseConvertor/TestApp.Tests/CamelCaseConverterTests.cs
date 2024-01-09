using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CamelCaseConverterTests
{
    [Test]
    public void Test_ConvertToCamelCase_EmptyString_ReturnsEmptyString()
    {
        //Arrange
        string input = string.Empty;

        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [TestCase("Stun", "stun")]
    [TestCase("stun", "stun")]
    public void Test_ConvertToCamelCase_SingleWord_ReturnsLowercaseWord(string input, string expected)
    {
        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Stun is having an exam", "stunIsHavingAnExam")]
    [TestCase("only small letters", "onlySmallLetters")]
    [TestCase("ONLY CAPS LETTERS", "onlyCapsLetters")]
    public void Test_ConvertToCamelCase_MultipleWords_ReturnsCamelCase(string input, string expected)
    {
        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWordsWithMixedCase_ReturnsCamelCase()
    {
        //Arrange
        string input = "Stun Is haVinG an eXam";
        string expected = "stunIsHavingAnExam";

        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ConvertToCamelCase_SingleWord2_ReturnsLowercaseWord()
    {
        //Arrange
        string input = "S";
        string expected = "s";

        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    //[Test]
    //public void Test_ConvertToCamelCase_MultipleWordsWithMixedCase2_ReturnsCamelCase()
    //{
    //    //Arrange
    //    string input = "Stun Is  Having an  Exam";
    //    string expected = "stunIsHavingAnExam";

    //    //Act
    //    string result = CamelCaseConverter.ConvertToCamelCase(input);

    //    //Assert
    //    Assert.That(result, Is.EqualTo(expected));
    //}
}
