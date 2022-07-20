
namespace PokerHands.DataAccess;

public class FileDataRetriever : IGameDataRetriever
{
   private readonly IGameDataParser _gameDataParser;
   private readonly string _fileUrl;

   public FileDataRetriever(IGameDataParser gameDataParser, string fileUrl)
   {
      _gameDataParser = gameDataParser;
      _fileUrl = fileUrl;
   }

   public Task<List<(List<Card>, List<Card>)>> GetGameData()
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