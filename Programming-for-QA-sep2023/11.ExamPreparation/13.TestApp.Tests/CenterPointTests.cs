using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class CenterPointTests
{
    [Test]
    public void Test_GetClosest_WhenFirstPointIsCloser_ShouldReturnFirstPoint()
    {
        //Arrange
        double x1 = 1;
        double y1 = 1;
        double x2 = 2;
        double y2 = 2;

        //Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        //Assert
        Assert.That(result, Is.EqualTo("(1, 1)"));
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsCloser_ShouldReturnSecondPoint()
    {
        //Arrange
        double x1 = 4;
        double y1 = 4;
        double x2 = 3;
        double y2 = 3;

        //Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        //Assert
        Assert.That(result, Is.EqualTo($"(3, 3)"));
    }

    [Test]
    public void Test_GetClosest_WhenBothPointsHaveEqualDistance_ShouldReturnFirstPoint()
    {
        //Arrange
        double x1 = 1;
        double y1 = 2;
        double x2 = 2;
        double y2 = 1;

        //Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        //Assert
        Assert.That(result, Is.EqualTo($"(1, 2)"));
    }

    [Test]
    public void Test_GetClosest_WhenFirstPointIsNegative_ShouldReturnFirstPoint()
    {
        //Arrange
        double x1 = -1;
        double y1 = -2;
        double x2 = 2;
        double y2 = 1;

        //Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        //Assert
        Assert.That(result, Is.EqualTo($"(-1, -2)"));
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsNegative_ShouldReturnSecondPoint()
    {
        //Arrange
        double x1 = 2;
        double y1 = 1;
        double x2 = -2;
        double y2 = -1;

        //Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        //Assert
        Assert.That(result, Is.EqualTo($"(-2, -1)"));
    }
}
