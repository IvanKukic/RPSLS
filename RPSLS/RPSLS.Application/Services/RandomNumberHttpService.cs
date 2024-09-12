using RPSLS.Application.Models;
using System.Text.Json;

namespace RPSLS.Application.Services;

public class RandomNumberHttpService
{
    private readonly HttpClient _httpClient;

	public RandomNumberHttpService(IHttpClientFactory httpClientFactory)
	{
		_httpClient = httpClientFactory.CreateClient(nameof(RandomNumberHttpService));
	}

	public async Task<int> GetRandomNumber()
	{
		var response = await _httpClient.GetAsync("/random");

        var responseData = await JsonSerializer.DeserializeAsync<RandomDto>(response.Content.ReadAsStream());

		return responseData!.RandomNumber;
	}
}
