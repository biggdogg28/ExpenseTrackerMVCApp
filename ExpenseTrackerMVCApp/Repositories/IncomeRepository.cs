using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class IncomeRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public IncomeRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }

        public DbSet<IncomeModel> GetIncomes()
        {
            return _context.Income;
        }

        public IncomeModel GetIncomeById(Guid id)
        {
            IncomeModel income = _context.Income.FirstOrDefault(x => x.IdIncome == id);
            return income;
        }

        public void AddIncome(IncomeModel model)
        {
            model.IdIncome = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;
            model.UpdatedOn = DateTime.Now;
            _context.Income.Add(model);
            _context.SaveChanges();
        }

        public void UpdateIncome(IncomeModel model)
        {
            //ExpenseCategoryModel expenseCategory = GetExpenseCategoriesById(model.ExpenseCategoryID);
            //if (expenseCategory != null)
            //{
            model.UpdatedOn = DateTime.Now;
            _context.Income.Update(model);
            _context.SaveChanges();
            //}
        }

        public void DeleteIncomeById(Guid id)
        {
            IncomeModel income = GetIncomeById(id);
            if (income != null)
            {
                _context.Remove(income);
                _context.SaveChanges();
            }

        }
    }
}
