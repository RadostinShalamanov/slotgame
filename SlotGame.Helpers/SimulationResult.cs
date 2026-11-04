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

        public double RPT => TotalBets == 0 ? 0 : (double)TotalSpins / TotalBets * 100;

        public TimeSpan ExecutionTime { get; set; }

        public double SpinsPerSecond =>
               ExecutionTime.TotalSeconds == 0 ? 0 : TotalSpins / ExecutionTime.TotalSeconds;
    }
}
