using ExpenseTrackerMVCApp.DataContext;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class ExpensesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public ExpensesRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }
    }
}
