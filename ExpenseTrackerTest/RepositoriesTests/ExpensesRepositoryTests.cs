using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using ExpenseTrackerTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerTest.RepositoriesTests
{
    [TestClass]
    public class ExpensesRepositoryTests
    {
        private readonly ExpensesRepository _repository;
        private readonly ExpenseTrackerDataContext _contextInMemory;

        public ExpensesRepositoryTests()
        {
            _contextInMemory = DBContextHelpers.GetDatabaseContext();
            _repository = new ExpensesRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllExpenses_ExistExpenses()
        {
            //Arrange
            //Guid id = Guid.NewGuid();

            ExpenseModel expense1 = new ExpenseModel()
            {
                IdExpense = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = Guid.NewGuid(),
                Amount = 500,
            };

            Guid locationId = Guid.NewGuid();

            ExpenseModel expense2 = new ExpenseModel()
            {
                IdExpense = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = locationId,
                Amount = 500,
            };

            ExpenseModel expense3 = new ExpenseModel()
            {
                IdExpense = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = locationId,
                Amount = 500,
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<ExpenseModel> list = new List<ExpenseModel>();
            list.Add(expense1);
            list.Add(expense2);
            list.Add(expense3);
            Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense2);
            Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense3);


            //Act
            List<ExpenseModel> dbExpenses = _repository.GetExpenses().ToList();

            //Assert
            Assert.AreEqual(list.Count, dbExpenses.Count);
        }

        [TestMethod]
        public void SameExpenseId_ExistExpenses()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            ExpenseModel expense1 = new ExpenseModel()
            {
                IdExpense = id,
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = Guid.NewGuid(),
                Amount = 500,
            };

            Guid locationId = Guid.NewGuid();

            ExpenseModel expense2 = new ExpenseModel()
            {
                IdExpense = id,
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = locationId,
                Amount = 500,
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<ExpenseModel> list = new List<ExpenseModel>();
            list.Add(expense1);
            list.Add(expense2);
            
            Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense2);
           

            //Act
            List<ExpenseModel> dbExpenses = _repository.GetExpenses().ToList();

            //Assert
            
            Assert.AreEqual(1, dbExpenses.Count);
        }

        [TestMethod]
        public void GetExpenses_WithoutDataInDB()
        {
            //Act
            List<ExpenseModel> dbExpenses = _repository.GetExpenses().ToList();

            //Assert
            Assert.AreEqual(0, dbExpenses.Count);
        }

        [TestMethod]
        public void GetExpensesById()
        {
            //Arrange
            ExpenseModel expense1 = new ExpenseModel()
            {
                IdExpense = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = Guid.NewGuid(),
                Amount = 500,
            };
            ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);

            Guid id = (Guid)expense1.IdExpense;

            //Act
            var result = _repository.GetExpenseById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expense1.ExpenseCategoryID, result.ExpenseCategoryID);
            Assert.AreEqual(expense1.CreatedDate, result.CreatedDate);
            Assert.AreEqual(expense1.UpdatedOn, result.UpdatedOn);
            Assert.AreEqual(expense1.Notes, result.Notes);
            Assert.AreEqual(expense1.Amount, result.Amount);
            Assert.AreEqual(expense1.IdLocation, result.IdLocation);
        }
        
        [TestMethod]
        public void GetExpenseById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetExpenseById(id);

            //Assert
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void DeleteExpense_ExpenseNotExist()
        {

            //Arrage
            Guid id = Guid.NewGuid();


            //Act
            _repository.DeleteExpenseById(id);
            var result = _repository.GetExpenseById(id);

            //Assert
            Assert.IsNull(result);


        }
        
        [TestMethod]
        public void DeleteExpense_ExpenseExist()
        {
            //Assert
            Guid id = Guid.NewGuid();

            ExpenseModel expense1 = new ExpenseModel()
            {
                IdExpense = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = Guid.NewGuid(),
                Amount = 500,
            };
            ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);

            //Act
            _repository.DeleteExpenseById(id);
            var result = _repository.GetExpenseById(id);

            //Assert
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void UpdateExpense_ExpenseExist()
        {
            ExpenseModel expense1 = new ExpenseModel()
            {
                IdExpense = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = Guid.NewGuid(),
                Amount = 500,
            };
            ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            expense.Notes = "noteUpdate";
            _repository.UpdateExpense(expense);

            ExpenseModel updatedModel = _repository.GetExpenseById((Guid)expense1.IdExpense);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(expense.Notes, updatedModel.Notes);
        }
        
        public void UpdateExpense_ExpenseNotExists()
        {
            ExpenseModel expense1 = new ExpenseModel()
            {
                IdExpense = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                ExpenseCategoryID = Guid.NewGuid(),
                IdLocation = Guid.NewGuid(),
                Amount = 500,
            };

            _repository.UpdateExpense(expense1);

            ExpenseModel updatedModel = _repository.GetExpenseById((Guid)expense1.IdExpense);

            Assert.IsNull(updatedModel);
        }
    }
}
