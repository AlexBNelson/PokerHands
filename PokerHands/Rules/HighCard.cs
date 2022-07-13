namespace PokerHands.Rules
{
    public class HighCard : BaseRule
    {
        public override int Rank { get; }

        public HighCard()
        {
            Rank = 1;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
            return true;

        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            var player1OrderedCards= player1Cards.OrderBy(card => card.Value).ToList();
            var player2OrderedCards = player2Cards.OrderBy(card => card.Value).ToList();

            for (int i = 4; i >= 0; i--)
            {
                if (player1OrderedCards[i].Value > player2OrderedCards[i].Value)
                {
                    return GameOutcome.Player1Wins;
                }
                else if (player2OrderedCards[i].Value > player1OrderedCards[i].Value)
                {
                    return GameOutcome.Player2Wins;
                }
            }

            return GameOutcome.Tie;
        }
    }
}
