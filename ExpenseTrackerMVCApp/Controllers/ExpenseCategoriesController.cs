﻿using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerMVCApp.Controllers
{
    public class ExpenseCategoriesController : Controller
    {
        private readonly ExpenseCategoriesRepository _repository;
        public ExpenseCategoriesController(ExpenseCategoriesRepository repository)
        {
            _repository = repository;
        }

        // GET: ExpenseCategoriesController
        public ActionResult Index()
        {
            var expenseCategories = _repository.GetExpenseCategories();
            return View("Index", expenseCategories);
        }

        // GET: ExpenseCategoriesController/Details/5
        public ActionResult Details(Guid id)
        {
            ExpenseCategoryModel expenseCategory = _repository.GetExpenseCategoriesById(id);
            return View("Details", expenseCategory);
        }

        // GET: ExpenseCategoriesController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: ExpenseCategoriesController/Create
        [HttpPost]
        
        public ActionResult Create(IFormCollection collection)
        {
            ExpenseCategoryModel expenseCategory = new ExpenseCategoryModel();
            TryUpdateModelAsync(expenseCategory);
            _repository.AddExpenseCategory(expenseCategory);

            return RedirectToAction("Index");
        }

        // GET: ExpenseCategoriesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ExpenseCategoryModel expenseCategory = _repository.GetExpenseCategoriesById(id);
            return View("Edit", expenseCategory);
        }

        // POST: ExpenseCategoriesController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            ExpenseCategoryModel expenseCategory = new();
            TryUpdateModelAsync(expenseCategory);
            _repository.UpdateExpenseCategory(expenseCategory);

            return RedirectToAction("Index");
        }

        // GET: ExpenseCategoriesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            ExpenseCategoryModel expenseCategory = _repository.GetExpenseCategoriesById(id);
            return View("Delete", expenseCategory);
        }

        // POST: ExpenseCategoriesController/Delete/5
        [HttpPost]
        
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteExpenseCategoryById(id);
            return RedirectToAction("Index");
        }
    }
}
