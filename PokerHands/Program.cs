// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using PokerHands;
using PokerHands.DataAccess;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.json");


var config = configuration.Build();

RuleGenerator ruleGenerator = new RuleGenerator();

BaseGameDataRetriever dataRetriever = new WebDataRetriever(config["WebGameDataLocation"]);

WinCalculator winCalculator = new WinCalculator();



var rules = ruleGenerator.GenerateRules();

var data = dataRetriever.GetGameData();



Console.WriteLine(winCalculator.CalculateWins(data, rules));

Console.ReadLine();
