using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.DataAccess;

public interface IGameDataParser
{
   List<Hands> ParseGameDataText(List<string> lines);
}