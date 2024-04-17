using ExamPrep1___RestSharp_API_Tests.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace ExamPrep1___RestSharp_API_Tests;

public class IdeaCenterApiTests
{
    private const string BASEURL = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:84";

    private RestClient _client;
    private static string _lastIdeaId;

    [OneTimeSetUp]
    public void Setup()
    {
        //Get Access Token
        string email = "testUser123@example.com";
        string password = "parola";
        string jwtToken = GetJwtToken(email, password);

        //Setup Rest Client
        _client = new RestClient(new RestClientOptions(BASEURL)
        {
            Authenticator = new JwtAuthenticator(jwtToken)
        });
    }

    private string GetJwtToken(string email, string password)
    {
        var authClient = new RestClient(BASEURL);

        var authRequest = new RestRequest("/api/User/Authentication", Method.Post);
        authRequest.AddJsonBody(new
        {
            email,
            password

        });
        var authResponse = authClient.Execute(authRequest);

        if (authResponse.StatusCode == HttpStatusCode.OK)
        {
            var user = JsonConvert.DeserializeObject<UserDTO>(authResponse.Content);
            var token = user.AccessToken;

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("Access token is null or whitespace");
            }
            return token;
        }
        else
        {
            throw new InvalidOperationException($"Authentication failed: {authResponse.Content}");
        }
    }

    [Test]
    [Order(1)]
    public async Task CreateNewIdea_WithValidData_ShouldReturnStatusCodeOK()
    {
        //Arrange
        string title = "Idea-" + new Random().Next(100, 1000);
        string description = $"Description for {title}";

        var request = new RestRequest("/api/Idea/Create", Method.Post);
        request.AddJsonBody(new
        {
            title = title,
            url = "",
            description = description
        });

        //Act
        var response = await _client.ExecuteAsync(request);
        var responseObject = JsonConvert.DeserializeObject<ApiResponseDTO>(response.Content);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseObject.Message, Is.EqualTo("Successfully created!"));
            Assert.That(responseObject.Idea.Title, Is.EqualTo(title));
            Assert.That(responseObject.Idea.Description, Is.EqualTo(description));
        });
    }

    [Test]
    [Order(2)]
    public async Task GetAllIdeas_ShouldReturnNonEmptyArray()
    {
        //Arrange
        var request = new RestRequest("/api/Idea/All", Method.Get);

        //Act
        var response = await _client.ExecuteAsync(request);

        var responseObjectList = JsonConvert.DeserializeObject<List<ApiResponseDTO>>(response.Content);
        _lastIdeaId = responseObjectList.Last().IdeaId;

        //Assert
        Console.WriteLine(responseObjectList.Count);
        Console.WriteLine(_lastIdeaId);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotEmpty(responseObjectList);
        });
    }

    [Test]
    [Order(3)]
    public async Task EditLastCreatedIdea_WithValidData_ShouldReturnStatusCodeOK()
    {
        //Arrange
        string title = "Title updated";
        string description = "Description updated";

        var request = new RestRequest("/api/Idea/Edit", Method.Put);
        request.AddQueryParameter("ideaId", _lastIdeaId);
        request.AddJsonBody(new
        {
            title,
            description
        });

        //Act
        var response = await _client.ExecuteAsync(request);

        var responseObject = JsonConvert.DeserializeObject<ApiResponseDTO>(response.Content);

        //Assert

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseObject.Message, Is.EqualTo("Edited successfully"));
            Assert.That(responseObject.Idea.Title, Is.EqualTo(title));
            Assert.That(responseObject.Idea.Description, Is.EqualTo(description));
        });
    }

    [Test]
    [Order(4)]
    public async Task DeleteLastEditedIdea_WithValidIdeaIdt_ShouldReturnStatusCodeOK()
    {
        //Arrange
        var request = new RestRequest("/api/Idea/Delete", Method.Delete);
        request.AddQueryParameter("ideaId", _lastIdeaId);

        //Act
        var response = await _client.ExecuteAsync(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Contains.Substring("The idea is deleted!"));
        //Assert.That(response.Content, Is.EqualTo("\"The idea is deleted!\""));
    }

    [Test]
    [Order(5)]
    public async Task CreateNewIdea_WithMissingRequiredFields_ShouldReturnBadRequest400()
    {
        //Arrange
        var request = new RestRequest("/api/Idea/Create", Method.Post);
        request.AddJsonBody(new
        {
            url = ""
        });

        //Act
        var response = await _client.ExecuteAsync(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

    }

    [Test]
    [Order(6)]
    public async Task EditIdea_WithInvalidIdeaId_ShouldReturnBadRequest400()
    {
        //Arrange
        var request = new RestRequest("/api/Idea/Edit", Method.Put);
        request.AddQueryParameter("ideaId", "unknownId");
        request.AddJsonBody(new
        {
            title = "edited title",
            description = "edited description"
        });

        //Act
        var response = await _client.ExecuteAsync(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(response.Content, Is.EqualTo("\"There is no such idea!\""));
    }

    [Test]
    [Order(7)]
    public async Task DeleteIdea_WithInvalidIdeaId_ShouldReturnBadRequest400()
    {
        //Arrange
        var request = new RestRequest("/api/Idea/Delete", Method.Delete);
        request.AddQueryParameter("ideaId", "unknownId");

        //Act
        var response = await _client.ExecuteAsync(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(response.Content, Does.Contain("There is no such idea!"));
        //Assert.That(response.Content, Is.EqualTo("\"There is no such idea!\""));
    }
}