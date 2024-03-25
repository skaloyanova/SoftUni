using RestSharp;

var client = new RestClient("https://api.github.com");
var request = new RestRequest("/users/skaloyanova/repos", Method.Get);
var response = client.Execute(request);

Console.WriteLine(response.Content);
Console.WriteLine(response.StatusCode);
Console.WriteLine(string.Join("\n", response.Headers));