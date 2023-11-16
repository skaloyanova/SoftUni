using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        string[] bannedWords = { "no" };
        string text = "original text";

        string result = TextFilter.Filter(bannedWords, text);
        string expected = "original text";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        string[] bannedWords = { "The", "on", "with", "mesmerizing" };
        string text = "The moonlight danced on the tranquil water, casting a mesmerizing glow that painted the night with a tapestry of ethereal beauty";

        string result = TextFilter.Filter(bannedWords, text);
        string expected = "*** mo**light danced ** the tranquil water, casting a *********** glow that painted the night **** a tapestry of ethereal beauty";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        string[] bannedWords = { };
        string text = "banned Words are empty!";

        string result = TextFilter.Filter(bannedWords, text);
        string expected = "banned Words are empty!";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        string[] bannedWords = { "ban 1", "  is"};
        string text = "alaba ban  1 aaaa  is ban ban 1 bbb is";

        string result = TextFilter.Filter(bannedWords, text);
        string expected = "alaba ban  1 aaaa**** ban ***** bbb is";

        Assert.That(result, Is.EqualTo(expected));
    }

    //[Test]
    //public void Test_Filter_WhenBannedWordIsEmptyString_ShouldReturnOriginalText()
    //{
    //    string[] bannedWords = { "", "are" };
    //    string text = "banned Words are empty!";

    //    string result = TextFilter.Filter(bannedWords, text);
    //    string expected = "banned Words *** empty!";

    //    Assert.That(result, Is.EqualTo(expected));
    //}

}
