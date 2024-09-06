using RPSLS.Domain.Enums;

namespace RPSLS.Application.Commands.Play;

public record PlayResponse(string Result, ChoiceType PlayerChoice, ChoiceType ComputerChoice);
