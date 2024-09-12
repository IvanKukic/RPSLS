using RPSLS.Domain.Enums;

namespace RPSLS.WebApi.Models;

public record PlayResponseDto(string Results, HandsignType Player, HandsignType Computer);