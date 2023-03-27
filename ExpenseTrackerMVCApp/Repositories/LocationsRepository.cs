using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerMVCApp.Repositories
{
    public class LocationsRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        public LocationsRepository(ExpenseTrackerDataContext context)
        {
            _context = context;
        }

        public DbSet<LocationModel> GetLocations()
        {
            return _context.Location;
        }

        public LocationModel GetLocationById(Guid id)
        {
            LocationModel location = _context.Location.FirstOrDefault(x => x.IdLocation == id);
            return location;
        }

        public void AddLocation(LocationModel model)
        {
            model.IdLocation = Guid.NewGuid();
            _context.Location.Add(model);
            _context.SaveChanges();
        }

        public void UpdateLocation(LocationModel model)
        {
            //ExpenseCategoryModel expenseCategory = GetExpenseCategoriesById(model.ExpenseCategoryID);
            //if (expenseCategory != null)
            //{
            _context.Location.Update(model);
            _context.SaveChanges();
            //}
        }

        public void DeleteLocationById(Guid id)
        {
            LocationModel location = GetLocationById(id);
            if (location != null)
            {
                _context.Remove(location);
                _context.SaveChanges();
            }

        }
    }
}
