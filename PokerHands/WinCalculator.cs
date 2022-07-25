using PokerHands.Models;
using PokerHands.Rules;

namespace PokerHands;

public class WinCalculator
{
   public int CalculateWins(List<Hands> data, List<BaseRule> rules)
   {
      int player1WinCount = 0;

      foreach (var play in data)
      {
         int player1Rank = 0;

         int player2Rank = 0;

         BaseRule player1Rule = rules.Last();

         var player1Cards = play.Hand1;

         var player2Cards = play.Hand2;

         rules.ForEach(x =>
         {
            if (x.MeetsConditions(player1Cards) && x.Rank > player1Rank)
            {
               player1Rank = x.Rank;
               player1Rule = x;
            }

            if (x.MeetsConditions(player2Cards) && x.Rank > player2Rank)
            {
               player2Rank = x.Rank;
            }

         });

         if (player1Rank > player2Rank)
         {
            player1WinCount++;
         }
         else if(player1Rank == player2Rank)
         {
            var result = player1Rule.CompareValue(player1Cards, player2Cards);

            if (result == GameOutcome.Player1Wins)
            {
               player1WinCount++;
            }
         }
      }

      return player1WinCount;
   }
}