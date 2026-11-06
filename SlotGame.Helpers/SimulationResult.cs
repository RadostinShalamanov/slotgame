using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotGame.Helpers
{
    public class SimulationResult
    {
        public long TotalSpins { get; set; }

        public long TotalBets { get; set; }

        public long TotalWins { get; set; }

        public long WinningSpins { get; set; }

        public long NetProfit => TotalWins - TotalBets;

        public double RTP()
        {
            if (TotalBets == 0)
            {
                return 0;
            }
            return (double) TotalWins / TotalBets * 100;
        }

      
    }
}
