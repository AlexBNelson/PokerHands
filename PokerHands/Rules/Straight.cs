namespace PokerHands.Rules
{
    public class Straight : BaseRule
    {
        public override int Rank { get; }

        public Straight()
        {
            Rank = 5;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
            var orderedCards = cards.OrderBy(card => card.Value).ToList();

            for (int i=0; i<5; i++)
            {
                if (orderedCards[i].Value != orderedCards[0].Value + i)
                {
                    return false;
                }
            }

            return true;
        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            var orderedPlayer1Cards = player1Cards.OrderBy(card => card.Value).ToList();

            var orderedPlayer2Cards = player2Cards.OrderBy(card => card.Value).ToList();

            if (orderedPlayer1Cards.Last().Value > orderedPlayer2Cards.Last().Value)
            {
                return GameOutcome.Player1Wins;
            }
            else if (orderedPlayer2Cards.Last().Value > orderedPlayer1Cards.Last().Value)
            {
                return GameOutcome.Player2Wins;
            }
            else
            {
                return GameOutcome.Tie;
            }

        }
    }
}
