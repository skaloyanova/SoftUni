using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class DuplicatesTests
{
    [Test]
    public void Test_RemoveDuplicates_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] input = Array.Empty<int>();

        // Act
        int[] result = Duplicates.RemoveDuplicates(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveDuplicates_NoDuplicates_ReturnsOriginalArray()
    {
        // Arrange
        int[] input = { 1, 5, 7, -5, 0};

        // Act
        int[] result = Duplicates.RemoveDuplicates(input);

        // Assert
        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void Test_RemoveDuplicates_SomeDuplicates_ReturnsUniqueArray()
    {
        // Arrange
        int[] input = { 1, 5, 5, 7, -5, -5, 0, 5 };

        // Act
        int[] result = Duplicates.RemoveDuplicates(input);

        // Assert
        Assert.That(result, Is.EqualTo(new int[] { 1, 5, 7, -5, 0 }));
    }

    [Test]
    public void Test_RemoveDuplicates_AllDuplicates_ReturnsSingleElementArray()
    {
        // Arrange
        int[] input = { 5, 5, 5, 5, 5 };

        // Act
        int[] result = Duplicates.RemoveDuplicates(input);

        // Assert
        Assert.That(result, Is.EqualTo(new int[] { 5 }));
    }
}
