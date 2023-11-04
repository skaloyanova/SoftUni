using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class ExtractFileTests
{
    [Test]
    public void Test_GetFile_NullPath_ThrowsArgumentNullException()
    {
        string? input = null;

        Assert.That(() => ExtractFile.GetFile(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_GetFile_EmptyPath_ThrowsArgumentNullException()
    {
        string input = string.Empty;

        Assert.That(() => ExtractFile.GetFile(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_GetFile_ValidPath_ReturnsFileNameAndExtension()
    {
        string input = "c:\\abc\\test.exe";

        string result = ExtractFile.GetFile(input);

        Assert.That(result, Is.EqualTo("File name: test\nFile extension: exe"));
    }

    [Test]
    public void Test_GetFile_PathWithNoExtension_ReturnsFileNameOnly()
    {
        string input = "c:\\abc\\test";

        string result = ExtractFile.GetFile(input);

        Assert.That(result, Is.EqualTo("File name: test"));
    }

    [Test]
    public void Test_GetFile_PathWithSpecialCharacters_ReturnsFileNameAndExtension()
    {
        string input = "c:\\abcd\\t@est+.csv";

        string result = ExtractFile.GetFile(input);

        Assert.That(result, Is.EqualTo("File name: t@est+\nFile extension: csv"));
    }
}
