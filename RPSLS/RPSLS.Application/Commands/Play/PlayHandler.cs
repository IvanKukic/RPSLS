using MediatR;
using RPSLS.Application.Services;
using RPSLS.Domain.Enums;

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
		//TODO: create logic to cover core game functionality
		var number = await _randomNumberHttpService.GetRandomNumber();
		ChoiceType computerChoice = (ChoiceType)((number % 5) + 1);
		return new PlayResponse((computerChoice == request.Player).ToString(), request.Player, computerChoice);
	}
}
