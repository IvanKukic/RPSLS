using MediatR;
using RPSLS.Domain.Enums;

namespace RPSLS.Application.Commands.Play;

public record PlayCommand(HandsignType Player) : IRequest<PlayResponse>;
