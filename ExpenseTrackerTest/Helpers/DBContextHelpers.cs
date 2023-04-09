using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExpenseTrackerTest.Helpers
{
    public class DBContextHelpers
    {
        public static ExpenseTrackerDataContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ExpenseTrackerDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var databaseContext = new ExpenseTrackerDataContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        public static ExpenseModel AddExpense(ExpenseTrackerDataContext context, ExpenseModel expense)
        {
            context.Add(expense);
            context.SaveChangesAsync();
            context.Entry(expense).State = EntityState.Detached;
            return expense;
        }
        public static ExpenseCategoryModel AddExpenseCategory(ExpenseTrackerDataContext context, ExpenseCategoryModel expenseCategory)
        {
            context.Add(expenseCategory);
            context.SaveChangesAsync();
            context.Entry(expenseCategory).State = EntityState.Detached;
            return expenseCategory;
        }
        public static TotalModel AddExpenseCategory(ExpenseTrackerDataContext context, TotalModel total)
        {
            context.Add(total);
            context.SaveChangesAsync();
            context.Entry(total).State = EntityState.Detached;
            return total;
        }
        public static IncomeModel AddExpenseCategory(ExpenseTrackerDataContext context, IncomeModel income)
        {
            context.Add(income);
            context.SaveChangesAsync();
            context.Entry(income).State = EntityState.Detached;
            return income;
        }

        public static IncomeTypeModel AddExpenseCategory(ExpenseTrackerDataContext context, IncomeTypeModel incomeType)
        {
            context.Add(incomeType);
            context.SaveChangesAsync();
            context.Entry(incomeType).State = EntityState.Detached;
            return incomeType;
        }

        public static LocationModel AddExpenseCategory(ExpenseTrackerDataContext context, LocationModel location)
        {
            context.Add(location);
            context.SaveChangesAsync();
            context.Entry(location).State = EntityState.Detached;
            return location;
        }

    }
}

