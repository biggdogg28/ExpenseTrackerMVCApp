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
        private readonly ExpenseCategoriesRepository _categoryRepository;
        public ExpensesController(ExpensesRepository repository, ExpenseCategoriesRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
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
            var expenseCategory = _categoryRepository.GetExpenseCategories();

            ViewBag.data = expenseCategory;

            return View("Create");
        }

        // POST: ExpensesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            ExpenseModel expense = new ExpenseModel();
            TryUpdateModelAsync(expense);
            _repository.AddExpense(expense);

            return RedirectToAction("Index");
        }

        // GET: ExpensesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ExpenseModel expense = _repository.GetExpenseById(id);
            return View("Edit", expense);
        }

        // POST: ExpensesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            ExpenseModel expense = _repository.GetExpenseById(id);
            TryUpdateModelAsync(expense);
            _repository.UpdateExpense(expense);

            return RedirectToAction("Index");
        }

        // GET: ExpensesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            ExpenseModel expense = _repository.GetExpenseById(id);
            return View("Delete", expense);
        }

        // POST: ExpensesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteExpenseById(id);
            return RedirectToAction("Index");
        }
    }
}
