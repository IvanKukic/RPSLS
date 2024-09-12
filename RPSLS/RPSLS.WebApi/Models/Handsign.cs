using RPSLS.Domain.Enums;

namespace RPSLS.WebApi.Models;

//Probably unneccesary to have DTOs, but better to not leak domain models through the API
public record Handsign(HandsignType Id, string Name)
{    
    public static Handsign CreateFromEnumType(HandsignType type)
    {
        //ToLowerInvariant() since I named the enum values with a capital starting letter to adhere to coding conventions
        return new Handsign(type, type.ToString().ToLowerInvariant());
    }
}


