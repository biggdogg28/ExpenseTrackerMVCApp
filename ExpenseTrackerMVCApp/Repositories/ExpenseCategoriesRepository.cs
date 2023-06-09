﻿using Azure;
using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class ExpenseCategoriesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public ExpenseCategoriesRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }

        public DbSet<ExpenseCategoryModel> GetExpenseCategories()
        {
            return _context.ExpenseCategory;
        }

        public ExpenseCategoryModel GetExpenseCategoriesById(Guid id)
        {
            ExpenseCategoryModel expenseCategory = _context.ExpenseCategory.FirstOrDefault(x => x.ExpenseCategoryID == id);
            return expenseCategory;
        }

        public void AddExpenseCategory(ExpenseCategoryModel model)
        {
            model.ExpenseCategoryID = Guid.NewGuid();
            _context.ExpenseCategory.Add(model);
            _context.SaveChanges();
        }

        public void UpdateExpenseCategory(ExpenseCategoryModel model)
        {
            //ExpenseCategoryModel expenseCategory = GetExpenseCategoriesById(model.ExpenseCategoryID);
            //if (expenseCategory != null)
            //{
                _context.ExpenseCategory.Update(model);
                _context.SaveChanges();
            //}
        }
        
        public void DeleteExpenseCategoryById(Guid id)
        {
            ExpenseCategoryModel expenseCategory = GetExpenseCategoriesById(id);
            if (expenseCategory != null)
            {
                _context.Remove(expenseCategory);
                _context.SaveChanges();
            }
        }

    }
}
