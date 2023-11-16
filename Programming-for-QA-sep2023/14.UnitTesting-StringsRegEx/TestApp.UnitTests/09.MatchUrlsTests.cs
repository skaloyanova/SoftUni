using NUnit.Framework;

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    // Regex: https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&=]*)

    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        string input = "";

        List<string> result = MatchUrls.ExtractUrls(input);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        string input = "text with no urls https:// sdddd.com";
        
        List<string> result = MatchUrls.ExtractUrls(input);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        string input = "single url https://linkon.biz opa";
        List<string> expected = new List<string>() { "https://linkon.biz" };

        List<string> result = MatchUrls.ExtractUrls(input);

        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        string input = "valid url https://linkon.biz another onehttps://aaaa.abv.bg http://wwww.alabala.co.uk invalid htt://abv.bg ://test.";
        List<string> expected = new List<string>() { "https://linkon.biz", "https://aaaa.abv.bg", "http://wwww.alabala.co.uk" };

        List<string> result = MatchUrls.ExtractUrls(input);

        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInTheQuotationMarks()
    {
        string input = "\"https://wwww.linkon.biz\" \"https://www.opa.la.bg\"";
        List<string> expected = new List<string>() { "https://wwww.linkon.biz", "https://www.opa.la.bg" };

        List<string> result = MatchUrls.ExtractUrls(input);

        CollectionAssert.AreEqual(expected, result);
    }
}
