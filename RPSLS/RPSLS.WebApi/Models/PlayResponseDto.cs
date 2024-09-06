using RPSLS.Domain.Enums;

namespace RPSLS.WebApi.Models;

public record PlayResponseDto(string Results, ChoiceType Player, ChoiceType Computer);