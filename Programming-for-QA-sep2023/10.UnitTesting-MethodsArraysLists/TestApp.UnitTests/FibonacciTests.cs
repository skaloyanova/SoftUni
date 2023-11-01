using NUnit.Framework;

namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_NegativeInput()
    {
        // Arrange
        int n = -1;

        // Act & Assert
        Assert.That(() => Fibonacci.CalculateFibonacci(n), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        int n = 0;

        int result = Fibonacci.CalculateFibonacci(n);

        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(5, 5)]
    [TestCase(15, 610)]
    [TestCase(31, 1346269)]
    public void Test_CalculateFibonacci_PositiveInput(int n, int expected)
    {
        int result = Fibonacci.CalculateFibonacci(n);

        Assert.That(result, Is.EqualTo(expected));
    }
}