using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTests.Models;

public class Place
{
    [JsonProperty("place name")]
    public string PlaceName { get; set; }
    public string Longitude { get; set; }
    public string State { get; set; }

    [JsonProperty("state abbreviation")]
    public string StateAbbreviation { get; set; }
    public string Latitude { get; set; }
}
