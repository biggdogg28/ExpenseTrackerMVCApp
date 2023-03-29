using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class IncomeController : Controller
    {
        public readonly IncomeRepository _repository;
        public readonly IncomeTypesRepository _incomeTypeRepository;
        public IncomeController(IncomeRepository repository, IncomeTypesRepository incomeTypeRepository)
        {
            _repository = repository;
            _incomeTypeRepository= incomeTypeRepository;
        }

        // GET: IncomesController
        public ActionResult Index()
        {
            var incomes = _repository.GetIncomes();
            return View("Index", incomes);
        }

        // GET: IncomesController/Details/5
        public ActionResult Details(Guid id)
        {
            IncomeModel income = _repository.GetIncomeById(id);
            return View("Details", income);
        }

        // GET: IncomesController/Create
        public ActionResult Create()
        {
            var incomeTypes = _incomeTypeRepository.GetIncomeTypes();

            ViewBag.data = incomeTypes;

            return View("Create");
        }

        // POST: IncomesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            IncomeModel income = new IncomeModel();
            TryUpdateModelAsync(income);
            _repository.AddIncome(income);
            //_totlsRepo.UpdateTotals();
            return RedirectToAction("Index");
            
        }

        // GET: IncomesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            IncomeModel income = _repository.GetIncomeById(id);
            return View("Edit", income);
        }

        // POST: IncomesController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            IncomeModel income = new IncomeModel();
            TryUpdateModelAsync(income);
            _repository.UpdateIncome(income);
            //_totlsRepo.UpdateTotals();
            return RedirectToAction("Index");
        }

        // GET: IncomesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            IncomeModel income = _repository.GetIncomeById(id);
            return View("Delete", income);
        }

        // POST: IncomesController/Delete/5
        [HttpPost]
        
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteIncomeById(id);
            return RedirectToAction("Index");
        }
    }
}
