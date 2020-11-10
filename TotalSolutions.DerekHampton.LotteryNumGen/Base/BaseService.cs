using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotalSolutions.DerekHampton.LotteryNumGen.Interfaces;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Base
{
    public abstract class BaseService
    {
        protected readonly ILoggingService _loggingService;

        public BaseService(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }
    }
}
