using System.Net;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpServices.Models;

namespace RestSharpServices;

public class GitHubApiClient
{
    private RestClient client;

    public GitHubApiClient(string baseUrl, string username, string token)
    {
        var options = new RestClientOptions(baseUrl)
        {
            Authenticator = new HttpBasicAuthenticator(username, token)
        };

        client = new RestClient(options);
    }

    public List<Issue>? GetAllIssues(string repo)
    {
        var request = new RestRequest($"/{repo}/issues");
        var response = client.Get(request);
        return response.Content != null ? JsonSerializer.Deserialize<List<Issue>>(response.Content) : null;
    }

    public Issue? GetIssueByNumber(string repo, int issueNumber)
    {
        var request = new RestRequest($"/{repo}/issues/{issueNumber}");
        var response = client.Get<Issue>(request);
        return response;
    }

    public Issue? CreateIssue(string repo, string title, string body)
    {
        var request = new RestRequest($"/{repo}/issues");
        request.AddBody(new { title, body });
        var response = client.Post<Issue>(request);
        return response;
    }

    public List<Label>? GetAllLabelsForIssue(string repo, int issueNumber)
    {
        var request = new RestRequest($"/{repo}/issues/{issueNumber}/labels");
        var response = client.Get<List<Label>>(request);
        return response;
    }

    public List<Comment>? GetAllCommentsForIssue(string repo, int issueNumber)
    {
        var request = new RestRequest($"/{repo}/issues/{issueNumber}/comments");
        var response = client.Get(request);
        return response.Content != null ? JsonSerializer.Deserialize<List<Comment>>(response.Content) : null;
    }

    public Comment? CreateCommentOnGitHubIssue(string repo, int issueNumber, string body)
    {
        var request = new RestRequest($"/{repo}/issues/{issueNumber}/comments");
        request.AddBody(new { body });
        var response = client.Post<Comment>(request);
        return response;
    }

    public Comment? GetCommentById (string repo, int commentId)
    {
        var request = new RestRequest($"/{repo}/issues/comments/{commentId}");
        var response = client.Get<Comment>(request);
        return response;
    }

    public Comment? EditCommentOnGitHubIssue( string repo, int commentId, string newBody)
    {
        var request = new RestRequest($"/{repo}/issues/comments/{commentId}");
        request.AddBody(new { body = newBody });
        var response = client.Patch<Comment>(request);
        return response;
    }

    public bool DeleteCommentOnGitHubIssue(string repo, int commentId)
    {
        var request = new RestRequest($"/{repo}/issues/comments/{commentId}");
        var response = client.Delete(request);
        return response.IsSuccessful;
    }

}
