using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands;

public class GameDataOptions
{
   public bool UseLocalGameData { get; set; } = true;
   public string Title { get; set; } = String.Empty;
   public string Name { get; set; } = String.Empty;

}