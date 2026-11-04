using SlotGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotGame.Domain
{
    public class Slot
    {
        private readonly Configuration _configuration;
        private readonly Random _random;

        public Slot(Configuration configuration, Random? random = null)
        {
            _configuration = configuration;
            _random = random ?? new Random();
        }

        public SpinResult Spin()
        {
            int reelsCount = _configuration.ReelsCount;
            int rowsCount = _configuration.RowsCount;

            int[] positions = new int[reelsCount];
            int[,] screen = new int[rowsCount, reelsCount];

            for (int reel = 0; reel < reelsCount; reel++)
            {
                int[] reelSymbols = _configuration.Reels[reel];
                positions[reel] = _random.Next(reelSymbols.Length);

                for (int row = 0; row < rowsCount; row++)
                {
                    int index = (positions[reel] + row) % reelSymbols.Length;
                    screen[row, reel] = reelSymbols[index];
                }
            }

            List<LineWin> wins = new();

            for (int lineIndex = 0; lineIndex < _configuration.Lines.Length; lineIndex++)
            {
                int[] line = _configuration.Lines[lineIndex];

                int firstSymbol = screen[line[0], 0];
                int matchCount = 1;

                for (int reel = 1; reel < reelsCount; reel++)
                {
                    int currSymbol = screen[line[reel], reel];

                    if (currSymbol != firstSymbol)
                    {
                        break;
                    }

                    matchCount++;
                }


                if (matchCount >= 3)
                {
                    int payout = _configuration.Symbols[firstSymbol][matchCount - 1];

                    if (payout > 0)
                    {
                        wins.Add(new LineWin
                        {
                            LineNumber = lineIndex + 1,
                            Symbol = firstSymbol,
                            MatchCount = matchCount,
                            Payout = payout
                        });
                    }
                }
            }

            return new SpinResult
            {
                ReelPositions = positions,
                Screen = screen,
                LineWins = wins,
                TotalPayout = wins.Sum(x => x.Payout)
            };
        }


    }
}
