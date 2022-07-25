
using Microsoft.Extensions.Options;
using PokerHands.Models;

namespace PokerHands.DataAccess;

public class FileDataRetriever : IGameDataRetriever
{
   private readonly IGameDataParser _gameDataParser;
   private readonly string _fileUrl;

   public FileDataRetriever(IGameDataParser gameDataParser, string fileUrl, IOptions<GameDataOptions> options)
   {
      _gameDataParser = gameDataParser;
      _fileUrl = fileUrl;
   }

   public Task<List<Hands>> GetGameData()
   {
      using var reader = File.OpenText(_fileUrl);

      var lines = new List<string>();

      while (true)
      {
         var line = reader.ReadLine();

         if (line == null)
         {
            break;
         }

         lines.Add(line);
      }

      return Task.FromResult(_gameDataParser.ParseGameDataText(lines));
   }

}