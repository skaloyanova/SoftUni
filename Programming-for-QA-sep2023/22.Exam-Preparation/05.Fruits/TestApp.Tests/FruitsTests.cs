using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            { "apple", 2 },
            { "orange", 5 }
        };
        string fruit = "orange";
        int expected = 5;

        //Act
        int result = Fruits.GetFruitQuantity(input, fruit);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            { "apple", 2 },
            { "orange", 5 }
        };
        string fruit = "orrange";
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(input, fruit);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> input = new();
        string fruit = "orange";

        //Act
        int result = Fruits.GetFruitQuantity(input, fruit);

        //Assert
        Assert.That(result == 0);
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int>? input = null;
        string fruit = "orange";

        //Act
        int result = Fruits.GetFruitQuantity(input, fruit);

        //Assert
        Assert.That(result == 0);
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            { "apple", 2 },
            { "orange", 5 }
        };
        string? fruit = null;

        //Act
        int result = Fruits.GetFruitQuantity(input, fruit);

        //Assert
        Assert.That(result == 0);
    }
}
