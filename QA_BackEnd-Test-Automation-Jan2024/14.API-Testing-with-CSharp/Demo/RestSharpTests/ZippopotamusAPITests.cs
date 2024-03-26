using Newtonsoft.Json;
using RestSharp;
using RestSharpTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTests;

public class ZippopotamusAPITests
{
    [TestCase("BG", "1000", "Sofija")]
    [TestCase("BG", "4400", "Pazardzhik")]
    [TestCase("CA", "M5S", "Toronto")]
    [TestCase("GB", "B1", "Birmingham")]
    [TestCase("DE", "10115", "Berlin")]
    public void Test_Zippopotamus_GetPlaceNameByPostcode(string countryCode, string postCode, string expectedPlace)
    {
        //Arrange
        var client = new RestClient("https://api.zippopotam.us");
        var request = new RestRequest($"{countryCode}/{postCode}", Method.Get);

        //Act
        var response = client.Execute(request);
        var location = JsonConvert.DeserializeObject<Location>(response.Content);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(location.CountryAbbreviation, Is.EqualTo(countryCode));
        Assert.That(location.Postcode, Is.EqualTo(postCode));
        Assert.That(location.Places[0].PlaceName.Contains(expectedPlace));
    }
}
