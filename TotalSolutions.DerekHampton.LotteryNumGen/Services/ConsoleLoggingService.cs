using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotalSolutions.DerekHampton.LotteryNumGen.Interfaces;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Services
{
    public class ConsoleLoggingService : ILoggingService
    {
        public Task LogMessage(string context, string message) 
        {
            return Task.Run(() => Console.WriteLine($"LOG [{DateTime.UtcNow}]: ({context}) {message}"));
        }
        public Task LogMessage(string context, Exception ex) 
        {
            return Task.Run(() => Console.WriteLine($"EXCEPTION [{DateTime.UtcNow}]: ({context}) {ex.Message}"));
        }
    }
}
