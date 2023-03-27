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
        private readonly ExpenseCategoriesRepository _expenseCategoryRepository;
        private readonly LocationsRepository _locationsRepository;
        public ExpensesController(ExpensesRepository repository, ExpenseCategoriesRepository expenseCategoryRepository, LocationsRepository locationsRepository)
        {
            _repository = repository;
            _expenseCategoryRepository = expenseCategoryRepository;
            _locationsRepository = locationsRepository;
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
            List<ExpenseCategoryModel> expenseCategory = _expenseCategoryRepository.GetExpenseCategories().ToList();
            List<LocationModel> location = _locationsRepository.GetLocations().ToList();

            ViewBag.dataE = expenseCategory;
            ViewBag.data = location;

            return View("Create");
        }

        // POST: ExpensesController/Create
        [HttpPost]
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
            List<ExpenseCategoryModel> expenseCategory = _expenseCategoryRepository.GetExpenseCategories().ToList();
            List<LocationModel> location = _locationsRepository.GetLocations().ToList();

            ViewBag.dataE = expenseCategory;
            ViewBag.data = location;

            return View("Edit", expense);
        }

        // POST: ExpensesController/Edit/5
        [HttpPost]
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
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteExpenseById(id);
            return RedirectToAction("Index");
        }
    }
}
