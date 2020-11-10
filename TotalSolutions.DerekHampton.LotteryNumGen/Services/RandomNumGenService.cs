using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotalSolutions.DerekHampton.LotteryNumGen.Base;
using TotalSolutions.DerekHampton.LotteryNumGen.Interfaces;
using TotalSolutions.DerekHampton.LotteryNumGen.Models;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Services
{
    public class RandomNumGenService : BaseService, IRandomNumGenService
    {

        private RandNumGenConfig _config;
        private Random _random;

        public RandomNumGenService(IOptions<RandNumGenConfig> config, ILoggingService loggingService) : base(loggingService)
        {
            _config = config.Value;
            _random = new Random();
        }



        public async Task<int> GenerateRandomNumber(List<int> exclusions = null)
        {
            int result = 0;

            try
            {
                while(result == 0)
                {
                    // Generate a random number
                    var candidate = _random.Next(_config.RangeMin, _config.RangeMax);

                    // Check candidate against exclusions list (if any)
                    // Return the result if it is a new number
                    if (exclusions != null && !exclusions.Contains(candidate))
                        result = candidate;                    
                }
            }
            catch(Exception ex)
            {
                await _loggingService.LogMessage("RandomNumGenService_GenerateRandomNumber", ex);
            }

            return result;
        }



        public async Task<Dictionary<string, List<int>>> LuckyDip()
        {

            // Using a dictionary allows us to keep track of order an different ball-types (e.g. bonus balls) and any other future types
            var result = new Dictionary<string, List<int>>();

            try
            {
                var mainBalls = new List<int>();
                var bonusBalls = new List<int>();

                // Generate Main Balls
                if(_config.NoMainBalls > 0)
                {
                    for(var main = 0; main < _config.NoMainBalls; main++)
                    {
                        var newNum = await GenerateRandomNumber(mainBalls);
                        mainBalls.Add(newNum);
                    }

                    result.Add("main", mainBalls);
                }

                // Generate Bonus Balls
                if (_config.NoBonusBalls > 0)
                {
                    for (var bonus = 0; bonus < _config.NoBonusBalls; bonus++)
                    {
                        var bonusNum = await GenerateRandomNumber(bonusBalls);
                        bonusBalls.Add(bonusNum);
                    }

                    result.Add("bonus", bonusBalls);
                }

                // Generate any other ball types
                // TODO

            }
            catch(Exception ex)
            {
                await _loggingService.LogMessage("RandomNumGenService_LuckyDip", ex);
            }

            return result;
        }


    }
}
