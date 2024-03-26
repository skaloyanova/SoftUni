using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpDemo;
using System.Security.AccessControl;

/*************************************
 * Executing simple HTTP GET request *
 *************************************/

var client1 = new RestClient("https://api.github.com");
var request1 = new RestRequest("/users/skaloyanova/repos", Method.Get);
var response1 = client1.Execute(request1);

Console.WriteLine("<<< Executing simple HTTP GET request >>>");
Console.WriteLine(response1.StatusCode);
Console.WriteLine(response1.Content);
Console.WriteLine(string.Join("\n", response1.Headers));

/********************************
 * Using URL Segment Parameters *
 ********************************/

var client2 = new RestClient("https://api.github.com");
var request2 = new RestRequest("/repos/{user}/{repo}/issues/{id}", Method.Get);

request2.AddUrlSegment("user", "testnakov");
request2.AddUrlSegment("repo", "test-nakov-repo");
request2.AddUrlSegment("id", 1);

var response2 = client2.Execute(request2);

Console.WriteLine("<<< Executing HTTP GET request using URL Segment Parameters >>>");
Console.WriteLine(response2.StatusCode);
Console.WriteLine(response2.Content);

/********************************
 * Deserializing JSON Responses *
 ********************************/

var client3 = new RestClient("https://api.github.com");
var request3 = new RestRequest("/users/softuni/repos", Method.Get);
var response3 = client3.Execute(request3);

var repoObjects = JsonConvert.DeserializeObject<List<Repo>>(response3.Content);

Console.WriteLine(string.Join("\n", repoObjects));

/*********************
 * HTTP POST Request *
 *********************/

var client4 = new RestClient(new RestClientOptions("https://api.github.com")
{
    Authenticator = new HttpBasicAuthenticator("skaloyanova", "") // <<< put github token here
});

var request4 = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Post);
request4.AddHeader("Content-Type", "application/json");
request4.AddJsonBody(new { title = "Write some title of the issue", body = "Body/Description of the issue" });

var response4 = client4.Execute(request4);

Console.WriteLine(response4.StatusCode);

