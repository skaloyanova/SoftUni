using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep1___RestSharp_API_Tests.Models;

public class ApiResponseDTO
{
    [JsonProperty("msg")]
    public string? Message { get; set; }

    [JsonProperty("idea")]
    public IdeaDTO? Idea { get; set; }

    [JsonProperty("id")]
    public string? IdeaId { get; set; }
}
