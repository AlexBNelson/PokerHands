// See https://aka.ms/new-console-template for more information

using PokerHands;
using PokerHands.DataAccess;



RuleGenerator ruleGenerator = new RuleGenerator();

IGameDataRetriever dataRetriever = new WebDataRetriever();

WinCalculator winCalculator = new WinCalculator();



var rules = ruleGenerator.GenerateRules();

var data = dataRetriever.GetGameData();



Console.WriteLine(winCalculator.CalculateWins(data, rules));

Console.ReadLine();



