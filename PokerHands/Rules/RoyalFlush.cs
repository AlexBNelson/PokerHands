namespace PokerHands.Rules
{
    public class RoyalFlush : BaseRule
    {
        public override int Rank { get; }

        public RoyalFlush()
        {
            Rank = 10;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
            var orderedCards = cards.OrderBy(card => card.Value).ToList();

            var suit = cards[0].Suit;

            return (orderedCards[0].Value == 0 && orderedCards[0].Suit == suit
                && orderedCards[1].Value == 10 && orderedCards[1].Suit == suit
                && orderedCards[2].Value == 11 && orderedCards[2].Suit == suit
                && orderedCards[3].Value == 12 && orderedCards[3].Suit == suit
                && orderedCards[4].Value == 13 && orderedCards[4].Suit == suit);

        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            return GameOutcome.Tie;
        }
    }
}
