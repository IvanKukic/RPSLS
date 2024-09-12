using Moq;
using RPSLS.Application.Commands.Play;
using RPSLS.Application.Interfaces;
using RPSLS.Domain.Enums;

namespace RPSLS.Tests.Application;

public class PlayHandlerTests
{
	private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new Mock<IHttpClientFactory>();

	[Fact]
	public async Task Handle_ShouldReturnWin_WhenPlayerWins()
	{
		// Arrange
		var randomNumberServiceMock = new Mock<IRandomNumberHttpService>();
		randomNumberServiceMock.Setup(x => x.GetRandomNumber()).ReturnsAsync(5); // Mock a random number

		var playHandler = new PlayHandler(randomNumberServiceMock.Object);

		var playCommand = new PlayCommand(HandsignType.Paper);

		// Act
		var response = await playHandler.Handle(playCommand, CancellationToken.None);

		// Assert
		Assert.Equal("win", response.Result); // Based on mocked random number
		Assert.Equal(HandsignType.Paper, response.PlayerChoice); // The player choice should be Paper
		Assert.Equal(HandsignType.Rock, response.ComputerChoice); // Based on the mocked random number (5 % 5) + 1 = 1 => Rock
	}

	[Fact]
	public async Task Handle_ShouldReturnLose_WhenComputerWins()
	{
		// Arrange
		var randomNumberServiceMock = new Mock<IRandomNumberHttpService>();
		randomNumberServiceMock.Setup(x => x.GetRandomNumber()).ReturnsAsync(5); // Mock a random number that makes computer win

		var playHandler = new PlayHandler(randomNumberServiceMock.Object);

		var playCommand = new PlayCommand(HandsignType.Scissors);

		// Act
		var response = await playHandler.Handle(playCommand, CancellationToken.None);

		// Assert
		Assert.Equal("lose", response.Result); // Based on the mocked random number (Rock beats Scissors)
		Assert.Equal(HandsignType.Scissors, response.PlayerChoice);
		Assert.Equal(HandsignType.Rock, response.ComputerChoice); // Based on the mocked random number (5 % 5) + 1 = Rock
	}

	[Fact]
	public async Task Handle_ShouldReturnTie_WhenBothChoicesAreTheSame()
	{
		// Arrange
		var randomNumberServiceMock = new Mock<IRandomNumberHttpService>();
		randomNumberServiceMock.Setup(x => x.GetRandomNumber()).ReturnsAsync(6); // Mock a random number that results in a tie

		var playHandler = new PlayHandler(randomNumberServiceMock.Object);

		var playCommand = new PlayCommand(HandsignType.Paper);

		// Act
		var response = await playHandler.Handle(playCommand, CancellationToken.None);

		// Assert
		Assert.Equal("tie", response.Result); // Both player and computer choose Paper
		Assert.Equal(HandsignType.Paper, response.PlayerChoice);
		Assert.Equal(HandsignType.Paper, response.ComputerChoice); // Based on the mocked random number (6 % 5) + 1 = Paper
	}
}
