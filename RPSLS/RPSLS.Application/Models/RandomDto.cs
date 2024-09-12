using System.Text.Json.Serialization;

namespace RPSLS.Application.Models;

public class RandomDto
{
    [JsonPropertyName("random_number")]
    public int RandomNumber { get; init; }
}
