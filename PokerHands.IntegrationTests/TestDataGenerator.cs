using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokerHands.DataAccess;

namespace PokerHands.IntegrationTests
{
    public class TestDataGenerator
    {

        public List<(List<Card>, List<Card>)> GenerateTestData(int start, int length)
        {
            BaseGameDataRetriever dataRetriever = new FileDataRetriever("./pokerHandsData.txt");

            var data = dataRetriever.GetGameData();

            return data.GetRange(start, length);
        }
    }
}
