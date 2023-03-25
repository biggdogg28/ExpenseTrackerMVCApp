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
            return _context.Incomes;
        }

        public IncomeModel GetIncomeById(Guid id)
        {
            IncomeModel income = _context.Incomes.FirstOrDefault(x => x.IncomeTypeID == id);
            return income;
        }

        public void AddIncome(IncomeModel model)
        {
            model.IncomeTypeID = Guid.NewGuid();
            _context.Incomes.Add(model);
            _context.SaveChanges();
        }

        public void UpdateIncome(IncomeModel model)
        {
            //ExpenseCategoryModel expenseCategory = GetExpenseCategoriesById(model.ExpenseCategoryID);
            //if (expenseCategory != null)
            //{
            _context.Incomes.Update(model);
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
