namespace PokerHands.Rules
{
    public class FourOfAKind : BaseRule
    {
        public override int Rank { get; }

        public FourOfAKind()
        {
            Rank = 8;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
           return cards.GroupBy(x => x.Value).Any(g => g.Count() == 4);

        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            var orderedPlayer1Cards = player1Cards.OrderBy(card => card.Value).ToList();

            var orderedPlayer2Cards = player2Cards.OrderBy(card => card.Value).ToList();

            var player1Rule = orderedPlayer1Cards.GroupBy(x => x.Value).Where(g => g.Count() == 4).ToList()[0];

            var player2Rule = orderedPlayer2Cards.GroupBy(x => x.Value).Where(g => g.Count() == 4).ToList()[0];

            if (player1Rule.ToList().First().Value > player2Rule.ToList().First().Value)
            {
                return GameOutcome.Player1Wins;
            }else if (player2Rule.ToList().First().Value > player1Rule.ToList().First().Value)
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
