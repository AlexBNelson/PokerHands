using PokerHands.Rules;

namespace PokerHands;

public class RuleGenerator
{
   public List<BaseRule> GenerateRules()
   {
      var hands = new List<BaseRule>
      {
         new RoyalFlush(),
         new StraightFlush(),
         new FourOfAKind(),
         new FullHouse(),
         new Flush(),
         new Straight(),
         new ThreeOfAKind(),
         new TwoPairs(),
         new OnePair(),
         new HighCard()
      };

      return hands;

   }
}