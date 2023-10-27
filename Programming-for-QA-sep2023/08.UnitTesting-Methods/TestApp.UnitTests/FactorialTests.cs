using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class FactorialTests
{
    [Test]
    public void CalculateFactorial_InputZero_ReturnsOne()
    {
        //Arrange
        int n = 0;

        //Act
        int result = Factorial.CalculateFactorial(n);

        //Assert
        Assert.AreEqual(1, result);
    }

    [Test]
    public void CalculateFactorial_InputPositiveNumber_ReturnsCorrectFactorial()
    {
        //Arrange
        int n = 3;

        //Act
        int result = Factorial.CalculateFactorial(n);

        //Assert
        Assert.AreEqual(6, result);
    }

    [Test]
    public void CalculateFactorial_InputNegativeNumber_ThrowsException()
    {
        //Arrange
        int n = -1;

        //Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorial.CalculateFactorial(n));
    }

    [Test, Ignore("not implemented")]
    [Category("Ignored UnitTests")]
    public void TestTest()
    {
        
    }
}
