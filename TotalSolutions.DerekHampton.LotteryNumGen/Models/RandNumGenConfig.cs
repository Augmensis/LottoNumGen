using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Models
{
    public class RandNumGenConfig
    {
        /// <summary>
        /// Generate numbers no smaller than this value (inclusive).
        /// </summary>
        public int RangeMin { get; set; } = 1;

        /// <summary>
        /// Generate numbers no larger than this value (inclusive).
        /// </summary>
        public int RangeMax { get; set; } = 100; // DH - Default values to show config from appsettings.json being used

        /// <summary>
        /// Number of main balls to be generated.
        /// </summary>
        public int NoMainBalls { get; set; } = 6;

        /// <summary>
        /// Number of bonus balls to be generated.
        /// </summary>
        public int NoBonusBalls { get; set; } = 2;
    }
}
