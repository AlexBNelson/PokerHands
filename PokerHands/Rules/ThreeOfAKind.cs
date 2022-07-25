using PokerHands.Models;

namespace PokerHands.Rules;

public class ThreeOfAKind : BaseRule
{
   public override int Rank { get; }

   public ThreeOfAKind()
   {
      Rank = 4;
   }
   public override bool MeetsConditions(List<Card> cards)
   {
      return cards.GroupBy(x => x.Value).Any(g => g.Count() == 3);

   }

   public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
   {
      var player1Rule = player1Cards.GroupBy(x => x.Value).Where(g => g.Count() == 3).First().ToList();

      var player2Rule = player2Cards.GroupBy(x => x.Value).Where(g => g.Count() == 3).First().ToList();

      if (player1Rule.First().Value > player2Rule.First().Value)
      {
         return GameOutcome.Player1Wins;
      }
      else if (player2Rule.First().Value > player1Rule.First().Value)
      {
         return GameOutcome.Player2Wins;
      }

      throw new Exception("If both players have three of a kind, one must be higher");
   }

        
}