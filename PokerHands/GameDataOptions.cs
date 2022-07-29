using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands;

public class GameDataOptions
{
   public bool UseLocalGameData { get; set; }
   public string WebDataLocation { get; set; } = String.Empty;
   public string LocalDataLocation { get; set; } = String.Empty;
   public string ActualDataLocation { get; set; } = String.Empty;
}