namespace PokerHands.Rules
{
    public enum GameOutcome
    {
        Player1Wins,
        Player2Wins,
        Tie
    }
    public abstract class BaseRule
    {
        public virtual int Rank { get; }
        public abstract bool MeetsConditions(List<Card> cards);
        public abstract GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards);
    }
}
