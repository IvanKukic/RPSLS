using MediatR;
using RPSLS.Domain.Enums;

namespace RPSLS.Application.Commands.Play;

public record PlayCommand(ChoiceType Player) : IRequest<PlayResponse>;
