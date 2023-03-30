using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class ExpensesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public ExpensesRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }

        public DbSet<ExpenseModel> GetExpenses()
        {
            return _context.Expenses;
        }

        public ExpenseModel GetExpenseById(Guid id)
        {
            ExpenseModel expense = _context.Expenses.FirstOrDefault(x => x.IdExpense == id);
            return expense;
            
        }

        public void AddExpense(ExpenseModel model)
        {
            model.IdExpense = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;
            model.UpdatedOn = DateTime.Now;
            _context.Expenses.Add(model);
            _context.SaveChanges();
        }

        public void UpdateExpense(ExpenseModel model)
        {
            //ExpenseCategoryModel expenseCategory = GetExpenseCategoriesById(model.ExpenseCategoryID);
            //if (expenseCategory != null)
            //{
            model.UpdatedOn = DateTime.Now;
            _context.Expenses.Update(model);
            _context.SaveChanges();
            //}
        }

        public void DeleteExpenseById(Guid id)
        {
            ExpenseModel expense = GetExpenseById(id);
            if (expense != null)
            {
                _context.Remove(expense);
                _context.SaveChanges();
            }

        }
    }
}
