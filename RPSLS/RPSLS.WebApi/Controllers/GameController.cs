using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPSLS.Application.Commands.Play;
using RPSLS.Application.Queries.GetRandomChoice;
using RPSLS.Domain.Enums;
using RPSLS.WebApi.Models;

namespace RPSLS.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
            _mediator = mediator;
    }

    /// <summary>
    /// Get list of possible choices (possibly)
    /// </summary>
    /// <returns>List of choices</returns>
    [HttpGet("choices")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Handsign>), StatusCodes.Status200OK)]
    public IActionResult ListChoices()
    {
        List<Handsign> result =
        [
            Handsign.CreateFromEnumType(HandsignType.Rock),
            Handsign.CreateFromEnumType(HandsignType.Paper),
            Handsign.CreateFromEnumType(HandsignType.Scissors),
            Handsign.CreateFromEnumType(HandsignType.Lizard),
            Handsign.CreateFromEnumType(HandsignType.Spock)
        ];

        return Ok(result);
    }

    /// <summary>
    /// Get a random choice
    /// </summary>
    /// <returns>Choice</returns>
    [HttpGet("choice")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Handsign), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetChoice()
    {
        var result = await _mediator.Send(new GetRandomChoiceQuery(), default);
        return Ok(result);
    }

    [HttpPost("play")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(PlayResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Play([FromBody] PlayRequestDto request)
    {
        var result = await _mediator.Send(new PlayCommand(request.Player));
        var response = new PlayResponseDto(result.Result, result.PlayerChoice, result.ComputerChoice);
        return Ok(response);
    }
}
