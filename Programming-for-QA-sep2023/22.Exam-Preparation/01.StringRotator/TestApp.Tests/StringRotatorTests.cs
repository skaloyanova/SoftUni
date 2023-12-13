using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        string input = string.Empty;
        int positions = 5;

        string result = StringRotator.RotateRight(input, positions);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        string input = "stunkalo";
        int positions = 0;

        string result = StringRotator.RotateRight(input, positions);

        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        string input = "stunkalo";
        int positions = 4;
        string expected = "kalostun";

        string result = StringRotator.RotateRight(input, positions);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        string input = "stunkalo";
        int positions = -2;
        string expected = "lostunka";

        string result = StringRotator.RotateRight(input, positions);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        string input = "stunkalo";
        int positions = 201;
        string expected = "ostunkal";

        string result = StringRotator.RotateRight(input, positions);

        Assert.That(result, Is.EqualTo(expected));
    }
}
