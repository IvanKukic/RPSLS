using System.Text.Json.Serialization;

namespace RPSLS.Application.Models;

internal class RandomDto
{
    [JsonPropertyName("random_number")]
    public int RandomNumber { get; init; }
}
