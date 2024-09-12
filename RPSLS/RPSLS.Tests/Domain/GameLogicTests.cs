using RPSLS.Domain.Enums;
using RPSLS.Domain.Logic;

public class GameLogicTests
{
	[Theory]
	[InlineData(HandsignType.Rock, HandsignType.Scissors, "win")]
	[InlineData(HandsignType.Rock, HandsignType.Lizard, "win")]
	[InlineData(HandsignType.Paper, HandsignType.Rock, "win")]
	[InlineData(HandsignType.Paper, HandsignType.Spock, "win")]
	[InlineData(HandsignType.Scissors, HandsignType.Paper, "win")]
	[InlineData(HandsignType.Scissors, HandsignType.Lizard, "win")]
	[InlineData(HandsignType.Lizard, HandsignType.Spock, "win")]
	[InlineData(HandsignType.Lizard, HandsignType.Paper, "win")]
	[InlineData(HandsignType.Spock, HandsignType.Scissors, "win")]
	[InlineData(HandsignType.Spock, HandsignType.Rock, "win")]
	public void DetermineWinner_PlayerWins(HandsignType player, HandsignType computer, string expectedResult)
	{
		var result = GameLogic.DetermineWinner(player, computer);
		Assert.Equal(expectedResult, result);
	}

	[Theory]
	[InlineData(HandsignType.Rock, HandsignType.Paper, "lose")]
	[InlineData(HandsignType.Rock, HandsignType.Spock, "lose")]
	[InlineData(HandsignType.Paper, HandsignType.Scissors, "lose")]
	[InlineData(HandsignType.Paper, HandsignType.Lizard, "lose")]
	[InlineData(HandsignType.Scissors, HandsignType.Rock, "lose")]
	[InlineData(HandsignType.Scissors, HandsignType.Spock, "lose")]
	[InlineData(HandsignType.Lizard, HandsignType.Rock, "lose")]
	[InlineData(HandsignType.Lizard, HandsignType.Scissors, "lose")]
	[InlineData(HandsignType.Spock, HandsignType.Paper, "lose")]
	[InlineData(HandsignType.Spock, HandsignType.Lizard, "lose")]
	public void DetermineWinner_PlayerLoses(HandsignType player, HandsignType computer, string expectedResult)
	{
		var result = GameLogic.DetermineWinner(player, computer);
		Assert.Equal(expectedResult, result);
	}

	[Theory]
	[InlineData(HandsignType.Rock, HandsignType.Rock, "tie")]
	[InlineData(HandsignType.Paper, HandsignType.Paper, "tie")]
	[InlineData(HandsignType.Scissors, HandsignType.Scissors, "tie")]
	[InlineData(HandsignType.Lizard, HandsignType.Lizard, "tie")]
	[InlineData(HandsignType.Spock, HandsignType.Spock, "tie")]
	public void DetermineWinner_Tie(HandsignType player, HandsignType computer, string expectedResult)
	{
		var result = GameLogic.DetermineWinner(player, computer);
		Assert.Equal(expectedResult, result);
	}
}
