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

        public abstract List<(List<Card>, List<Card>)> GetGameData();

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
    }
}
