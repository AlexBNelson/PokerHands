using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Models;

public record Hands //TODO: Use in favour of List, List tuple.
   (List<Card> Hand1, List<Card> Hand2);