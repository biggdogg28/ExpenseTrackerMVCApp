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
    public class IncomeRepositoryTests
    {
        private readonly IncomeRepository _repository;
        private readonly ExpenseTrackerDataContext _contextInMemory;

        public IncomeRepositoryTests()
        {
            _contextInMemory = DBContextHelpers.GetDatabaseContext();
            _repository = new IncomeRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllIncome_ExistIncome()
        {
            //Arrange
            //Guid id = Guid.NewGuid();

            IncomeModel income1 = new IncomeModel()
            {
                IdIncome = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };

            Guid locationId = Guid.NewGuid();

            IncomeModel income2 = new IncomeModel()
            {
                IdIncome = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };

            IncomeModel income3 = new IncomeModel()
            {
                IdIncome = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };

            //IncomeModel Income = Helpers.DBContextHelpers.AddIncome(_contextInMemory, Income1);
            List<IncomeModel> list = new List<IncomeModel>();
            list.Add(income1);
            list.Add(income2);
            list.Add(income3);
            Helpers.DBContextHelpers.AddIncome(_contextInMemory, income1);
            Helpers.DBContextHelpers.AddIncome(_contextInMemory, income2);
            Helpers.DBContextHelpers.AddIncome(_contextInMemory, income3);


            //Act
            List<IncomeModel> dbIncome = _repository.GetIncomes().ToList();

            //Assert
            Assert.AreEqual(list.Count, dbIncome.Count);
        }

        [TestMethod]
        public void SameIncomeId_ExistIncome()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            IncomeModel income1 = new IncomeModel()
            {
                IdIncome = id,
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };

            IncomeModel income2 = new IncomeModel()
            {
                IdIncome = id,
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };

            //IncomeModel Income = Helpers.DBContextHelpers.AddIncome(_contextInMemory, Income1);
            List<IncomeModel> list = new List<IncomeModel>();
            list.Add(income1);
            list.Add(income2);

            Helpers.DBContextHelpers.AddIncome(_contextInMemory, income1);
            Helpers.DBContextHelpers.AddIncome(_contextInMemory, income2);


            //Act
            List<IncomeModel> dbIncome = _repository.GetIncomes().ToList();

            //Assert
            //Expected to fail since there cannot be 2 Income with the same ID
            Assert.AreEqual(list.Count, dbIncome.Count);
        }

        [TestMethod]
        public void GetIncome_WithoutDataInDB()
        {
            //Act
            List<IncomeModel> dbIncome = _repository.GetIncomes().ToList();

            //Assert
            Assert.AreEqual(0, dbIncome.Count);
        }

        [TestMethod]
        public void GetIncomeById()
        {
            //Arrange
            IncomeModel income1 = new IncomeModel()
            {
                IdIncome = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };
            IncomeModel Income = Helpers.DBContextHelpers.AddIncome(_contextInMemory, income1);

            Guid id = (Guid)income1.IdIncome;

            //Act
            var result = _repository.GetIncomeById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(income1.IdIncome, result.IdIncome);
            Assert.AreEqual(income1.CreatedDate, result.CreatedDate);
            Assert.AreEqual(income1.UpdatedOn, result.UpdatedOn);
            Assert.AreEqual(income1.Notes, result.Notes);
            Assert.AreEqual(income1.Amount, result.Amount);
            Assert.AreEqual(income1.IncomeTypeID, result.IncomeTypeID);
            Assert.AreEqual(income1.Name, result.Name);
        }

        [TestMethod]
        public void GetIncomeById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetIncomeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteIncome_IncomeNotExist()
        {

            //Arrage
            Guid id = Guid.NewGuid();


            //Act
            _repository.DeleteIncomeById(id);
            var result = _repository.GetIncomeById(id);

            //Assert
            Assert.IsNull(result);


        }

        [TestMethod]
        public void DeleteIncome_IncomeExist()
        {
            //Assert
            Guid id = Guid.NewGuid();

            IncomeModel Income1 = new IncomeModel()
            {
                IdIncome = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };
            IncomeModel Income = Helpers.DBContextHelpers.AddIncome(_contextInMemory, Income1);

            //Act
            _repository.DeleteIncomeById(id);
            var result = _repository.GetIncomeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateIncome_IncomeExist()
        {
            IncomeModel income1 = new IncomeModel()
            {
                IdIncome = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };
            IncomeModel income = Helpers.DBContextHelpers.AddIncome(_contextInMemory, income1);
            income.Notes = "noteUpdate";
            _repository.UpdateIncome(income);

            IncomeModel updatedModel = _repository.GetIncomeById((Guid)income1.IdIncome);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(income.Notes, updatedModel.Notes);
        }

        public void UpdateIncome_IncomeNotExists()
        {
            IncomeModel income1 = new IncomeModel()
            {
                IdIncome = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                Notes = "Tags2",
                Name = "Name",
                IncomeTypeID = Guid.NewGuid(),
                Amount = 500,
            };

            _repository.UpdateIncome(income1);

            IncomeModel updatedModel = _repository.GetIncomeById((Guid)income1.IdIncome);

            Assert.IsNull(updatedModel);
        }
    }
}
