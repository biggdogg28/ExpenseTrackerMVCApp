using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Models;
using ExpenseTrackerMVCApp.Repositories;
using ExpenseTrackerTest.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace ExpenseTrackerTest.RepositoriesTests
{
    [TestClass]
    public class ExpenseCategoriesRepositoryTests
    {
        private readonly ExpenseCategoriesRepository _repository;
        private readonly ExpenseTrackerDataContext _contextInMemory;

        public ExpenseCategoriesRepositoryTests()
        {
            _contextInMemory = DBContextHelpers.GetDatabaseContext();
            _repository = new ExpenseCategoriesRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllExpenseCategories_ExistExpenses()
        {
            //Arrange
            //Guid id = Guid.NewGuid();

            ExpenseCategoryModel expenseCategory1 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = Guid.NewGuid(),
                Name= "Test",
            };

            ExpenseCategoryModel expenseCategory2 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = Guid.NewGuid(),
                Name = "Test",
            };

            ExpenseCategoryModel expenseCategory3 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = Guid.NewGuid(),
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<ExpenseCategoryModel> list = new List<ExpenseCategoryModel>();
            list.Add(expenseCategory1);
            list.Add(expenseCategory2);
            list.Add(expenseCategory3);
            Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory1);
            Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory2);
            Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory3);


            //Act
            List<ExpenseCategoryModel> dbExpenseCategories = _repository.GetExpenseCategories().ToList();

            //Assert
            Assert.AreEqual(list.Count, dbExpenseCategories.Count);
        }

        [TestMethod]
        public void SameExpenseCategoryId_ExistExpenses()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            ExpenseCategoryModel expenseCategory1 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = id,
                Name = "Test",
            };

            ExpenseCategoryModel expenseCategory2 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = id,
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<ExpenseCategoryModel> list = new List<ExpenseCategoryModel>();
            list.Add(expenseCategory1);
            list.Add(expenseCategory2);
            
            Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory1);
            Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory2);
            


            //Act
            List<ExpenseCategoryModel> dbExpenseCategories = _repository.GetExpenseCategories().ToList();

            //Assert
            //Expected to fail since there cannot be 2 ExpenseCategories with the same ID
            Assert.AreEqual(list.Count, dbExpenseCategories.Count);
        }

        [TestMethod]
        public void GetExpenseCategories_WithoutDataInDB()
        {
            //Act
            List<ExpenseCategoryModel> dbExpenseCategories = _repository.GetExpenseCategories().ToList();

            //Assert
            Assert.AreEqual(0, dbExpenseCategories.Count);
        }

        [TestMethod]
        public void GetExpenseCategoryCategoriesById()
        {
            //Arrange
            ExpenseCategoryModel expenseCategory1 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = Guid.NewGuid(),
                Name = "Test",
            };
            ExpenseCategoryModel expenseCategory = Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory1);

            Guid id = (Guid)expenseCategory1.ExpenseCategoryID;

            //Act
            var result = _repository.GetExpenseCategoriesById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expenseCategory1.ExpenseCategoryID, result.ExpenseCategoryID);
            Assert.AreEqual(expenseCategory1.Name, result.Name);
        }

        [TestMethod]
        public void GetExpenseCategoryById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetExpenseCategoriesById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteExpenseCategory_ExpenseCategoryNotExist()
        {

            //Arrage
            Guid id = Guid.NewGuid();


            //Act
            _repository.DeleteExpenseCategoryById(id);
            var result = _repository.GetExpenseCategoriesById(id);

            //Assert
            Assert.IsNull(result);


        }

        [TestMethod]
        public void DeleteExpenseCategory_ExpenseCategoryExist()
        {
            //Assert
            Guid id = Guid.NewGuid();

            ExpenseCategoryModel expenseCategory1 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = Guid.NewGuid(),
                Name = "Test",
            };
            ExpenseCategoryModel expenseCategory = Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory1);

            //Act
            _repository.DeleteExpenseCategoryById(id);
            var result = _repository.GetExpenseCategoriesById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateExpenseCategory_ExpenseCategoryExist()
        {
            ExpenseCategoryModel expenseCategory1 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = Guid.NewGuid(),
                Name = "Test",
            };
            ExpenseCategoryModel expenseCategory = Helpers.DBContextHelpers.AddExpenseCategory(_contextInMemory, expenseCategory1);
            expenseCategory.Name = "NameUpdated";
            _repository.UpdateExpenseCategory(expenseCategory);

            ExpenseCategoryModel updatedModel = _repository.GetExpenseCategoriesById((Guid)expenseCategory1.ExpenseCategoryID);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(expenseCategory.Name, updatedModel.Name);
        }

        public void UpdateExpenseCategory_ExpenseCategoryNotExists()
        {
            ExpenseCategoryModel expenseCategory1 = new ExpenseCategoryModel()
            {
                ExpenseCategoryID = Guid.NewGuid(),
                Name = "Test",
            };

            _repository.UpdateExpenseCategory(expenseCategory1);

            ExpenseCategoryModel updatedModel = _repository.GetExpenseCategoriesById((Guid)expenseCategory1.ExpenseCategoryID);

            Assert.IsNull(updatedModel);
        }

    }
}
