namespace PokerHands.Rules
{
    public class Flush : BaseRule
    {
        public override int Rank { get; }

        public Flush()
        {
            Rank = 6;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
            return cards.GroupBy(x => x.Suit).Count() == 1;
        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            var orderedPlayer1Cards = player1Cards.OrderBy(card => card.Value).ToList();
            var orderedPlayer2Cards = player2Cards.OrderBy(card => card.Value).ToList();

            for (int i = 4; i >= 0; i--)
            {
                if (orderedPlayer1Cards[i].Value == orderedPlayer2Cards[i].Value)
                {
                    return GameOutcome.Player1Wins;
                }
                else if (orderedPlayer2Cards[i].Value == orderedPlayer1Cards[i].Value)
                {
                    return GameOutcome.Player2Wins;
                }
            }

            return GameOutcome.Tie;

        }
    }
}
