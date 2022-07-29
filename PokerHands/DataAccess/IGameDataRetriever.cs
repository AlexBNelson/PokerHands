using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHands.Models;

namespace PokerHands.DataAccess;

public enum DataRetrievers
{
   FileDataRetriever,
   WebDataRetriever
}
public interface IGameDataRetriever
{
   Task<List<Hands>> GetGameData();
}