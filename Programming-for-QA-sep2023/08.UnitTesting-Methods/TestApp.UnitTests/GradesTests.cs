using NUnit.Framework;

namespace TestApp.UnitTests;

/*
 * 2.00 … 2.99 ➡ "Fail"
 * 3.00 … 3.49 ➡ "Average"
 * 3.50 … 4.49 ➡ "Good"
 * 4.50 … 5.49 ➡ "Very good"
 * 5.50 … 6.00 ➡ "Excellent"
 * Other ➡ "Invalid!"
 */

public class GradesTests
{
    [TestCase(2.50, "Fail")]
    [TestCase(3.20, "Average")]
    [TestCase(3.60, "Good")]
    [TestCase(5.00, "Very Good")]
    [TestCase(5.80, "Excellent")]
    public void Test_GradeAsWords_ReturnsCorrectString(double grade, string expected)
    {
        // Arrange

        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase(1.99, "Invalid!")]
    [TestCase(2.00, "Fail")]
    [TestCase(2.99, "Fail")]
    [TestCase(3.00, "Average")]
    [TestCase(3.49, "Average")]
    [TestCase(3.50, "Good")]
    [TestCase(4.49, "Good")]
    [TestCase(4.50, "Very Good")]
    [TestCase(5.49, "Very Good")]
    [TestCase(5.50, "Excellent")]
    [TestCase(6.00, "Excellent")]
    [TestCase(6.01, "Invalid!")]
    [TestCase(double.PositiveInfinity, "Invalid!")]
    [TestCase(double.NegativeInfinity, "Invalid!")]
    public void Test_GradeAsWords_ReturnsCorrectString_EdgeCases(double grade, string expected)
    {
        // Arrange

        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
