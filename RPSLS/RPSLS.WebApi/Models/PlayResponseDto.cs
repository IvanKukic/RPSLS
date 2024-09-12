using RPSLS.Domain.Enums;

namespace RPSLS.WebApi.Models;

public record PlayResponseDto(string Result, HandsignType Player, HandsignType Computer);