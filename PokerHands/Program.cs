// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PokerHands;
using PokerHands.DataAccess;

//var configuration = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile($"appsettings.json");

//var config = configuration.Build();




var host = Host.CreateDefaultBuilder(args)
   .ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
   {
      configurationBuilder.Sources.Clear();

      configurationBuilder
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
   })
   .ConfigureServices((context, services) =>
      services
         .AddScoped<IGameDataRetriever, WebDataRetriever>()
         .AddScoped<IGameDataParser, GameDataParser>()
         .Configure<GameDataOptions>(context.Configuration))
   .Build();


//TODO: Container https://docs.microsoft.com/en-us/dotnet/core/extensions/options
// https://stackoverflow.com/questions/72508316/options-pattern-ioptions-c-sharp-net-6-0-windows-form






//TODO: Game is your route object. this is the one you will "Resolve"
//TODO: Resolve appropriate service depending on what you have set in your app config file. I.e use file or use URL. Extra challenge. Let's resolve both and run the whole thing twice!
//TODO: Find a way to resolve config file values in your service. Try IOptions

var game = host.Services.CreateScope().ServiceProvider.GetRequiredService<Game>();

//TODO: Move all services into game.

Console.WriteLine(game.CalculateWins());

Console.ReadLine();






