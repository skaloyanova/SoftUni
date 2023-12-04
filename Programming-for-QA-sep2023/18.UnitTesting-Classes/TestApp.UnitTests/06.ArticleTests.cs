using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void Setup()
    {
        this._article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articlesInput = {
            "Article1 Content1 Author1",
            "Article2 Content2 Author2",
            "Article3 Content3 Author3",
        };

        // Act
        Article result = _article.AddArticles(articlesInput);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article1"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_AddArticles_ReturnsNull_WhenNoDataIsGiven()
    {
        // Arrange
        string[] articlesInput = { };

        // Act
        Article result = _article.AddArticles(articlesInput);

        // Assert
        Assert.That(result.Title, Is.Null);
        Assert.That(result.Author, Is.Null);
        Assert.That(result.Content, Is.Null);
        CollectionAssert.IsEmpty(result.ArticleList);
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        //Arrange
        Article input = new()
        {
            ArticleList = {
                new Article () {Title = "Z-Article", Content = "Content-P", Author = "Au-T-thor"},
                new Article () {Title = "A-Article", Content = "Content-Z", Author = "Au-H-thor"},
                new Article () {Title = "K-Article", Content = "Content-A", Author = "Au-O-thor"},
                new Article () {Title = "S-Article", Content = "Content-O", Author = "Au-R-thor"},
            }
        };

        string expected =
            $"A-Article - Content-Z: Au-H-thor{Environment.NewLine}" +
            $"K-Article - Content-A: Au-O-thor{Environment.NewLine}" +
            $"S-Article - Content-O: Au-R-thor{Environment.NewLine}" +
            $"Z-Article - Content-P: Au-T-thor";

        //Act
        string result = _article.GetArticleList(input, "title");

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByContent()
    {
        //Arrange
        Article input = new()
        {
            ArticleList = {
                new Article () {Title = "Z-Article", Content = "Content-P", Author = "Au-T-thor"},
                new Article () {Title = "A-Article", Content = "Content-Z", Author = "Au-H-thor"},
                new Article () {Title = "K-Article", Content = "Content-A", Author = "Au-O-thor"},
                new Article () {Title = "S-Article", Content = "Content-O", Author = "Au-R-thor"},
            }
        };
        string expected =
            $"K-Article - Content-A: Au-O-thor{Environment.NewLine}" +
            $"S-Article - Content-O: Au-R-thor{Environment.NewLine}" +
            $"Z-Article - Content-P: Au-T-thor{Environment.NewLine}" +
            $"A-Article - Content-Z: Au-H-thor";

        //Act
        string result = _article.GetArticleList(input, "content");

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByAuthor()
    {
        //Arrange
        Article input = new()
        {
            ArticleList = {
                new Article () {Title = "Z-Article", Content = "Content-P", Author = "Au-T-thor"},
                new Article () {Title = "A-Article", Content = "Content-Z", Author = "Au-H-thor"},
                new Article () {Title = "K-Article", Content = "Content-A", Author = "Au-O-thor"},
                new Article () {Title = "S-Article", Content = "Content-O", Author = "Au-R-thor"},
            }
        };
        string expected =
            $"A-Article - Content-Z: Au-H-thor{Environment.NewLine}" +
            $"K-Article - Content-A: Au-O-thor{Environment.NewLine}" +
            $"S-Article - Content-O: Au-R-thor{Environment.NewLine}" +
            $"Z-Article - Content-P: Au-T-thor";

        //Act
        string result = _article.GetArticleList(input, "author");

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        //Arrange
        Article input = new()
        {
            ArticleList = {
                new Article () {Title = "Z-Article", Content = "Content-P", Author = "Au-T-thor"},
                new Article () {Title = "A-Article", Content = "Content-Z", Author = "Au-H-thor"},
                new Article () {Title = "K-Article", Content = "Content-A", Author = "Au-O-thor"},
                new Article () {Title = "S-Article", Content = "Content-O", Author = "Au-R-thor"},
            }
        };

        //Act
        string result = _article.GetArticleList(input, "something");

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenNoDataIsGiven()
    {
        //Arrange
        Article input = new()
        {
            ArticleList = new()
        };

        //Act
        string result = _article.GetArticleList(input, "title");

        //Assert
        Assert.That(result, Is.Empty);
    }
}
