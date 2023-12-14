using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            { "Pesho", 5},
            { "Peshko", 5},
            { "Lazar", 4},
            { "Gosho", 4},
            { "Tedi", 3},
        };

        string expected = $"Peshko with average grade 5.00{Environment.NewLine}" +
            $"Pesho with average grade 5.00{Environment.NewLine}" +
            $"Gosho with average grade 4.00";

        //Act
        string result = Grades.GetBestStudents(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        //Arrange
        Dictionary<string, int> input = new();

        //Act
        string result = Grades.GetBestStudents(input);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            { "Pesho", 4},
            { "Gosho", 6},
        };

        string expected = $"Gosho with average grade 6.00{Environment.NewLine}" +
            $"Pesho with average grade 4.00";

        //Act
        string result = Grades.GetBestStudents(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            { "Pesho", 4},
            { "Gosho", 4},
        };

        string expected = $"Gosho with average grade 4.00{Environment.NewLine}" +
            $"Pesho with average grade 4.00";

        //Act
        string result = Grades.GetBestStudents(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
