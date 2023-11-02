using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{

    [Test]
    public void Test_RemoveStringNumbers_NullInput_ThrowsException()
    {
        // Arrange
        char[]? input = null;

        // Act + Assert
        Assert.That(() => Fake.RemoveStringNumbers(input), Throws.ArgumentException);
    }

    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        char[] input = { '0', '1', 'a', 'b', '5', 'c' };

        char[] result = Fake.RemoveStringNumbers(input);

        Assert.That(result, Is.EqualTo(new char[] { 'a', 'b', 'c' }));
    }

    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray_()
    {
        char[] input = { '0', '1', '2', '3', '5' };

        char[] result = Fake.RemoveStringNumbers(input);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        char[] input = { 's', 't', 'u', 'n' };

        char[] result = Fake.RemoveStringNumbers(input);

        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        char[] input = Array.Empty<char>();

        char[] result = Fake.RemoveStringNumbers(input);

        Assert.That(result, Is.Empty);
    }
}
