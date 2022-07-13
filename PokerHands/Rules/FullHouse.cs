namespace PokerHands.Rules
{
    public class FullHouse : BaseRule
    {
        public override int Rank { get; }

        public FullHouse()
        {
            Rank = 7;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
           return cards.GroupBy(x => x.Value).Any(g => g.Count() == 3)
               && cards.GroupBy(x => x.Value).Any(g => g.Count() == 2);

        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            var threeOfAKindResult = CompareValueOfNofAKind(player1Cards, player2Cards, 3);

            if (threeOfAKindResult != GameOutcome.Tie)
            {
                return threeOfAKindResult;
            }
            else
            {
                return CompareValueOfNofAKind(player1Cards, player2Cards, 2);
            }

        }

        private GameOutcome CompareValueOfNofAKind(List<Card> player1Cards, List<Card> player2Cards, int numberOfCardsWithSameValue)
        {
            var orderedPlayer1Cards = player1Cards.OrderBy(card => card.Value).ToList();

            var orderedPlayer2Cards = player2Cards.OrderBy(card => card.Value).ToList();

            var player1Rule = orderedPlayer1Cards.GroupBy(x => x.Value).Where(g => g.Count() == numberOfCardsWithSameValue).ToList()[0];

            var player2Rule = orderedPlayer2Cards.GroupBy(x => x.Value).Where(g => g.Count() == numberOfCardsWithSameValue).ToList()[0];

            if (player1Rule.ToList().First().Value > player2Rule.ToList().First().Value)
            {
                return GameOutcome.Player1Wins;
            }
            else if (player2Rule.ToList().First().Value > player1Rule.ToList().First().Value)
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
