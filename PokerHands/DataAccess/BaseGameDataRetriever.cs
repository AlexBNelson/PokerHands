namespace PokerHands.DataAccess
{
    public abstract class BaseGameDataRetriever
    {
        protected readonly string FileUrl;
        protected readonly Dictionary<char, int> CardNumberMap = new()
        {
            {'A',14},
            {'T',10},
            {'J',11},
            {'Q',12},
            {'K',13}
        };

        protected readonly Dictionary<char, Suit> SuitAbbreviations = new()
        {
            { 'C', Suit.Clubs },
            { 'S', Suit.Spades },
            { 'H', Suit.Hearts },
            { 'D', Suit.Diamonds }
        };

        protected BaseGameDataRetriever(string fileUrl)
        {
            FileUrl = fileUrl;
        }

        protected BaseGameDataRetriever()
        {
            FileUrl = "";
        }

        //TODO: List of lists
        public abstract Task<List<(List<Card>, List<Card>)>> GetGameData();

        protected int ParseCardNumber(char c)
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

        protected Suit GetSuitFromChar(char c)
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

        protected List<(List<Card>, List<Card>)> ParseGameDataText(List<string> lines)
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
