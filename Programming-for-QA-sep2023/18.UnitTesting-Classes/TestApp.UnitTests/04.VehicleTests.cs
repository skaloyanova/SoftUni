using NUnit.Framework;

using System;

using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles _vehicle;

    [SetUp]
    public void Setup()
    {
        _vehicle = new Vehicles();
    }
   
    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
        string[] vehicles = { "Car/Toyota/Camry/150", "Truck/Volvo/VNL/500", "Car/Ford/Focus/120" };
        string expected = $"Cars:{Environment.NewLine}" +
            $"Ford: Focus - 120hp{Environment.NewLine}" +
            $"Toyota: Camry - 150hp{Environment.NewLine}" +
            $"Trucks:{Environment.NewLine}" +
            $"Volvo: VNL - 500kg";

        // Act
        string result = _vehicle.AddAndGetCatalogue(vehicles);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        string[] vehicles = { };
        string expected = $"Cars:{Environment.NewLine}Trucks:";

        string result = _vehicle.AddAndGetCatalogue(vehicles);

        Assert.That(result, Is.EqualTo(expected));
    }
}
