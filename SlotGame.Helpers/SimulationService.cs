using SlotGame.Domain;
using SlotGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotGame.Helpers
{
    public class SimulationService
    {
        private readonly Slot _slot;
        private readonly int _betPerLine;

        public SimulationService(Slot slot, int betPerLine = 1)
        {
            if (betPerLine <= 0)
            {
                throw new ArgumentException("Bet must be greater than zero!");
            }

            _slot = slot;
            _betPerLine = betPerLine;
        }

        public SimulationResult Run(long numberOfSpins)
        {
            if (numberOfSpins <= 0)
            {
                throw new ArgumentException("Number of spins must be positive!");
            }

            SimulationResult result = new()
            {
                TotalSpins = numberOfSpins
            };



            for (int i = 0; i < numberOfSpins; i++)
            {
                SpinResult spinResult = _slot.Spin();

                result.TotalBets += 5L * _betPerLine;

                long payout = spinResult.LineWins.Sum(x => (long)x.Payout * _betPerLine);

                result.TotalWins += payout;

                if (spinResult.LineWins.Count > 0)
                {
                    result.WinningSpins++;
                }
            }

            

            return result;


        }
    }
}
