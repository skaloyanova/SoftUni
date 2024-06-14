using RestSharp.Authenticators;
using RestSharp;
using System.Net;
using System.Text.Json;
using StorySpoilApiTests.Models;

namespace StorySpoilApiTests;

public class StorySpoilTests
{
    private const string BASEURL = "https://d5wfqm7y6yb3q.cloudfront.net";
    private RestClient _client;
    private static string _storyId;

    [OneTimeSetUp]
    public void Setup()
    {
        //Get Access Token
        string accessToken = GetJwtToken("userStanislava", "parola");

        //Setup Rest Client with JWT authenticator
        _client = new RestClient(new RestClientOptions(BASEURL)
        {
            Authenticator = new JwtAuthenticator(accessToken)
        });
    }

    private string GetJwtToken(string username, string password)
    {
        var authClient = new RestClient(BASEURL);

        var authRequest = new RestRequest("/api/User/Authentication", Method.Post);
        authRequest.AddJsonBody(new
        {
            userName = username,
            password

        });
        var authResponse = authClient.Execute(authRequest);

        if (authResponse.StatusCode == HttpStatusCode.OK)
        {
            var content = JsonSerializer.Deserialize<JsonElement>(authResponse.Content);
            var token = content.GetProperty("accessToken").GetString();

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

    private string GetRandomStoryTitle()
    {
        string[] storyArray = new[] { "City", "Animal", "Music", "Movie", "Book" };
        int randomIndex = new Random().Next(0, storyArray.Length);

        string randomStoryPrefix = storyArray[randomIndex];
        int randomStorySuffix = new Random().Next(100, 1000);

        return $"{randomStoryPrefix}-{randomStorySuffix}";
    }

    [Test]
    [Order(1)]
    public void CreateStorySpoiler_WithCorrectRequestData_ShouldBeSuccessful()
    {
        //Arrange
        string title = GetRandomStoryTitle();
        var story = new StoryDto
        {
            Title = title,
            Description = $"Description for {title}",
            Url = ""
        };

        var request = new RestRequest("/api/Story/Create", Method.Post);
        request.AddJsonBody(story);

        //Act
        var response = _client.Execute(request);
        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.IsNotNull(content.StoryId);
            Assert.That(content.Message, Is.EqualTo("Successfully created!"));
        });

        //Store the StoryId as a static member of the test class  
        _storyId = content.StoryId;
    }

    [Test]
    [Order(2)]
    public void EditStory_WithCorrectRequestData_ShouldBeSucessful()
    {
        //Arrange
        var editedStory = new StoryDto
        {
            Title = "Edited title",
            Description = "Edited description"
        };

        var request = new RestRequest($"/api/Story/Edit/{_storyId}", Method.Put);
        request.AddJsonBody(editedStory);

        //Act
        var response = _client.Execute(request);
        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(content.Message, Is.EqualTo("Successfully edited"));
            Assert.That(content.StoryId, Is.EqualTo(_storyId));
        });
    }

    [Test]
    [Order(3)]
    public void DeletetStory_WithCorrectRequestData_ShouldBeSucessful()
    {
        //Arrange
        var request = new RestRequest($"/api/Story/Delete/{_storyId}", Method.Delete);

        //Act
        var response = _client.Execute(request);
        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(content.Message, Is.EqualTo("Deleted successfully!"));
        });
    }

    [Test]
    [Order(4)]
    public void CreateStorySpoiler_WithMissingTitle_ShouldReturnBadRequest400()
    {
        //Arrange
        var invalidStory = new StoryDto
        {
            Description = "Required Title field is missing",
            Url = ""
        };

        var request = new RestRequest("/api/Story/Create", Method.Post);
        request.AddJsonBody(invalidStory);

        //Act
        var response = _client.Execute(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    [Order(5)]
    public void CreateStorySpoiler_WithMissingDescription_ShouldReturnBadRequest400()
    {
        //Arrange
        var invalidStory = new StoryDto
        {
            Title = "Required Description field is missing",
            Url = ""
        };

        var request = new RestRequest("/api/Story/Create", Method.Post);
        request.AddJsonBody(invalidStory);

        //Act
        var response = _client.Execute(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    [Order(6)]
    public void EditStory_WithInvalidStoryId_ShouldReturnNotFound404()
    {
        //Arrange
        var editedStory = new StoryDto
        {
            Title = "Edited title",
            Description = "Edited description"
        };

        string invalidStoryId = "0-1-2-3";

        var request = new RestRequest($"/api/Story/Edit/{invalidStoryId}", Method.Put);
        request.AddJsonBody(editedStory);

        //Act
        var response = _client.Execute(request);
        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(content.Message, Is.EqualTo("No spoilers..."));
        });
    }

    [Test]
    [Order(7)]
    public void DeletetStory_WithInvalidStoryId_ShouldReturnBadRequest400()
    {
        //Arrange
        string invalidStoryId = "0-1-2-3";
        var request = new RestRequest($"/api/Story/Delete/{invalidStoryId}", Method.Delete);

        //Act
        var response = _client.Execute(request);
        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(content.Message, Is.EqualTo("Unable to delete this story spoiler!"));
        });
    }
}