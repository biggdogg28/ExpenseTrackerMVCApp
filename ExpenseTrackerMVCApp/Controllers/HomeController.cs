using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TotalsRepository _totalsRepository;

        public HomeController(ILogger<HomeController> logger, TotalsRepository totalsRepository)
        {
            _logger = logger;
            _totalsRepository = totalsRepository;
        }

        public IActionResult Index()
        {
            var totals = _totalsRepository.GetTotal();
            return View("Index", totals);
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

        public ActionResult ChartView()
        {
            return View();
        }
    }
}