using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotalSolutions.DerekHampton.LotteryNumGen.Interfaces;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Base
{
    public class BaseController : Controller
    {
        protected readonly ILoggingService _loggingService;

        public BaseController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }
    }
}
