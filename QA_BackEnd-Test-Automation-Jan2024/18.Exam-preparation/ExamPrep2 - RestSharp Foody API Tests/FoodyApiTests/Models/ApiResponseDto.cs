using System.Text.Json.Serialization;

namespace FoodyApiTests.Models;

public class ApiResponseDto
{
    [JsonPropertyName("msg")]
    public string? Message { get; set; }

    [JsonPropertyName("foodId")]
    public string? FoodId { get; set; }
}
