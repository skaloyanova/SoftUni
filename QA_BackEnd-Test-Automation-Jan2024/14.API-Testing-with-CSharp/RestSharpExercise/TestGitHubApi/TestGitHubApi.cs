using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi;

public class TestGitHubApi
{
    private GitHubApiClient client;
    private static string repo;
    private static int lastCreatedIssueNumber;
    private static int lastCreatedCommentId;

    [SetUp]
    public void Setup()
    {
        client = new GitHubApiClient("https://api.github.com/repos/testnakov", "skaloyanova", "");     //<<< put GitHub token here
        repo = "test-nakov-repo";
    }


    [Test, Order(1)]
    public void Test_GetAllIssuesFromARepo()
    {
        //Act
        var issues = client.GetAllIssues(repo);

        //Assert
        Assert.NotNull(issues);
        Assert.That(issues.Count, Is.GreaterThan(1), "There should be more than 1 issue");

        foreach (var issue in issues)
        {
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0.");
            Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty.");
        }
    }

    [Test, Order(2)]
    public void Test_GetIssueByValidNumber()
    {
        //Arrange
        int issueNumber = 1;

        //Act
        var issue = client.GetIssueByNumber(repo, issueNumber);

        //Assert
        Assert.NotNull(issue);
        Assert.That(issue.Number, Is.EqualTo(issueNumber), "Issue Number should match the requested one.");
        Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
        Assert.That(issue.Title, Is.EqualTo("Test creation"));
    }

    [Test, Order(2)]
    public void Test_GetIssueByInValidNumber()
    {
        //Arrange
        int issueNumber = 999999999;

        //Act
        var issue = client.GetIssueByNumber(repo, issueNumber);

        //Assert
        Assert.NotNull(issue);
        Assert.That(issue.Number, Is.EqualTo(0), "Issue Number should be default value 0 for empty Issue object.");
        Assert.That(issue.Id, Is.EqualTo(0), "Issue ID should be default value 0 for empty Issue object.");
        Assert.That(issue.Title, Is.Null, "Issue Title should be default value null for empty Issue object.");
        Assert.That(issue.Body, Is.Null, "Issue Body should be default value null for empty Issue object.");
    }

    [Test, Order(3)]
    public void Test_GetAllLabelsForIssue()
    {
        //Arrange
        int issueNumber = 1;

        //Act
        var labels = client.GetAllLabelsForIssue(repo, issueNumber);

        //Assert
        Assert.IsNotNull(labels);
        Assert.That(labels.Count, Is.GreaterThan(0));

        foreach (var label in labels)
        {
            Assert.That(label.Id, Is.GreaterThan(0));
            Assert.That(label.Name, Is.Not.Empty);

            //Print label details
            Console.WriteLine($"Label Id: {label.Id}; Label Name: {label.Name}");
        }
    }

    [Test, Order(4)]
    public void Test_GetAllCommentsForIssue()
    {
        //Arrange
        int issueNumber = 1;

        //Act
        var comments = client.GetAllCommentsForIssue(repo, issueNumber);

        //Assert
        Assert.IsNotNull(comments);
        Assert.That(comments.Count, Is.GreaterThan(0), "Comments number should be greater than 0.");

        foreach (var comment in comments)
        {
            Assert.That(comment.Id, Is.GreaterThan(0), "Comment ID should be greater than 0.");
            Assert.That(comment.Body, Is.Not.Empty, "Comment Body should not be empty");

            //Print comment
            Console.WriteLine($"Comment Id: {comment.Id}, Body: {comment.Body}");
        }
    }

    [Test, Order(5)]
    public void Test_CreateGitHubIssue()
    {
        //Arrange
        string title = "Issue 1 created for test purpose";
        string body = "Body of issue 1";

        //Act
        var createdIssue = client.CreateIssue(repo, title, body);

        lastCreatedIssueNumber = createdIssue.Number;

        //Assert
        Assert.Multiple(() =>
        {
            Assert.IsNotNull(createdIssue);
            Assert.That(createdIssue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0.");
            Assert.That(createdIssue.Id, Is.GreaterThan(0), "Issue Id should be greater than 0.");
            Assert.That(createdIssue.Title, Is.EqualTo(title));
            Assert.That(createdIssue.Body, Is.EqualTo(body));
        });

        Console.WriteLine(lastCreatedIssueNumber);

    }

    [Test, Order(6)]
    public void Test_CreateCommentOnGitHubIssue()
    {
        //Arrange
        int issueNumber = lastCreatedIssueNumber;
        Assert.That(issueNumber, Is.GreaterThan(0));

        string body = $"This is comment's body for issue {issueNumber}";

        //Act
        var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, body);

        lastCreatedCommentId = comment.Id;

        //Assert
        Assert.IsNotNull(comment);
        Assert.That(comment.Id, Is.GreaterThan(0));
        Assert.That(comment.Body, Is.EqualTo(body));

        Console.WriteLine($"Comment body for issue {issueNumber}: {comment.Body}");
    }

    [Test, Order(7)]
    public void Test_GetCommentById()
    {
        //Arrange
        int commentId = lastCreatedCommentId;
        Assert.That(commentId, Is.GreaterThan(0));

        //Act
        var comment = client.GetCommentById(repo, commentId);

        //Assert
        Assert.IsNotNull(comment);
        Assert.That(comment.Id, Is.EqualTo(commentId));
        Assert.IsNotEmpty(comment.Body);

        Console.WriteLine($"Comment id: {comment.Id}, Comment body: {comment.Body}");
    }


    [Test, Order(8)]
    public void Test_EditCommentOnGitHubIssue()
    {
        //Arrange
        int commentId = lastCreatedCommentId;
        Console.WriteLine(commentId);
        Assert.That(commentId, Is.GreaterThan(0));

        string newBody = "Updated body of the comment";

        //Act
        var comment = client.EditCommentOnGitHubIssue(repo, commentId, newBody);

        //Assert
        Assert.IsNotNull(comment);
        Assert.That(comment.Id, Is.EqualTo(commentId));
        Assert.That(comment.Body, Is.EqualTo(newBody));
    }

    [Test, Order(9)]
    public void Test_DeleteCommentOnGitHubIssue()
    {
        //Arrange
        int commentId = lastCreatedCommentId;
        Assert.That(commentId, Is.GreaterThan(0));

        //Act
        var result = client.DeleteCommentOnGitHubIssue(repo, commentId);

        //Assert
        Assert.IsTrue(result);
    }
}

