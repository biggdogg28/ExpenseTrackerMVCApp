using ExpenseTrackerMVCApp.DataContext;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class LocationsRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public LocationsRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }
    }
}
