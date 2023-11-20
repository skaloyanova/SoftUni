using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        string[] input = { };

        string result = Plants.GetFastestGrowing(input);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        string[] input = { "plant" };
        string expected = $"Plants with 5 letters:{Environment.NewLine}plant";

        string result = Plants.GetFastestGrowing(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        string[] input = { "plant", "plant6", "alabaa", "abcde", "four" };
        StringBuilder sb = new ();
        sb.AppendLine("Plants with 4 letters:");
        sb.AppendLine("four");
        sb.AppendLine("Plants with 5 letters:");
        sb.AppendLine("plant");
        sb.AppendLine("abcde");
        sb.AppendLine("Plants with 6 letters:");
        sb.AppendLine("plant6");
        sb.AppendLine("alabaa");

        string expected = sb.ToString().Trim();

        string result = Plants.GetFastestGrowing(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        string[] input = { "plant", "plAnt6", "alaAAb", "Abcde", "f0ur" };
        StringBuilder sb = new();
        sb.AppendLine("Plants with 4 letters:");
        sb.AppendLine("f0ur");
        sb.AppendLine("Plants with 5 letters:");
        sb.AppendLine("plant");
        sb.AppendLine("Abcde");
        sb.AppendLine("Plants with 6 letters:");
        sb.AppendLine("plAnt6");
        sb.AppendLine("alaAAb");

        string expected = sb.ToString().Trim();

        string result = Plants.GetFastestGrowing(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithPlantsWithSpace_ShouldReturnGroupedPlants()
    {
        string[] input = { "pla nt", "", "plAnt6", "  ", "1" };
        StringBuilder sb = new();
        sb.AppendLine("Plants with 0 letters:");
        sb.AppendLine("");
        sb.AppendLine("Plants with 1 letters:");
        sb.AppendLine("1");
        sb.AppendLine("Plants with 2 letters:");
        sb.AppendLine("  ");
        sb.AppendLine("Plants with 6 letters:");
        sb.AppendLine("pla nt");
        sb.AppendLine("plAnt6");

        string expected = sb.ToString().Trim();

        string result = Plants.GetFastestGrowing(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
