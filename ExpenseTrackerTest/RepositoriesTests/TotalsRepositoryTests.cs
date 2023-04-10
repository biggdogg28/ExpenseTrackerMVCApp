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
    public class TotalsRepositoryTests
    {
        private readonly TotalsRepository _repository;
        private readonly ExpenseTrackerDataContext _contextInMemory;

        public TotalsRepositoryTests()
        {
            _contextInMemory = DBContextHelpers.GetDatabaseContext();
            _repository = new TotalsRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllTotals_ExistTotals()
        {
            //Arrange
            //Guid id = Guid.NewGuid();

            TotalModel total1 = new TotalModel()
            {
                IdTotals = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };

            Guid locationId = Guid.NewGuid();

            TotalModel total2 = new TotalModel()
            {
                IdTotals = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };

            TotalModel total3 = new TotalModel()
            {
                IdTotals = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };

            TotalModel total = Helpers.DBContextHelpers.AddTotal(_contextInMemory, total1);
            List<TotalModel> list = new List<TotalModel>();
            list.Add(total1);
            list.Add(total2);
            list.Add(total3);
            Helpers.DBContextHelpers.AddTotal(_contextInMemory, total1);
            Helpers.DBContextHelpers.AddTotal(_contextInMemory, total2);
            Helpers.DBContextHelpers.AddTotal(_contextInMemory, total3);


            //Act
            List<TotalModel> dbTotals = _repository.GetTotal().ToList();

            //Assert
            Assert.AreEqual(list.Count, dbTotals.Count);
        }

        [TestMethod]
        public void SameTotalId_ExistTotals()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            TotalModel total1 = new TotalModel()
            {
                IdTotals = id,
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };

            TotalModel total2 = new TotalModel()
            {
                IdTotals = id,
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };


            //TotalModel Total = Helpers.DBContextHelpers.AddTotal(_contextInMemory, Total1);
            List<TotalModel> list = new List<TotalModel>();
            list.Add(total1);
            list.Add(total2);

            Helpers.DBContextHelpers.AddTotal(_contextInMemory, total1);
            Helpers.DBContextHelpers.AddTotal(_contextInMemory, total2);


            //Act
            List<TotalModel> dbTotals = _repository.GetTotal().ToList();

            //Assert
            
            Assert.AreEqual(1, dbTotals.Count);
        }

        [TestMethod]
        public void GetTotals_WithoutDataInDB()
        {
            //Act
            List<TotalModel> dbTotals = _repository.GetTotal().ToList();

            //Assert
            Assert.AreEqual(0, dbTotals.Count);
        }

        [TestMethod]
        public void GetTotalsById()
        {
            //Arrange
            TotalModel total1 = new TotalModel()
            {
                IdTotals = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };

            TotalModel total = Helpers.DBContextHelpers.AddTotal(_contextInMemory, total1);

            Guid id = (Guid)total1.IdTotals;

            //Act
            var result = _repository.GetTotalById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(total1.IdTotals, result.IdTotals);
            Assert.AreEqual(total1.CreatedDate, result.CreatedDate);
            Assert.AreEqual(total1.UpdatedOn, result.UpdatedOn);
            Assert.AreEqual(total1.TotalIncome, result.TotalIncome);
            Assert.AreEqual(total1.TotalExpenses, result.TotalExpenses);
            Assert.AreEqual(total1.Balance, result.Balance);
        }

        [TestMethod]
        public void GetTotalById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetTotalById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteTotal_TotalNotExist()
        {

            //Arrage
            Guid id = Guid.NewGuid();


            //Act
            _repository.DeleteTotalsById(id);
            var result = _repository.GetTotalById(id);

            //Assert
            Assert.IsNull(result);


        }

        [TestMethod]
        public void DeleteTotal_TotalExist()
        {
            //Assert
            Guid id = Guid.NewGuid();

            TotalModel total1 = new TotalModel()
            {
                IdTotals = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };
            TotalModel Total = Helpers.DBContextHelpers.AddTotal(_contextInMemory, total1);

            //Act
            _repository.DeleteTotalsById(id);
            var result = _repository.GetTotalById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateTotal_TotalExist()
        {
            TotalModel total1 = new TotalModel()
            {
                IdTotals = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };
            TotalModel total = Helpers.DBContextHelpers.AddTotal(_contextInMemory, total1);
            total.UpdatedOn = DateTime.Now;
            _repository.UpdateTotals(total);

            TotalModel updatedModel = _repository.GetTotalById((Guid)total1.IdTotals);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(total.UpdatedOn, updatedModel.UpdatedOn);
        }

        public void UpdateTotal_TotalNotExists()
        {
            TotalModel total1 = new TotalModel()
            {
                IdTotals = Guid.NewGuid(),
                CreatedDate = new DateTime(2023, 05, 02),
                UpdatedOn = new DateTime(2023, 05, 02),
                TotalExpenses = 500,
                TotalIncome = 600,
                Balance = 100,
            };

            _repository.UpdateTotals(total1);

            TotalModel updatedModel = _repository.GetTotalById((Guid)total1.IdTotals);

            Assert.IsNull(updatedModel);
        }
    }
}
