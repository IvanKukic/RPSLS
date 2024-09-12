using RPSLS.Application.Interfaces;
using RPSLS.Application.Models;
using System.Net;
using System.Text.Json;

namespace RPSLS.Application.Services;

public class RandomNumberHttpService : IRandomNumberHttpService
{
    private readonly HttpClient _httpClient;

	public RandomNumberHttpService(IHttpClientFactory httpClientFactory)
	{
		_httpClient = httpClientFactory.CreateClient(nameof(RandomNumberHttpService));
	}

	public async Task<int> GetRandomNumber()
	{
		try
		{
			var response = await _httpClient.GetAsync("/random");

			response.EnsureSuccessStatusCode();
			var responseData = await JsonSerializer.DeserializeAsync<RandomDto>(response.Content.ReadAsStream());

			return responseData!.RandomNumber;
		}
		catch(Exception ex)
		{
			//TODO: set up serilog for more robust logging
			Console.WriteLine(ex.Message);
			return new Random().Next(1, 100);
		}
	}
}
