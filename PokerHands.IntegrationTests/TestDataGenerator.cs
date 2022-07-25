using PokerHands.DataAccess;
using PokerHands.Models;

namespace PokerHands.IntegrationTests;

public class TestDataGenerator
{

   public List<(List<Card>, List<Card>)> GenerateTestData(int start, int length)
   {
      BaseGameDataRetriever dataRetriever = new FileDataRetriever("./pokerHandsData.txt");

      var data = dataRetriever.GetGameData();

      return data.GetRange(start, length);
   }
}