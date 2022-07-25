using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHands.Models;

namespace PokerHands.DataAccess;

public class GameDataParser : IGameDataParser
{
   public List<Hands> ParseGameDataText(List<string> lines)
   {
      List<Hands> cardData = new List<Hands>();

      foreach (var line in lines)
      {
         List<string> cardCodes = line.Split(" ").ToList();

         List<Card> cards = new List<Card>();

         cardCodes.ForEach(c =>
         {
            cards.Add(new Card()
            {
               Suit = GetSuitFromChar(c[1]),
               Value = ParseCardNumber(c[0])
            });
         });

         var player1Cards = cards.GetRange(0, 5);

         var player2Cards = cards.GetRange(5, 5);

         cardData.Add(new Hands(player1Cards, player2Cards));
      }
      return cardData;
   }

   private int ParseCardNumber(char c)
   {
      if (int.TryParse(c.ToString(), out var number))
      {
         return number;
      }
      else
      {
         return CardNumberMap[c];
      }
   }

   private Suit GetSuitFromChar(char c)
   {
      if (SuitAbbreviations.ContainsKey(c))
      {
         return SuitAbbreviations[c];
      }
      else
      {
         throw new Exception("invalid suit abbreviation");
      }
   }

   private readonly Dictionary<char, int> CardNumberMap = new()
   {
      { 'A', 14 },
      { 'T', 10 },
      { 'J', 11 },
      { 'Q', 12 },
      { 'K', 13 }
   };

   private readonly Dictionary<char, Suit> SuitAbbreviations = new()
   {
      { 'C', Suit.Clubs },
      { 'S', Suit.Spades },
      { 'H', Suit.Hearts },
      { 'D', Suit.Diamonds }
   };
}