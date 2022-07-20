
namespace PokerHands.DataAccess;

public class WebDataRetriever : IGameDataRetriever
{
   private readonly IGameDataParser _gameDataParser;
   private readonly string _url;

   public WebDataRetriever(IGameDataParser gameDataParser, string url)
   {
      _gameDataParser = gameDataParser;
      _url = url;
   }

   public async Task<List<(List<Card>, List<Card>)>> GetGameData()
   {
      var client = new HttpClient();

      var response = await client.GetAsync(_url);

      var content = response.Content;
      var stream = await content.ReadAsStreamAsync();
      var reader = new StreamReader(stream);


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

      return _gameDataParser.ParseGameDataText(lines);
   }
}