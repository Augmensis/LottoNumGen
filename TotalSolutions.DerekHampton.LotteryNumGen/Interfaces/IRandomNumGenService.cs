using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Interfaces
{
    public interface IRandomNumGenService
    {
        /// <summary>
        /// Generates a new random number within the config parameters. Values from the exclusions list are ignored and regenerated.
        /// </summary>
        /// <param name="exclusions"></param>
        /// <returns></returns>
        Task<int> GenerateRandomNumber(List<int> exclusions = null);


        /// <summary>
        /// Generates a list of unique int values depeding on config parameters.
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, List<int>>> LuckyDip();
    }
}
