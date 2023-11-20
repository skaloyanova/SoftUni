using System;
using System.Text;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        string[] input = Array.Empty<string>();

        string result = Orders.Order(input);

        Assert.That(result, Is.Empty);
    }


    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        string[] input = new string[] { "table 1.5 10", "stool 1.55 5", "window 5.1 5", "window 1 0", "door 2.4 2", "door 2.4 4", "zero 0 5", "test 0 4", "test 1.12 5" };
        StringBuilder sb = new();
        sb.AppendLine("table -> 15.00");
        sb.AppendLine("stool -> 7.75");
        sb.AppendLine("window -> 5.00");
        sb.AppendLine("door -> 14.40");
        sb.AppendLine("zero -> 0.00");
        sb.AppendLine("test -> 10.08");

        string expected = sb.ToString().Trim();

        string result = Orders.Order(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        string[] input = new string[] { "table 1.5049 9.3", "stool 1.998 5", "door 2.4 2", "door 2.40148 4" };
        StringBuilder sb = new();
        sb.AppendLine("table -> 14.00");
        sb.AppendLine("stool -> 9.99");
        sb.AppendLine("door -> 14.41");

        string expected = sb.ToString().Trim();

        string result = Orders.Order(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        string[] input = new string[] { "table 1.5 10.0", "stool 1.55 5.1", "window 5.1 5", "window 5.11 2.1" };
        StringBuilder sb = new();
        sb.AppendLine("table -> 15.00");
        sb.AppendLine("stool -> 7.91");
        sb.AppendLine("window -> 36.28");

        string expected = sb.ToString().Trim();

        string result = Orders.Order(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
