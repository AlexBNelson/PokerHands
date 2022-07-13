using System.Net;

namespace PokerHands.DataAccess
{
    public class WebDataRetriever : IGameDataRetriever
    {
        private readonly Dictionary<char, int> cardNumberMap = new() 
        {
            {'A',14},
            {'T',10},
            {'J',11},
            {'Q',12},
            {'K',13}
        };

        private readonly Dictionary<char, Suit> suitAbbreviations = new()
        {
            { 'C', Suit.Clubs },
            { 'S', Suit.Spades },
            { 'H', Suit.Hearts },
            { 'D', Suit.Diamonds }
        };

        public List<(List<Card>, List<Card>)> GetGameData()
        {
            var webRequest = WebRequest.Create(@"https://projecteuler.net/project/resources/p054_poker.txt");

            var response = webRequest.GetResponse();

            var content = response.GetResponseStream();
            var reader = new StreamReader(content);


            var lines = new List<string>();

            while (true)
            {
                var line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                lines.Add(line);
            }

            return ParseGameDataText(lines);
        }

        private List<(List<Card>, List<Card>)> ParseGameDataText(List<string> lines)
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
                return cardNumberMap[c];
            }
        }

        private Suit GetSuitFromChar(char c)
        {
            if (suitAbbreviations.ContainsKey(c))
            {
                return suitAbbreviations[c];
            }
            else
            {
                throw new Exception("invalid suit abbreviation");
            }
        }
    }
}
