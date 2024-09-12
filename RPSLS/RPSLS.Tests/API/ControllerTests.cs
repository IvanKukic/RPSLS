using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RPSLS.Application.Commands.Play;
using RPSLS.Application.Queries.GetRandomChoice;
using RPSLS.Domain.Enums;
using RPSLS.WebApi.Controllers;
using RPSLS.WebApi.Models;

public class GameControllerTests
{
	private readonly Mock<IMediator> _mediatorMock;
	private readonly GameController _controller;

	public GameControllerTests()
	{
		_mediatorMock = new Mock<IMediator>();
		_controller = new GameController(_mediatorMock.Object);
	}

	[Fact]
	public void ListChoices_ShouldReturnAllChoices()
	{
		// Act
		var result = _controller.ListChoices() as OkObjectResult;

		// Assert
		Assert.NotNull(result);
		Assert.Equal(200, result.StatusCode);

		var choices = result.Value as IEnumerable<Handsign>;
		Assert.NotNull(choices);
		Assert.Equal(5, choices.Count());
		Assert.Contains(choices, c => c.Id == HandsignType.Rock);
		Assert.Contains(choices, c => c.Id == HandsignType.Paper);
		Assert.Contains(choices, c => c.Id == HandsignType.Scissors);
		Assert.Contains(choices, c => c.Id == HandsignType.Lizard);
		Assert.Contains(choices, c => c.Id == HandsignType.Spock);
	}

	[Fact]
	public async Task GetChoice_ShouldReturnRandomChoice()
	{
		// Arrange
		var expectedChoice = new RPSLS.Domain.Entities.Handsign((int)HandsignType.Spock);
		_mediatorMock.Setup(m => m.Send(It.IsAny<GetRandomChoiceQuery>(), default)).Returns(Task.FromResult(expectedChoice));

		// Act
		var result = await _controller.GetChoice() as OkObjectResult;

		// Assert
		Assert.NotNull(result);
		Assert.Equal(200, result.StatusCode);

		var choice = result.Value as RPSLS.Domain.Entities.Handsign;
		Assert.NotNull(choice);
		Assert.Equal(expectedChoice.HandsignType, choice.HandsignType);
	}

	[Fact]
	public async Task Play_ShouldReturnPlayResponseDto()
	{
		// Arrange
		var playCommand = new PlayCommand(HandsignType.Rock);
		var playResponse = new PlayResponse("win", HandsignType.Rock, HandsignType.Scissors);
		_mediatorMock.Setup(m => m.Send(playCommand, default))
			.ReturnsAsync(playResponse);

		var playRequest = new PlayRequestDto(HandsignType.Rock);

		// Act
		var result = await _controller.Play(playRequest) as OkObjectResult;

		// Assert
		Assert.NotNull(result);
		Assert.Equal(200, result.StatusCode);

		var responseDto = result.Value as PlayResponseDto;
		Assert.NotNull(responseDto);
		Assert.Equal(playResponse.Result, responseDto.Result);
		Assert.Equal(playResponse.PlayerChoice, responseDto.Player);
		Assert.Equal(playResponse.ComputerChoice, responseDto.Computer);
	}
}
