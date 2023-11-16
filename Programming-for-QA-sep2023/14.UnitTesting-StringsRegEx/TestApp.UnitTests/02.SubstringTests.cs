using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{
    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        string toRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog";

        string result = Substring.RemoveOccurrences(toRemove, input);
        string expected = "The quick brown jumps over the lazy dog";

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        string toRemove = "The ";
        string input = "The quick brown fox jumps over the lazy dog";

        string result = Substring.RemoveOccurrences(toRemove, input);
        string expected = "quick brown fox jumps over lazy dog";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        string toRemove = "dog";
        string input = "The quick brown fox jumps over the lazy dog";

        string result = Substring.RemoveOccurrences(toRemove, input);
        string expected = "The quick brown fox jumps over the lazy";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        string toRemove = "abc";
        string input = "aaabcbabccbc";

        string result = Substring.RemoveOccurrences(toRemove, input);
        string expected = "";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_emptyInput()
    {
        string toRemove = "abc";
        string input = string.Empty;

        string result = Substring.RemoveOccurrences(toRemove, input);

        Assert.That(result, Is.Empty);
    }

    //[Test]
    //public void Test_RemoveOccurrences_emptyRemoveSrting()
    //{
    //    string toRemove = string.Empty;
    //    string input = "abc";

    //    string result = Substring.RemoveOccurrences(toRemove, input);

    //    Assert.That(result, Is.EqualTo(input));
    //}
}
