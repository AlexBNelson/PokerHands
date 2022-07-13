using PokerHands;
using PokerHands.Rules;

namespace PokerRules.Test
{
    public class ValidRuleTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void RoyalFlush_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 10,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 11,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 12,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 13,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 0,
                    Suit = Suit.Hearts
                },
            };

            RoyalFlush hand = new RoyalFlush();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void StraightFlush_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Diamonds
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Diamonds
                },
                new Card()
                {
                    Value = 9,
                    Suit = Suit.Diamonds
                },
                new Card()
                {
                    Value = 10,
                    Suit = Suit.Diamonds
                },
                new Card()
                {
                    Value = 11,
                    Suit = Suit.Diamonds
                },
            };

            StraightFlush hand = new StraightFlush();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void FourOfAKind_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Clubs
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Spades
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Diamonds
                },
            };

            FourOfAKind hand = new FourOfAKind();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void FullHouse_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Clubs
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Spades
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Diamonds
                },
            };

            FullHouse hand = new FullHouse();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void Flush_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 2,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 12,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 4,
                    Suit = Suit.Hearts
                },
            };

            Flush hand = new Flush();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void Straight_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 9,
                    Suit = Suit.Clubs
                },
                new Card()
                {
                    Value = 10,
                    Suit = Suit.Spades
                },
                new Card()
                {
                    Value = 11,
                    Suit = Suit.Diamonds
                },
            };

            Straight hand = new Straight();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void ThreeOfAKind_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Clubs
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Spades
                },
                new Card()
                {
                    Value = 3,
                    Suit = Suit.Diamonds
                },
            };

            ThreeOfAKind hand = new ThreeOfAKind();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void TwoPairs_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Clubs
                },
                new Card()
                {
                    Value = 3,
                    Suit = Suit.Spades
                },
                new Card()
                {
                    Value = 3,
                    Suit = Suit.Clubs
                },
            };

            TwoPairs hand = new TwoPairs();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }

        [Test]
        public void OnePair_ValidRule()
        {
            List<Card> cards = new List<Card>()
            {
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 8,
                    Suit = Suit.Hearts
                },
                new Card()
                {
                    Value = 7,
                    Suit = Suit.Clubs
                },
                new Card()
                {
                    Value = 3,
                    Suit = Suit.Spades
                },
                new Card()
                {
                    Value = 2,
                    Suit = Suit.Diamonds
                },
            };

            OnePair hand = new OnePair();

            bool result = hand.MeetsConditions(cards);

            Assert.IsTrue(result);
        }
    }
}