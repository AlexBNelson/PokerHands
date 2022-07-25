using PokerHands.Models;

namespace PokerHands.Rules;

public class StraightFlush : BaseRule
{
   private const int MaximumLowestCardValue = 9;
   public override int Rank { get; }

   public StraightFlush()
   {
      Rank = 9;
   }
   public override bool MeetsConditions(List<Card> cards)
   {
      var orderedCards = cards.OrderBy(card => card.Value).ToList();

      var suit = cards[0].Suit;

      var lowestValueCard = orderedCards[0].Value;

      return (lowestValueCard <= MaximumLowestCardValue
              && orderedCards[0].Value == lowestValueCard && orderedCards[0].Suit == suit
              && orderedCards[1].Value == lowestValueCard + 1 && orderedCards[1].Suit == suit
              && orderedCards[2].Value == lowestValueCard + 2 && orderedCards[2].Suit == suit
              && orderedCards[3].Value == lowestValueCard + 3 && orderedCards[3].Suit == suit
              && orderedCards[4].Value == lowestValueCard + 4 && orderedCards[4].Suit == suit);

   }

   public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
   {
      var orderedPlayer1Cards = player1Cards.OrderBy(card => card.Value).ToList();

      var orderedPlayer2Cards = player2Cards.OrderBy(card => card.Value).ToList();

      if (orderedPlayer1Cards[0].Value > orderedPlayer2Cards[0].Value)
      {
         return GameOutcome.Player1Wins;
      }
      else if (orderedPlayer1Cards[0].Value < orderedPlayer2Cards[0].Value)
      {
         return GameOutcome.Player2Wins;
      }
      else
      {
         return GameOutcome.Tie;
      }
            
            
            
   }
}