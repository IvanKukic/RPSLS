using RPSLS.Domain.Enums;

namespace RPSLS.WebApi.Models;

//Probably unneccesary to have DTOs, but better to not leak domain models through the API
public record ChoiceDto(ChoiceType Id, string Name)
{    
    public static ChoiceDto CreateFromEnumType(ChoiceType type)
    {
        //ToLowerInvariant() since I named the enum values with a capital starting letter to adhere to coding conventions
        return new ChoiceDto(type, type.ToString().ToLowerInvariant());
    }
}


