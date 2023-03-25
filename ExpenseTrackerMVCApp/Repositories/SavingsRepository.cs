using ExpenseTrackerMVCApp.DataContext;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class SavingsRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public SavingsRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }
    }
}
