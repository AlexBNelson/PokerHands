using NUnit.Framework;
using PokerHands.Models;
using PokerHands.Rules;

namespace PokerHands.Test;

public class RuleCompareValueTests
{
   [SetUp]
   public void Setup()
   {
   }
   [Test]
   public void CompareRoyalFlush_Tie()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 9,
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
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 9,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 13,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 0,
            Suit = Suit.Diamonds
         }

      };

      RoyalFlush hand = new RoyalFlush();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Tie);
   }

   [Test]
   public void CompareStraightFlush_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 4,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 6,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Hearts
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 1,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 3,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 4,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Diamonds
         }

      };

      StraightFlush hand = new StraightFlush();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareFourOfAKind_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Clubs
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 3,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 3,
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
            Suit = Suit.Hearts
         }

      };

      FourOfAKind hand = new FourOfAKind();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareFullHouse_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 9,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 9,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 9,
            Suit = Suit.Clubs
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 8,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Hearts
         }

      };

      FullHouse hand = new FullHouse();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }



   [Test]
   public void CompareFlush_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 2,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 9,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 3,
            Suit = Suit.Hearts
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 10,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 3,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Diamonds
         }

      };

      Flush hand = new Flush();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareStraight_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 9,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 10,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 4,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 6,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         }

      };

      Straight hand = new Straight();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareThreeOfAKind_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 4,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 4,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 6,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 4,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         }

      };

      ThreeOfAKind hand = new ThreeOfAKind();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareTwoPairs_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 4,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 4,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         }

      };

      TwoPairs hand = new TwoPairs();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareTwoPairs_HighestPairSame_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 4,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 4,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         }

      };

      TwoPairs hand = new TwoPairs();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareOnePair_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 3,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 10,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         }

      };

      OnePair hand = new OnePair();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareOnePair_PairSameValue_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 3,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 10,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         }

      };

      OnePair hand = new OnePair();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareHighCard_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 7,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 11,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 4,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 3,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 10,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 2,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 5,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 8,
            Suit = Suit.Spades
         }

      };

      HighCard hand = new HighCard();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }

   [Test]
   public void CompareHighCard_HighestCardsSame_Player1Wins()
   {
      List<Card> player1Cards = new List<Card>()
      {
         new Card()
         {
            Value = 4,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 12,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 10,
            Suit = Suit.Hearts
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 3,
            Suit = Suit.Spades
         }

      };

      List<Card> player2Cards = new List<Card>()
      {
         new Card()
         {
            Value = 12,
            Suit = Suit.Diamonds
         },
         new Card()
         {
            Value = 4,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 7,
            Suit = Suit.Spades
         },
         new Card()
         {
            Value = 10,
            Suit = Suit.Clubs
         },
         new Card()
         {
            Value = 1,
            Suit = Suit.Spades
         }

      };

      HighCard hand = new HighCard();

      var winner = hand.CompareValue(player1Cards, player2Cards);

      Assert.IsTrue(winner == GameOutcome.Player1Wins);
   }
}