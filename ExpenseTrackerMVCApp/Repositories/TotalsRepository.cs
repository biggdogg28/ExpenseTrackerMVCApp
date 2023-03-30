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

        public DbSet<TotalModel> GetTotal()
        {
            return _context.Totals;
        }

        public TotalModel GetTotalById(Guid id)
        {
            TotalModel total = _context.Totals.FirstOrDefault(x => x.IdTotals == id);
            return total;
        }

        public void AddTotals(TotalModel model)
        {
            model.IdTotals = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;
            model.UpdatedOn = DateTime.Now;
            _context.Totals.Add(model);
            _context.SaveChanges();
        }

        public void UpdateTotals(TotalModel model)
        {
            model.UpdatedOn = DateTime.Now;
            _context.Totals.Update(model);
            _context.SaveChanges();
        }

        public void DeleteTotals(Guid id)
        {
            TotalModel total = GetTotalById(id);
            if (total != null)
            {
                _context.Remove(total);
                _context.SaveChanges();
            }

        }

    }
}
