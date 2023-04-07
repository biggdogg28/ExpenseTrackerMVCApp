using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LocationsRepository _locationsRepository;
        private readonly ExpensesRepository _expenseRepository;
        public LocationsController(LocationsRepository locationsRepository, ExpensesRepository expenseRepository)
        {
            _locationsRepository = locationsRepository;
            _expenseRepository = expenseRepository;
        }
        // GET: LocationsController
        public ActionResult Index()
        {
            var locations = _locationsRepository.GetLocations();
            return View("Index", locations);
        }

        // GET: LocationsController/Details/5
        public ActionResult Details(Guid id)
        {
            LocationModel location = _locationsRepository.GetLocationById(id);
            return View("Details", location);
        }

        // GET: LocationsController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: LocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var location = new LocationModel();
            TryUpdateModelAsync(location);
            _locationsRepository.AddLocation(location);

            return RedirectToAction("Index");
        }

        // GET: LocationsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            LocationModel location = _locationsRepository.GetLocationById(id);
            return View("Edit", location);
        }

        // POST: LocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            LocationModel location = new LocationModel();
            TryUpdateModelAsync(location);
            _locationsRepository.UpdateLocation(location);
            return RedirectToAction("Index");
        }

        // GET: LocationsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_expenseRepository.GetExpenses().Any(x => x.IdLocation == _locationsRepository.GetLocationById(id).IdLocation))
            {
                return RedirectToAction("Error");
            }
            else
            {
                LocationModel location = _locationsRepository.GetLocationById(id);
                return View("Delete", location);
            }
        }

        // POST: LocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _locationsRepository.DeleteLocationById(id);
            return RedirectToAction("Index");
        }
        public ActionResult Error(string message)
        {
            return View("Error", message);
        }
    }
}
