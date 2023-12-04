using NUnit.Framework;

using System;
using System.Text;
using System.Xml.Linq;

namespace TestApp.UnitTests;

public class PlanetTests
{
    [Test]
    public void Test_CalculateGravity_ReturnsCorrectCalculation()
    {
        // Arrange
        Planet earth = new("Earth", 12742, 149600000, 1);
        double mass = 1000;
        double expectedGravity = mass * 6.67430e-11 / Math.Pow(earth.Diameter / 2, 2);

        // Act
        double result = earth.CalculateGravity(mass);

        // Assert
        Assert.That(result, Is.EqualTo(expectedGravity));
    }

    [Test]
    public void Test_GetPlanetInfo_ReturnsCorrectInfo()
    {
        //Arrange
        Planet input = new Planet("Melmak", 10.0008, 1000, 2);
        string expected = $"Planet: Melmak{Environment.NewLine}" +
                          $"Diameter: 10.0008 km{Environment.NewLine}" +
                          $"Distance from the Sun: 1000 km{Environment.NewLine}" +
                          $"Number of Moons: 2";

        //Act
        string result = input.GetPlanetInfo();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
