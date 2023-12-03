using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class SongTests
{
    private Song _song;

    [SetUp]
    public void Setup()
    {
        this._song = new();
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsAllSongs_WhenWantedListIsAll()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = "all";
        string expected = $"Song1{Environment.NewLine}Song2{Environment.NewLine}Song3";

        // Act
        string result = _song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsFilteredSongs_WhenWantedListIsSpecific()
    {
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Electro_Song3_13:00", "Electro_Song33_10:00" };
        string wantedList = "Electro";
        string expected = $"Song3{Environment.NewLine}Song33";

        string result = _song.AddAndListSongs(songs, wantedList);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenNoSongsMatchWantedList()
    {
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Electro_Song3_13:00", "Electro_Song33_10:00" };
        string wantedList = "Jazz";
        string expected = "";

        string result = _song.AddAndListSongs(songs, wantedList);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenSongsListIsEmpty()
    {
        // Arrange
        string[] songs = { };
        string wantedList = "All";
        string expected = "";

        // Act
        string result = _song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenWantedListIsEmpty()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Electro_Song3_13:00", "Electro_Song33_10:00" };
        string wantedList = "";
        string expected = "";

        // Act
        string result = _song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
