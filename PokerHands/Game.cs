using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHands.DataAccess;

namespace PokerHands;

public class Game
{
   private readonly IGameDataRetriever _gameDataRetriever;
   private readonly WinCalculator _winCalculator;
   private readonly RuleGenerator _ruleGenerator;

   public Game(IGameDataRetriever gameDataRetriever)
   {
      _ruleGenerator = new RuleGenerator();
      _gameDataRetriever = gameDataRetriever;
      _winCalculator = new WinCalculator();
   }

   public async Task<int> CalculateWins()
   {
      var data = await _gameDataRetriever.GetGameData();

      var rules = _ruleGenerator.GenerateRules();

      return _winCalculator.CalculateWins(data, rules);
   }
}