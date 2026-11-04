using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotGame.Domain.Models
{
    public class LineWin
    {
        public int LineNumber { get; set; }

        public int Symbol { get; set; }

        public int MatchCount { get; set; }

        public int Payout { get; set; }
    }
}
