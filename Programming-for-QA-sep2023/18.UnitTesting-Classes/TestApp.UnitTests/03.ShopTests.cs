using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop _shop;

    [SetUp]
    public void Setup()
    {
        _shop = new Shop();
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        string[] products = { "54321 Gadget 3 15.5", "98765 Gizmo 2 8.4", "12345 Widget 5 10.02" };

        string expected = $"12345{Environment.NewLine}" +
            $"-- Widget - $10.02: 5{Environment.NewLine}" +
            $"-- $50.10{Environment.NewLine}" +
            $"54321{Environment.NewLine}" +
            $"-- Gadget - $15.50: 3{Environment.NewLine}" +
            $"-- $46.50{Environment.NewLine}" +
            $"98765{Environment.NewLine}" +
            $"-- Gizmo - $8.40: 2{Environment.NewLine}" +
            $"-- $16.80";

        // Act
        string result = _shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        string[] products = { };
        string expected = "";

        string result = _shop.AddAndGetBoxes(products);

        Assert.That(result, Is.EqualTo(expected));
    }
}
