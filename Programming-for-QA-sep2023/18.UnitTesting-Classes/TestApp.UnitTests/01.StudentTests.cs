using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class StudentTests
{
    private Student _student;

    [SetUp]
    public void SetUp()
    {
        this._student = new();
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia" };
        string wantedCity = "Sofia";
        string expected = $"John Doe is 25 years old.{Environment.NewLine}Alice Johnson is 20 years old.";

        // Act
        string result = _student.AddAndGetByCity(students, wantedCity);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists2()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia" };
        string wantedCity = "Varna";
        string expected = $"Jane Smith is 22 years old.";

        // Act
        string result = _student.AddAndGetByCity(students, wantedCity);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityDoesNotExist()
    {
        string[] students = { "Aaaz Baaz 20 Sofia", "Caaaz Daaz 18 Burgas", "Eeez Deez 5 Any" };
        string wantedTown = "Plovdiv";
        string expected = "";

        string result = _student.AddAndGetByCity(students, wantedTown);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityExistAndDataUpdated()
    {
        string[] students = { "Aaaz Baaz 20 Sofia", "Caaaz Daaz 18 Burgas", "Aaaz Baaz 20 Burgas", "Caaaz Daaz 20 Burgas" };
        string wantedTown = "Burgas";
        string expected = $"Aaaz Baaz is 20 years old.{Environment.NewLine}Caaaz Daaz is 20 years old.";

        string result = _student.AddAndGetByCity(students, wantedTown);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenNoStudentsGiven()
    {
        string[] students = { };
        string wantedTown = "Plovdiv";
        string expected = "";

        string result = _student.AddAndGetByCity(students, wantedTown);

        Assert.That(result, Is.EqualTo(expected));
    }
}
