using NUnit.Framework;
using System;

using System.Collections.Generic;
using System.Linq;

namespace TestApp.Tests;

public class DrumSetTests
{
    [Test]
    public void Test_Drum_TerminateCommandNotGiven_ThrowsArgumentException()
    {
        //Arrange
        decimal money = 1000.00001m;
        List<int> initialQuality = new() { 100, 5 };
        List<string> commands = new() { "5", "3000" };

        //Act & Assert
        Assert.That(() => DrumSet.Drum(money, initialQuality, commands), Throws.ArgumentException);
    }

    [Test]
    public void Test_Drum_StringGivenAsCommand_ThrowsArgumentException()
    {
        //Arrange
        decimal money = 1000.0000001m;
        List<int> initialQuality = new() { 100, 5};
        List<string> commands = new() { "asdsa", "6", "Hit it again, Gabsy!" };

        //Act & Assert
        Assert.That(() => DrumSet.Drum(money, initialQuality, commands), Throws.ArgumentException);
    }

    [TestCase(501.55, "15 30 45 1", "Hit it again, Gabsy!", "15 30 45 1\nGabsy has 501.55lv.")]
    [TestCase(501.55, "15 30 45 1", "15; 5; Hit it again, Gabsy!", "10 10 25 1\nGabsy has 450.55lv.")]
    [TestCase(501.55, "15 30 45 1", "10; 5; 2; Hit it again, Gabsy!", "13 13 28 1\nGabsy has 447.55lv.")]
    public void Test_Drum_ReturnsCorrectQualityAndAmount(decimal money, string initialQualityStr, string commandsStr, string expected)
    {
        //Arrange
        List<int> initialQuality = initialQualityStr.Split(" ").Select(int.Parse).ToList();
        List<string> commands = commandsStr.Split("; ").ToList();

        //Act
        string result = DrumSet.Drum(money, initialQuality, commands);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }


    //[TestCase(90, "20 10 5", "20; 10; 10; Hit it again, Gabsy!", "\nGabsy has 0.00lv.")]
    [TestCase(90.01, "20 10 5", "20; 10; 10; Hit it again, Gabsy!", "\nGabsy has 0.01lv.")]
    //[TestCase(210, "40 15", "41; 40; Hit it again, Gabsy!", "15\nGabsy has 0.00lv.")]
    [TestCase(210.01, "40 15", "41; 40; Hit it again, Gabsy!", "15\nGabsy has 0.01lv.")]
    public void Test_Drum_BalanceZero_WithOneDrumLeftOver_ReturnsCorrectQualityAndAmount(decimal money, string initialQualityStr, string commandsStr, string expected)
    {
        //Arrange
        List<int> initialQuality = initialQualityStr.Split(" ").Select(int.Parse).ToList();
        List<string> commands = commandsStr.Split("; ").ToList();

        //Act
        string result = DrumSet.Drum(money, initialQuality, commands);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(100, "20 10 5", "20; 10; 10; Hit it again, Gabsy!", "\nGabsy has 10.00lv.")]
    public void Test_Drum_NotEnoughBalance_RemovesAllDrums_ReturnsCorrectQualityAndAmount(decimal money, string initialQualityStr, string commandsStr, string expected)
    {
        //Arrange
        List<int> initialQuality = initialQualityStr.Split(" ").Select(int.Parse).ToList();
        List<string> commands = commandsStr.Split("; ").ToList();

        //Act
        string result = DrumSet.Drum(money, initialQuality, commands);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
