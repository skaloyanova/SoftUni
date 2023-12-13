using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
         //Act
        _inventory.AddProduct("egg", 1.05, 10);
        string result = _inventory.DisplayInventory();

        //Assert
        Assert.That(result.Contains("egg - Price: $1.05 - Quantity: 10"));
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        string result = _inventory.DisplayInventory();

        Assert.That(result, Is.EqualTo("Product Inventory:"));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        string expected = $"Product Inventory:{Environment.NewLine}" +
            $"egg - Price: $1.05 - Quantity: 10{Environment.NewLine}" +
            $"milk - Price: $2.50 - Quantity: 2";

        _inventory.AddProduct("egg", 1.05, 10);
        _inventory.AddProduct("milk", 2.50, 2);
        string result = _inventory.DisplayInventory();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        double result = _inventory.CalculateTotalValue();

        Assert.That(result == 0);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        _inventory.AddProduct("egg", 1.05, 10);
        _inventory.AddProduct("milk", 2.50, 2);
        _inventory.AddProduct("zero", 3.50, 0);
        _inventory.AddProduct("zeroo", 0, 5);
        double expected = 15.5;

        double result = _inventory.CalculateTotalValue();

        Assert.That(result, Is.EqualTo(expected));
    }
}
