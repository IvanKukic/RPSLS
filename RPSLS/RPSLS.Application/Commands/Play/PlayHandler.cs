using MediatR;
using RPSLS.Application.Services;
using RPSLS.Domain.Enums;
using RPSLS.Domain.Logic;

namespace RPSLS.Application.Commands.Play;

public class PlayHandler : IRequestHandler<PlayCommand, PlayResponse>
{
	private readonly RandomNumberHttpService _randomNumberHttpService;

	public PlayHandler(RandomNumberHttpService randomNumberHttpService)
	{
		_randomNumberHttpService = randomNumberHttpService;
	}

	public async Task<PlayResponse> Handle(PlayCommand request, CancellationToken cancellationToken)
	{
		var number = await _randomNumberHttpService.GetRandomNumber();
		HandsignType computerChoice = (HandsignType)((number % 5) + 1);
		var gameResult = GameLogic.DetermineWinner(request.Player, computerChoice);
		return new PlayResponse(gameResult, request.Player, computerChoice);
	}
}
