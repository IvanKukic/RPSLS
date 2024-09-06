using RPSLS.Domain.Enums;

namespace RPSLS.Domain.Entities;

public class Choice
{
    public ChoiceType ChoiceType { get; init; }
    public string Name { get; init; }

    public Choice(ChoiceType choiceType, string name)
    {
        ChoiceType = choiceType;
        Name = name;
    }

    public bool AmITheWinner(Choice choice)
    {
        return false;
    }

    public Choice(int type)
    {
        var actualType = (ChoiceType)type;
        ChoiceType = actualType;
        Name = actualType.ToString();
    }
}
