using ExpenseTrackerMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerMVCApp.DataContext
{
    public class ExpenseTrackerDataContext : DbContext
    {
        public ExpenseTrackerDataContext(DbContextOptions<ExpenseTrackerDataContext> options) : base(options) { }

        public DbSet<ExpenseCategoryModel> ExpenseCategories { get; set; }
        public DbSet<ExpenseModel> Expenses { get; set; }
        public DbSet<IncomeModel> Income { get; set; }
        public DbSet<IncomeTypeModel> IncomeTypes { get; set; }
        public DbSet<LocationModel> Location { get; set; }
        public DbSet<TotalModel> Total { get; set; }
    }
}
