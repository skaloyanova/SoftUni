using NUnit.Framework;

namespace TestApp.UnitTests;

public class CalculateTests
{
    [Test]
    public void Test_Addition_WithPositiveNumbers()
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actual = calculator.Addition(5, 2);

        // Assert
        Assert.AreEqual(7, actual, "Addition did not work properly.");
        Assert.Greater(actual, 0);
    }

    [Test]
    public void Test_Addition_WithNegativeNumbers()
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actual = calculator.Addition(-5, -3);

        // Assert
        Assert.AreEqual(-8, actual, "Addition did not work properly.");
        Assert.Less(actual, 0);
    }

    [Test]
    public void Test_Subtraction_WhenGivenPossitiveNumbers()
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actual = calculator.Subtraction(5, 2);

        // Assert
        Assert.AreEqual(3, actual, "Addition did not work properly.");
    }

    [Test]
    public void Test_Subtraction_WhenGivenNegativeNumbers()
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actual = calculator.Subtraction(-5, -2);

        // Assert
        Assert.AreEqual(-3, actual, "Addition did not work properly.");
    }
}
