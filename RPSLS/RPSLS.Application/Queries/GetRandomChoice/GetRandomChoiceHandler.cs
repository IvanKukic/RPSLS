using MediatR;
using RPSLS.Application.Interfaces;
using RPSLS.Domain.Entities;

namespace RPSLS.Application.Queries.GetRandomChoice;

public class GetRandomChoiceHandler : IRequestHandler<GetRandomChoiceQuery, Handsign>
{

	private readonly IRandomNumberHttpService _randomNumberHttpService;

	public GetRandomChoiceHandler(IRandomNumberHttpService randomNumberHttpService)
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
