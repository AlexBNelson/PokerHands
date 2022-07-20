// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using PokerHands;
using PokerHands.DataAccess;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.json");

//TODO: Container

var config = configuration.Build();


RuleGenerator ruleGenerator = new RuleGenerator();

BaseGameDataRetriever dataRetriever = new WebDataRetriever(config["GameDataLocation"]);

//TODO: Game is your route object. this is the one you will "Resolve"
//TODO: Resolve appropriate service depending on what you have set in your app config file. I.e use file or use URL. Extra challenge. Let's resolve both and run the whole thing twice!
//TODO: Find a way to resolve config file values in your service. Try IOptions

var game = new Game(new WebDataRetriever(new GameDataParser(), config["GameDataLocation"]));

//TODO: Move all services into game.
WinCalculator winCalculator = new WinCalculator();

var rules = ruleGenerator.GenerateRules();

var data = await dataRetriever.GetGameData();


Console.WriteLine(winCalculator.CalculateWins(data, rules));

Console.ReadLine();

public class Game
{
   private readonly IGameDataRetriever _gameDataRetriever;

   public Game(IGameDataRetriever gameDataRetriever)
   {
      _gameDataRetriever = gameDataRetriever;
   }
}

public interface IGameDataRetriever
{
   Task<List<(List<Card>, List<Card>)>> GetGameData();
}

public class GameDataParser : IGameDataParser
{
   public List<(List<Card>, List<Card>)> ParseGameDataText(List<string> lines)
   {
      List<(List<Card>, List<Card>)> cardData = new List<(List<Card>, List<Card>)>();

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

         cardData.Add((player1Cards, player2Cards));
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

public interface IGameDataParser
{
   List<(List<Card>, List<Card>)> ParseGameDataText(List<string> lines);
}