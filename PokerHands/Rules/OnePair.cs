namespace PokerHands.Rules
{
    public class OnePair : BaseRule
    {
        public override int Rank { get; }

        public OnePair()
        {
            Rank = 2;
        }
        public override bool MeetsConditions(List<Card> cards)
        {
            return cards.GroupBy(x => x.Value).Any(g => g.Count() == 2)
                   && cards.GroupBy(x => x.Value).Count() == 4;

        }

        public override GameOutcome CompareValue(List<Card> player1Cards, List<Card> player2Cards)
        {
            var player1Pair = player1Cards.GroupBy(x => x.Value).FirstOrDefault(g => g.Count() == 2).ToList();
            var player2Pair = player2Cards.GroupBy(x => x.Value).FirstOrDefault(g => g.Count() == 2).ToList();
            

            if (player1Pair[0].Value > player2Pair[0].Value)
            {
                return GameOutcome.Player1Wins;
            }
            else if (player2Pair[0].Value > player1Pair[0].Value)
            {
                return GameOutcome.Player2Wins;
            }
            else
            {
                var player1Distinct = player1Cards.Distinct().OrderBy(card => card.Value).ToList();
                var player2Distinct = player2Cards.Distinct().OrderBy(card => card.Value).ToList();

                for (int i = 2; i >= 0; i--)
                {
                    if (player1Distinct[i].Value > player2Distinct[i].Value)
                    {
                        return GameOutcome.Player1Wins;
                    }
                    else if (player2Distinct[i].Value > player1Distinct[i].Value)
                    {
                        return GameOutcome.Player2Wins;
                    }
                }

                return GameOutcome.Tie;
            }
        }
    }
}
