using RPSLS.Domain.Enums;

namespace RPSLS.Domain.Logic
{
	public static class GameLogic
	{
		public static string DetermineWinner(HandsignType player, HandsignType computer)
		{
			if (player == computer)
				return "tie";

			return (player, computer) switch
			{
				(HandsignType.Rock, HandsignType.Scissors) or (HandsignType.Rock, HandsignType.Lizard) => "win",
				(HandsignType.Paper, HandsignType.Rock) or (HandsignType.Paper, HandsignType.Spock) => "win",
				(HandsignType.Scissors, HandsignType.Paper) or (HandsignType.Scissors, HandsignType.Lizard) => "win",
				(HandsignType.Lizard, HandsignType.Spock) or (HandsignType.Lizard, HandsignType.Paper) => "win",
				(HandsignType.Spock, HandsignType.Scissors) or (HandsignType.Spock, HandsignType.Rock) => "win",

				// All other cases are where computer wins
				_ => "lose"
			};
		}
	}
}
