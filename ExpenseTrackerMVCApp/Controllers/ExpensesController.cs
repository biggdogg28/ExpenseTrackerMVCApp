using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpensesRepository _repository;
        public ExpensesController(ExpensesRepository repository)
        {
            _repository = repository;
        }

        // GET: ExpensesController
        public ActionResult Index()
        {
            var expenses = _repository.GetExpenses();
            return View("Index", expenses);
        }

        // GET: ExpensesController/Details/5
        public ActionResult Details(Guid id)
        {
            ExpenseModel expense = _repository.GetExpenseById(id);
            return View("Details", expense);
        }

        // GET: ExpensesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpensesController/Create
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

        // GET: ExpensesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: ExpensesController/Edit/5
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

        // GET: ExpensesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: ExpensesController/Delete/5
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
