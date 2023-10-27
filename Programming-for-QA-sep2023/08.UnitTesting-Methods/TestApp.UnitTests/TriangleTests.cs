using NUnit.Framework;
using System;
using System.Text;

namespace TestApp.UnitTests;

public class TriangleTests
{
    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size0()
    {
        // Arrange
        int size = 0;

        // Act
        string result = Triangle.PrintTriangle(size);

        // Assert
        Assert.AreEqual(string.Empty, result);
        Assert.AreEqual(0, result.Length);

    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size3()
    {
        // Arrange
        int size = 3;

        // Act
        string result = Triangle.PrintTriangle(size);

        StringBuilder expected = new StringBuilder();
        expected.Append("1");expected.AppendLine();
        expected.Append("1 2");expected.AppendLine();
        expected.Append("1 2 3");expected.AppendLine();
        expected.Append("1 2");expected.AppendLine();
        expected.Append("1");

        // Assert
        Assert.AreEqual(expected.ToString(), result);
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size5()
    {
        // Arrange
        int size = 5;

        // Act
        string result = Triangle.PrintTriangle(size);

        string expected = "" +
            "1" + Environment.NewLine +
            "1 2" + Environment.NewLine +
            "1 2 3" + Environment.NewLine +
            "1 2 3 4" + Environment.NewLine +
            "1 2 3 4 5" + Environment.NewLine +
            "1 2 3 4" + Environment.NewLine +
            "1 2 3" + Environment.NewLine +
            "1 2" + Environment.NewLine +
            "1";

        // Assert
        Assert.AreEqual(expected, result);
    }
}
