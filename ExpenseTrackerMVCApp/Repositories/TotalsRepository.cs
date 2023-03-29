using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class TotalsRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public TotalsRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }

        public DbSet<ExpenseModel> GetExpenses()
        {
            return _context.Expenses;
        }
        public DbSet<IncomeModel> GetIncome()
        {
            return _context.Income;
        }

        public void AddTotals(TotalModel model)
        {
            model.IdTotals = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;
            model.UpdatedOn = DateTime.Now;
            _context.Total.Add(model);
            _context.SaveChanges();
        }

        //public void AddExpenseAmount(TotalModel model)
        //{
        //    model.IdTotals = Guid.NewGuid();
        //    _context.Expenses.Select(a => a.Amount);
        //    _context.SaveChanges();
        //}

    }
}
