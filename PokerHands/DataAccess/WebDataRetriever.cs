
using Microsoft.Extensions.Options;
using PokerHands.Models;

namespace PokerHands.DataAccess;

public class WebDataRetriever : IGameDataRetriever
{
   private readonly IGameDataParser _gameDataParser;
   private readonly string _url;

   public WebDataRetriever(IGameDataParser gameDataParser, IOptions<GameDataOptions> options)
   {
      _gameDataParser = gameDataParser;
      _url = options.Value.WebDataLocation;
   }

   public async Task<List<Hands>> GetGameData()
   {
      var client = new HttpClient();

      var response = await client.GetAsync(_url);

      var content = response.Content;
      var stream = await content.ReadAsStreamAsync();
      var reader = new StreamReader(stream);


      var lines = new List<string>();

      while (true)
      {
         var line = await reader.ReadLineAsync();

         if (line == null)
         {
            break;
         }

         lines.Add(line);
      }

      return _gameDataParser.ParseGameDataText(lines);
   }
}