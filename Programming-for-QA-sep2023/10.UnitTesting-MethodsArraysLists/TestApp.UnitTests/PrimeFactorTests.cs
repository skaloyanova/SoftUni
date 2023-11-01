using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_NumberLowerThanTwo()
    {
        long input = 1;

        Assert.That(() => PrimeFactor.FindLargestPrimeFactor(input), Throws.ArgumentException);
    }

    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        long input = 17;

        long result = PrimeFactor.FindLargestPrimeFactor(input);

        Assert.That(result, Is.EqualTo(17));
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        long input = 462;

        long result = PrimeFactor.FindLargestPrimeFactor(input);

        Assert.That(result, Is.EqualTo(11));
    }
}
