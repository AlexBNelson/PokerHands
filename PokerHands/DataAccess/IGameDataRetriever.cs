namespace PokerHands.DataAccess
{
    public interface IGameDataRetriever
    {
        List<(List<Card>, List<Card>)> GetGameData();
    }
}
