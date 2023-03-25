using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class IncomeRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public IncomeRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }
    }
}
