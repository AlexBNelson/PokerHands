using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHands.Models;

namespace PokerHands.DataAccess;

public interface IGameDataRetriever
{
   Task<List<Hands>> GetGameData();
}