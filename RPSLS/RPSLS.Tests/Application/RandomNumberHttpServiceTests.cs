using Moq;
using Moq.Protected;
using RPSLS.Application.Models;
using RPSLS.Application.Services;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RPSLS.Tests.Application;

public class RandomNumberHttpServiceTests
{
	private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
	private readonly Mock<HttpMessageHandler> _handlerMock;
	private readonly HttpClient _httpClient;
	private readonly RandomNumberHttpService _service;

	public RandomNumberHttpServiceTests()
	{
		_handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
		_httpClient = new HttpClient(_handlerMock.Object);
		_httpClient.BaseAddress = new Uri("https://www.test.com");
		_httpClientFactoryMock = new Mock<IHttpClientFactory>();
		_httpClientFactoryMock.Setup(f => f.CreateClient(nameof(RandomNumberHttpService)))
			.Returns(_httpClient);
		_service = new RandomNumberHttpService(_httpClientFactoryMock.Object);
	}

	[Fact]
	public async Task GetRandomNumber_ShouldReturnRandomNumber_WhenResponseIsSuccessful()
	{
		// Arrange
		RandomDto randomDto = new RandomDto { RandomNumber = 42};
		var jsonResponse = JsonSerializer.Serialize(randomDto);
		var content = new StringContent(jsonResponse, System.Text.Encoding.UTF8, MediaTypeHeaderValue.Parse("application/json"));

		_handlerMock.Protected()
			.Setup<Task<HttpResponseMessage>>("SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>())
			.ReturnsAsync(new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = content
			});

		// Act
		var result = await _service.GetRandomNumber();

		// Assert
		Assert.Equal(42, result);
	}

	[Fact]
	public async Task GetRandomNumber_ShouldReturnRandomNumber_WhenExceptionOccurs()
	{
		// Arrange
		_handlerMock.Protected()
			.Setup<Task<HttpResponseMessage>>("SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>())
			.ThrowsAsync(new HttpRequestException("Network error"));

		// Act
		var result = await _service.GetRandomNumber();

		// Assert
		Assert.InRange(result, 1, 100); // Ensure it falls within the fallback range
	}
}