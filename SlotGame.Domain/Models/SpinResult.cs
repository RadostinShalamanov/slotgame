using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotGame.Domain.Models
{
    public class SpinResult
    {
        public int[] ReelPositions { get; set; } = Array.Empty<int>();

        public int[,] Screen { get; set; } = new int[0, 0];

        public List<LineWin> LineWins { get; set; } = new();

        public int TotalPayout { get; set; }
    }
}
