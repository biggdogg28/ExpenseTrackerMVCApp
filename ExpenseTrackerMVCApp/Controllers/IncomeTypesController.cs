using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class IncomeTypesController : Controller
    {
        private readonly IncomeTypesRepository _repository;
        private readonly IncomeRepository _incomeRepository;
        public IncomeTypesController(IncomeTypesRepository repository, IncomeRepository incomeRepository)
        {
            _repository = repository;
            _incomeRepository = incomeRepository;
        }

        // GET: IncomeTypesController
        public ActionResult Index()
        {
            var incomeTypes = _repository.GetIncomeTypes();
            return View("Index", incomeTypes);
        }

        // GET: IncomeTypesController/Details/5
        public ActionResult Details(Guid id)
        {
            IncomeTypeModel incomeType = _repository.GetIncomeTypeById(id);
            return View("Details", incomeType);
        }

        // GET: IncomeTypesController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: IncomeTypesController/Create
        [HttpPost]
       
        public ActionResult Create(IFormCollection collection)
        {
                IncomeTypeModel incomeType = new IncomeTypeModel();
                TryUpdateModelAsync(incomeType);
                _repository.AddIncomeType(incomeType);

                return RedirectToAction("Index");
        }

        // GET: IncomeTypesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            IncomeTypeModel incomeType = _repository.GetIncomeTypeById(id);
            return View("Edit", incomeType);
        }

        // POST: IncomeTypesController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            IncomeTypeModel incomeType = new();
            TryUpdateModelAsync(incomeType);
            _repository.UpdateIncomeType(incomeType);

            return RedirectToAction("Index");
        }

        // GET: IncomeTypesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_incomeRepository.GetIncomes().Any(x => x.IncomeTypeID == _repository.GetIncomeTypeById(id).IncomeTypeID))
            {
                return RedirectToAction("Error");
            }
            else
            {
                IncomeTypeModel incomeType = _repository.GetIncomeTypeById(id);
                return View("Delete", incomeType);
            }
        }

        // POST: IncomeTypesController/Delete/5
        [HttpPost]
        
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteIncomeTypeById(id);
            return RedirectToAction("Index");
        }
        public ActionResult Error(string message)
        {
            return View("Error", message);
        }
    }
}
