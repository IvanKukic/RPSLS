using MediatR;
using Microsoft.VisualBasic;
using RPSLS.Application.Services;
using RPSLS.Domain.Entities;

namespace RPSLS.Application.Queries.GetRandomChoice;

public class GetRandomChoiceHandler : IRequestHandler<GetRandomChoiceQuery, Handsign>
{

	private readonly RandomNumberHttpService _randomNumberHttpService;

	public GetRandomChoiceHandler(RandomNumberHttpService randomNumberHttpService)
	{
		_randomNumberHttpService = randomNumberHttpService;
	}

	public async Task<Handsign> Handle(GetRandomChoiceQuery request, CancellationToken cancellationToken)
	{
		var number = await _randomNumberHttpService.GetRandomNumber();

		//RNG returns numbers [1-100], to get our values we first mod by 5
		//which gives us values [0-4] and then we add one to be in the desired [1-5] range
		var type  = (number % 5) + 1;
		return new Handsign(type);
	}
}
