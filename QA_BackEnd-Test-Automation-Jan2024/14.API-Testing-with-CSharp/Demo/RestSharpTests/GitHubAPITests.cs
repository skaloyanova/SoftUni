using RestSharp;
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
            MaxTimeout = 3000
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
}