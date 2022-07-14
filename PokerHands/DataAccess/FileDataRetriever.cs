using System.Net;
using Microsoft.Extensions.Configuration;

namespace PokerHands.DataAccess
{
    public class FileDataRetriever : BaseGameDataRetriever
    {
        public FileDataRetriever(string fileUrl) : base(fileUrl)
        {
            
        }

        public override List<(List<Card>, List<Card>)> GetGameData()
        {
            using var reader = File.OpenText(FileUrl);


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

    }
        

        
    
}
