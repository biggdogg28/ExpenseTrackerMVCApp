using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class TotalsController : Controller
    {
        private readonly TotalsRepository _totalsRepository;
        private readonly ExpensesRepository _expensesRepository;
        private readonly IncomeRepository _incomeRepository;
        public TotalsController(TotalsRepository totalsRepository, ExpensesRepository expensesRepository, IncomeRepository incomeRepository)
        {
            _totalsRepository = totalsRepository;
            _expensesRepository = expensesRepository;
            _incomeRepository = incomeRepository;
        }

        // GET: TotalsController
        public ActionResult Index()
        {
            var incomes = _incomeRepository.GetIncomes();
            decimal sumI = incomes.Sum(x => x.Amount);
            var expenses = _expensesRepository.GetExpenses();
            decimal sumE = expenses.Sum(x => x.Amount);
            TotalModel model = new TotalModel() { TotalExpenses = sumI, TotalIncome = sumE };
            _totalsRepository.AddTotals(model);
            return View("Index", model);
        }

        // GET: TotalsController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: TotalsController/Create
        public ActionResult Create()
        {
            return View("Overview");
        }

        // POST: TotalsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TotalsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: TotalsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TotalsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: TotalsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
