using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpTests.Models;
using System.Net;

namespace RestSharpTests;

public class GitHubAPITests
{
    private RestClient client;

    [SetUp]
    public void Setup()
    {
        var options = new RestClientOptions("https://api.github.com")
        {
            Authenticator = new HttpBasicAuthenticator("skaloyanova", "")   // <<< put github api token here
        };

        client = new RestClient(options);
    }

    [Test]
    public void Test_GitHubIssuesAPIGetRequest()
    {
        //Arrange
        var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Get);

        //Act
        var response = client.Get(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public void Test_GetAllIssuesFromRepo()
    {
        //Arrange
        var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Get);

        //Act
        var response = client.Execute(request);
        var issues = JsonConvert.DeserializeObject<List<Issue>>(response.Content);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(issues.Count > 1);

        foreach (var issue in issues)
        {
            Assert.That(issue.Id, Is.GreaterThan(0));
            Assert.That(issue.Number, Is.GreaterThan(0));
            Assert.That(issue.Title, Is.Not.Empty);
        }
    }

    [Test]
    public void Test_CreateGitHubIssue()
    {
        //Arrange
        string title = "Issue created via API 3";
        string body = "Body of the issue create via API";

        //Act
        var issueCreated = CreateIssue(title, body);

        //Assert
        Assert.That(issueCreated.Title, Is.EqualTo(title));
        Assert.That(issueCreated.Body, Is.EqualTo(body));
    }

    [Test]
    public void Test_EditGitHubIssue()
    {
        //Arrange
        string title = "Issue to edit via API 2";
        string body = "Body of the issue to edit via API 2";
        var issue = CreateIssue(title, body);

        //Act
        var updateRequest = new RestRequest($"/repos/testnakov/test-nakov-repo/issues/{issue.Number}", Method.Patch);
        string updatedBody = "UPDATED body 2";
        string updatedTitle = "UPDATED title 2";
        updateRequest.AddJsonBody(new {
            title = updatedTitle,
            body = updatedBody });

        var response = client.Execute(updateRequest);
        var updatedIssue = JsonConvert.DeserializeObject<Issue>(response.Content);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(updatedIssue.Number, Is.EqualTo(issue.Number));
        Assert.That(updatedIssue.Title, Is.EqualTo(updatedTitle));
        Assert.That(updatedIssue.Body, Is.EqualTo(updatedBody));
    }

    private Issue CreateIssue(string title, string body)
    {
        var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Post);
        request.AddBody(new { title, body });
        var response = client.Execute(request);
        var issueObject = JsonConvert.DeserializeObject<Issue>(response.Content);

        return issueObject;
    }
}