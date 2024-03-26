using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTests.Models;

public class Location
{
    [JsonProperty("post code")]
    public string Postcode { get; set; }
    public string Country { get; set; }

    [JsonProperty("country abbreviation")]
    public string CountryAbbreviation { get; set; }
    public List<Place> Places { get; set; }
}
