namespace PokerHands.Rules
{
    public class TwoPairs : BaseRule
    {
        public override int Rank { get; }

        public TwoPairs()
        {
            Rank = 3;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
            return cards.GroupBy(x => x.Value).Any(g => g.Count() == 2)
                   && cards.GroupBy(x => x.Value).Count() == 3;

        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            var player1Pairs = player1Cards.GroupBy(x => x.Value).Where(g => g.Count() == 2);
            var player2Pairs = player2Cards.GroupBy(x => x.Value).Where(g => g.Count() == 2);

            var orderedPlayer1Pairs = player1Pairs.OrderBy(pair => pair.ToList()[0].Value).ToList();
            var orderedPlayer2Pairs = player2Pairs.OrderBy(pair => pair.ToList()[0].Value).ToList();

            if (orderedPlayer1Pairs[0].ToList().First().Value > orderedPlayer2Pairs[0].ToList().First().Value)
            {
                return GameOutcome.Player1Wins;
            }
            else if (orderedPlayer2Pairs[0].ToList().First().Value > orderedPlayer1Pairs[0].ToList().First().Value)
            {
                return GameOutcome.Player2Wins;
            }
            else if (orderedPlayer1Pairs[1].ToList().First().Value > orderedPlayer2Pairs[1].ToList().First().Value)
            {
                return GameOutcome.Player1Wins;
            }
            else if (orderedPlayer2Pairs[1].ToList().First().Value > orderedPlayer1Pairs[1].ToList().First().Value)
            {
                return GameOutcome.Player2Wins;
            }
            else if (player1Cards.Distinct().First().Value > player2Cards.Distinct().First().Value)
            {
                return GameOutcome.Player1Wins;
            }
            else if (player2Cards.Distinct().First().Value > player1Cards.Distinct().First().Value)
            {
                return GameOutcome.Player1Wins;
            }
            else
            {
                return GameOutcome.Tie;
            }
        }
    }
}
