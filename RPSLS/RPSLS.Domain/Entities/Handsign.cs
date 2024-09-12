using RPSLS.Domain.Enums;

namespace RPSLS.Domain.Entities;

public class Handsign
{
    public HandsignType HandsignType { get; init; }
    public string Name { get; init; }

    public Handsign(HandsignType handsignType, string name)
    {
        HandsignType = handsignType;
        Name = name;
    }

    public Handsign(int type)
    {
        var actualType = (HandsignType)type;
        HandsignType = actualType;
        Name = actualType.ToString().ToLower();
    }
}
