using ASPNET_MVC_Samples.Models;
using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TotalsRepository _totalsRepository;
        private readonly IncomeRepository _incomeRepository;
        private readonly ExpensesRepository _expensesRepository;

        public HomeController(ILogger<HomeController> logger, TotalsRepository totalsRepository, IncomeRepository incomeRepository, ExpensesRepository expensesRepository)
        {
            _logger = logger;
            _totalsRepository = totalsRepository;
            _incomeRepository = incomeRepository;
            _expensesRepository = expensesRepository;
        }

        public IActionResult Index()
        {
            var incomes = _incomeRepository.GetIncomes();
            decimal sumI = incomes.Sum(x => x.Amount);
            var expenses = _expensesRepository.GetExpenses();
            decimal sumE = expenses.Sum(x => x.Amount);
            decimal balance = sumI - sumE;

            List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(10, sumI),
                new DataPoint(20, sumE)
            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

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
    }
}