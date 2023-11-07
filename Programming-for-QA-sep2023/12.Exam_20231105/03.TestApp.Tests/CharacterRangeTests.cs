using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class CharacterRangeTests
{
    [Test]
    public void Test_GetRange_WithAAndBInOrder_ReturnsEmptyString()
    {
        //Arrange
        char one = 'A';
        char two = 'B';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetRange_WithAAndBInOrder_ReturnsEmptyString2()
    {
        //Arrange
        char one = '5';
        char two = '6';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetRange_WithBAndAInOrder_ReturnsEmptyString()
    {
        //Arrange
        char one = 'b';
        char two = 'a';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetRange_WithBAndAInOrder_ReturnsEmptyString2()
    {
        //Arrange
        char one = '7';
        char two = '6';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetRange_WithAAndCInOrder_ReturnsB()
    {
        //Arrange
        char one = 'a';
        char two = 'c';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.EqualTo("b"));
    }

    [Test]
    public void Test_GetRange_WithAAndCInOrder_ReturnsB2()
    {
        //Arrange
        char one = '1';
        char two = '6';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.EqualTo("2 3 4 5"));
    }

    [Test]
    public void Test_GetRange_WithDAndGInOrder_Returns_E_F()
    {
        //Arrange
        char one = 'D';
        char two = 'G';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.EqualTo("E F"));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y()
    {
        //Arrange
        char one = 'x';
        char two = 'z';

        //Act
        string result = CharacterRange.GetRange(one, two);

        //Assert
        Assert.That(result, Is.EqualTo("y"));
    }
}
