using RPSLS.Domain.Enums;

namespace RPSLS.Domain.Logic
{
	public static class GameLogic
	{
		public static string DetermineWinner(HandsignType player, HandsignType computer)
		{
			if (player == computer)
				return "You tie";

			return (player, computer) switch
			{
				(HandsignType.Rock, HandsignType.Scissors) or (HandsignType.Rock, HandsignType.Lizard) => "You win",
				(HandsignType.Paper, HandsignType.Rock) or (HandsignType.Paper, HandsignType.Spock) => "You win",
				(HandsignType.Scissors, HandsignType.Paper) or (HandsignType.Scissors, HandsignType.Lizard) => "You win",
				(HandsignType.Lizard, HandsignType.Spock) or (HandsignType.Lizard, HandsignType.Paper) => "You win",
				(HandsignType.Spock, HandsignType.Scissors) or (HandsignType.Spock, HandsignType.Rock) => "You win",

				// All other cases are where computer wins
				_ => "You lose"
			};
		}
	}
}
