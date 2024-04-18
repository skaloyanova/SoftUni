using FoodyApiTests.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace FoodyApiTests;

public class FoodyTests
{
    private const string BASEURL = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:86";
    private RestClient _client;
    private static string _foodId;

    [OneTimeSetUp]
    public void Setup()
    {
        //Get Access token
        string username = "testUser123";
        string password = "parola";
        string token = GetAccessToken(username, password);

        //Setup RestClient
        _client = new RestClient(new RestClientOptions(BASEURL)
        {
            Authenticator = new JwtAuthenticator(token)
        });
    }

    private string GetAccessToken(string username, string password)
    {
        var authClient = new RestClient(BASEURL);
        var authRequest = new RestRequest("/api/User/Authentication", Method.Post);
        authRequest.AddJsonBody(new
        {
            userName = username,
            password = password
        });

        var response = authClient.Execute(authRequest);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = JsonSerializer.Deserialize<JsonElement>(response.Content);

            string? token = content.GetProperty("accessToken").GetString();

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("Access token is null or whitespace");
            }
            else
            {
                return token;
            }
        }
        else
        {
            throw new InvalidOperationException($"Authentication faile: {response.Content}");
        }
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _client.Dispose();
    }

    private string GetRandomFoodName()
    {
        string[] foodArray = ["Pizza", "Pasta", "Beef", "Vegan", "Dessert", "Soup"];
        int randomIndex = new Random().Next(0, foodArray.Length);

        string randomFoodPrefix = foodArray[randomIndex];
        int randomFoodSuffix = new Random().Next(100, 1000);

        return $"{randomFoodPrefix}-{randomFoodSuffix}";
    }


    [Test, Order(1)]
    public void CreateFood_WithCorrectData_ShouldReturnCreated201()
    {
        //Arrange
        var randomFoodName = GetRandomFoodName();
        var newFood = new FoodDto
        {
            Name = randomFoodName,
            Description = $"Description for {randomFoodName}",
            Url = ""
        };

        var request = new RestRequest("/api/Food/Create", Method.Post);
        request.AddJsonBody(newFood);

        //Act
        var response = _client.Execute(request);
        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        _foodId = content.FoodId;

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(content.FoodId, Is.Not.Null);
        });
    }

    [Test, Order(2)]
    public void EditFood_WithCorrectData_ShouldReturnOK200()
    {
        //Arrange
        var request = new RestRequest($"/api/Food/Edit/{_foodId}", Method.Patch);
        var body = new[]
        {
            new
            {
                path = "/name",
                op = "replace",
                value = "UPDATED food name"
            }
        };
        request.AddJsonBody(body);

        //Act
        var response = _client.Execute(request);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

            Assert.That(content.Message, Is.EqualTo("Successfully edited"));
            Assert.That(content.FoodId, Is.EqualTo(_foodId));
        });
    }

    [Test, Order(3)]
    public void GetAllFoods_ShouldReturnNonEmptyArray()
    {
        //Arrange
        var request = new RestRequest("/api/Food/All", Method.Get);

        //Act
        var response = _client.Execute(request);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = JsonSerializer.Deserialize<List<FoodDto>>(response.Content);

            Assert.That(content.Count, Is.GreaterThan(0));
        });
    }

    [Test, Order(4)]
    public void DeleteFood_WithFoodId_ShouldReturnOK200()
    {
        //Arrange
        var request = new RestRequest($"/api/Food/Delete/{_foodId}", Method.Delete);

        //Act
        var response = _client.Execute(request);
        
        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

            Assert.That(content.Message, Is.EqualTo("Deleted successfully!"));
        });

    }

    [Test, Order(5)]
    public void CreateFood_WithMissingFields_ShouldReturnBadRequest400()
    {
        //Arrange
        var newFood = new FoodDto
        {
            Name = "only name",
            Url = ""
        };

        var request = new RestRequest("/api/Food/Create", Method.Post);
        request.AddJsonBody(newFood);

        //Act
        var response = _client.Execute(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

    }

    [Test, Order(6)]
    public void EditFood_WithInvalidFoodId_ShouldReturnNotFound404()
    {
        //Arrange
        var invalidFoodId = "invalid";
        var request = new RestRequest($"/api/Food/Edit/{invalidFoodId}", Method.Patch);
        var body = new[]
        {
            new
            {
                path = "/name",
                op = "replace",
                value = "UPDATED food name"
            }
        };
        request.AddJsonBody(body);

        //Act
        var response = _client.Execute(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        Assert.That(content.Message, Is.EqualTo("No food revues..."));

    }

    [Test, Order(7)]
    public void DeleteFood_WithInvalidFoodId_ShouldReturnNotFound404()
    {
        //Arrange
        var invalidFoodId = "invalid";
        var request = new RestRequest($"/api/Food/Delete/{invalidFoodId}", Method.Delete);

        //Act
        var response = _client.Execute(request);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        var content = JsonSerializer.Deserialize<ApiResponseDto>(response.Content);

        Assert.That(content.Message, Is.EqualTo("No food revues..."));
    }
}