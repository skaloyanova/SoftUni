using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep1___RestSharp_API_Tests.Models;

public class IdeaDTO
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}
