using PokerHands.Models;

namespace PokerHands.Rules;

public abstract class BaseRule
{
   public virtual int Rank { get; }
   public abstract bool MeetsConditions(List<Card> cards);
   public abstract GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards);
}