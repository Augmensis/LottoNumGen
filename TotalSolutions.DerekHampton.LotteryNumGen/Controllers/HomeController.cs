using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Extensions.Logging;
using TotalSolutions.DerekHampton.LotteryNumGen.Base;
using TotalSolutions.DerekHampton.LotteryNumGen.Interfaces;
using TotalSolutions.DerekHampton.LotteryNumGen.Models;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRandomNumGenService _numGenService;

        public HomeController(ILogger<HomeController> logger, IRandomNumGenService numGenService, ILoggingService loggingService) : base(loggingService)
        {
            _logger = logger;
            _numGenService = numGenService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new LuckyDipViewModel();

            try
            {
                var luckyDip = await _numGenService.LuckyDip();

                if(luckyDip.ContainsKey("main"))
                    vm.LottoNumbers = luckyDip["main"];

                if (luckyDip.ContainsKey("bonus"))
                    vm.BonusNumbers = luckyDip["bonus"];

            }
            catch(Exception ex)
            {
                await _loggingService.LogMessage("HomeController_Index", ex.Message);
            }          

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
