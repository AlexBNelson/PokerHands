using PokerHands.Rules;

namespace PokerHands
{
    public class RuleGenerator
    {
        public List<BaseRule> GenerateRules()
        {
            List<BaseRule> hands = new List<BaseRule>();


            hands.Add(new RoyalFlush());

            hands.Add(new StraightFlush());

            hands.Add(new FourOfAKind());

            hands.Add(new FullHouse());

            hands.Add(new Flush());

            hands.Add(new Straight());

            hands.Add(new ThreeOfAKind());

            hands.Add(new TwoPairs());

            hands.Add(new OnePair());

            hands.Add(new HighCard());

            return hands;

        }
    }
}
