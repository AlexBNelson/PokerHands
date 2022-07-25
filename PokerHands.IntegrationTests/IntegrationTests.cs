using Castle.Components.DictionaryAdapter;
using Moq;
using PokerHands.DataAccess;

namespace PokerHands.IntegrationTests;

public class IntegrationTests
{
   [SetUp]
   public void Setup()
   {
            

   }

   [Test]
   public void GetCorrectNumberOfPlayer1Wins()
   {
      TestDataGenerator dataGenerator = new TestDataGenerator();

      var testData = dataGenerator.GenerateTestData(100, 6);


      RuleGenerator ruleGenerator = new RuleGenerator();

      Mock<BaseGameDataRetriever> dataRetriever = new Mock<BaseGameDataRetriever>();

      WinCalculator winCalculator = new WinCalculator();


      dataRetriever.Setup(x => x.GetGameData()).Returns(testData);


      var actualPlayer1Wins = winCalculator.CalculateWins(dataRetriever.Object.GetGameData(), ruleGenerator.GenerateRules());


      var expectedPlayer1Wins = 2;


      Assert.That(actualPlayer1Wins, Is.EqualTo(expectedPlayer1Wins));
   }
}