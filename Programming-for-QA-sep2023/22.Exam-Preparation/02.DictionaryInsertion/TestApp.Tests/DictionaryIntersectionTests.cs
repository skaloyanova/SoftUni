using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> d1 = new();
        Dictionary<string, int> d2 = new();

        Dictionary<string, int> result = DictionaryIntersection.Intersect(d1, d2);

        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> d1 = new()
        {
            { "one", 1 },
            { "two", 2 },
        };
        Dictionary<string, int> d2 = new();

        Dictionary<string, int> result = DictionaryIntersection.Intersect(d1, d2);

        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> d1 = new()
        {
            { "one", 1 },
            { "two", 2 },
        };
        Dictionary<string, int> d2 = new()
        {
            { "three", 3},
            { "four", 4 },
        };

        Dictionary<string, int> result = DictionaryIntersection.Intersect(d1, d2);

        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        Dictionary<string, int> d1 = new()
        {
            { "one", 1 },
            { "two", 2 },
        };
        Dictionary<string, int> d2 = new()
        {
            { "three", 3},
            { "two", 2 },
        };
        Dictionary<string, int> expected = new()
        {
            { "two", 2 },
        };


        Dictionary<string, int> result = DictionaryIntersection.Intersect(d1, d2);

        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> d1 = new()
        {
            { "one", 1 },
            { "two", 2 },
        };
        Dictionary<string, int> d2 = new()
        {
            { "one", 3},
            { "two", 4 },
        };

        Dictionary<string, int> result = DictionaryIntersection.Intersect(d1, d2);

        CollectionAssert.IsEmpty(result);
    }
}
