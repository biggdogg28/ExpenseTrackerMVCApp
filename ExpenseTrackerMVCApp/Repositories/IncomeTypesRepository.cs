using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class IncomeTypesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public IncomeTypesRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }
        public DbSet<IncomeTypeModel> GetIncomeTypes()
        {
            return _context.IncomeTypes;
        }

        public IncomeTypeModel GetIncomeTypeById(Guid id)
        {
            IncomeTypeModel incomeType = _context.IncomeTypes.FirstOrDefault(x => x.IncomeTypeID == id);
            return incomeType;
        }

        public void AddIncomeType(IncomeTypeModel model)
        {
            model.IncomeTypeID = Guid.NewGuid();
            _context.IncomeTypes.Add(model);
            _context.SaveChanges();
        }

        public void UpdateIncomeType(IncomeTypeModel model)
        {
            //ExpenseCategoryModel expenseCategory = GetExpenseCategoriesById(model.ExpenseCategoryID);
            //if (expenseCategory != null)
            //{
            _context.IncomeTypes.Update(model);
            _context.SaveChanges();
            //}
        }

        public void DeleteIncomeTypeById(Guid id)
        {
            IncomeTypeModel incomeType = GetIncomeTypeById(id);
            if (incomeType != null)
            {
                _context.Remove(incomeType);
                _context.SaveChanges();
            }

        }
    }
}
