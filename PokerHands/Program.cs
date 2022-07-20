// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokerHands;
using PokerHands.DataAccess;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.json");
var config = configuration.Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddScoped<BaseGameDataRetriever, WebDataRetriever>()
            .AddTransient<WinCalculator>()).Build();

var winCalc = host.Services.CreateScope().ServiceProvider.GetRequiredService<WinCalculator>(); ;

RuleGenerator ruleGenerator = new RuleGenerator();

var rules = ruleGenerator.GenerateRules();


Console.WriteLine(winCalc.CalculateWins(rules));

Console.ReadLine();

host.StartAsync();
