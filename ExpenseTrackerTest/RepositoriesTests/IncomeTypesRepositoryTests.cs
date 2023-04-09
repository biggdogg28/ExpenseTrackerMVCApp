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
    public class IncomeTypesRepositoryTests
    {
        private readonly IncomeTypesRepository _repository;
        private readonly ExpenseTrackerDataContext _contextInMemory;

        public IncomeTypesRepositoryTests()
        {
            _contextInMemory = DBContextHelpers.GetDatabaseContext();
            _repository = new IncomeTypesRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllIncomeType_ExistExpenses()
        {
            //Arrange
            //Guid id = Guid.NewGuid();

            IncomeTypeModel IncomeType1 = new IncomeTypeModel()
            {
                IncomeTypeID = Guid.NewGuid(),
                Name = "Test",
            };

            IncomeTypeModel IncomeType2 = new IncomeTypeModel()
            {
                IncomeTypeID = Guid.NewGuid(),
                Name = "Test",
            };

            IncomeTypeModel IncomeType3 = new IncomeTypeModel()
            {
                IncomeTypeID = Guid.NewGuid(),
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<IncomeTypeModel> list = new List<IncomeTypeModel>();
            list.Add(IncomeType1);
            list.Add(IncomeType2);
            list.Add(IncomeType3);
            Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType1);
            Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType2);
            Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType3);


            //Act
            List<IncomeTypeModel> dbIncomeType = _repository.GetIncomeTypes().ToList();

            //Assert
            Assert.AreEqual(list.Count, dbIncomeType.Count);
        }

        [TestMethod]
        public void SameIncomeTypeId_ExistExpenses()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            IncomeTypeModel IncomeType1 = new IncomeTypeModel()
            {
                IncomeTypeID = id,
                Name = "Test",
            };

            IncomeTypeModel IncomeType2 = new IncomeTypeModel()
            {
                IncomeTypeID = id,
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<IncomeTypeModel> list = new List<IncomeTypeModel>();
            list.Add(IncomeType1);
            list.Add(IncomeType2);

            Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType1);
            Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType2);



            //Act
            List<IncomeTypeModel> dbIncomeType = _repository.GetIncomeTypes().ToList();

            //Assert
            //Expected to fail since there cannot be 2 IncomeType with the same ID
            Assert.AreEqual(list.Count, dbIncomeType.Count);
        }

        [TestMethod]
        public void GetIncomeType_WithoutDataInDB()
        {
            //Act
            List<IncomeTypeModel> dbIncomeType = _repository.GetIncomeTypes().ToList();

            //Assert
            Assert.AreEqual(0, dbIncomeType.Count);
        }

        [TestMethod]
        public void GetIncomeTypeCategoriesById()
        {
            //Arrange
            IncomeTypeModel IncomeType1 = new IncomeTypeModel()
            {
                IncomeTypeID = Guid.NewGuid(),
                Name = "Test",
            };
            IncomeTypeModel IncomeType = Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType1);

            Guid id = (Guid)IncomeType1.IncomeTypeID;

            //Act
            var result = _repository.GetIncomeTypeById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(IncomeType1.IncomeTypeID, result.IncomeTypeID);
            Assert.AreEqual(IncomeType1.Name, result.Name);
        }

        [TestMethod]
        public void GetIncomeTypeById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetIncomeTypeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteIncomeType_IncomeTypeNotExist()
        {

            //Arrage
            Guid id = Guid.NewGuid();


            //Act
            _repository.DeleteIncomeTypeById(id);
            var result = _repository.GetIncomeTypeById(id);

            //Assert
            Assert.IsNull(result);


        }

        [TestMethod]
        public void DeleteIncomeType_IncomeTypeExist()
        {
            //Assert
            Guid id = Guid.NewGuid();

            IncomeTypeModel IncomeType1 = new IncomeTypeModel()
            {
                IncomeTypeID = Guid.NewGuid(),
                Name = "Test",
            };
            IncomeTypeModel IncomeType = Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType1);

            //Act
            _repository.DeleteIncomeTypeById(id);
            var result = _repository.GetIncomeTypeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateIncomeType_IncomeTypeExist()
        {
            IncomeTypeModel IncomeType1 = new IncomeTypeModel()
            {
                IncomeTypeID = Guid.NewGuid(),
                Name = "Test",
            };
            IncomeTypeModel IncomeType = Helpers.DBContextHelpers.AddIncomeType(_contextInMemory, IncomeType1);
            IncomeType.Name = "NameUpdated";
            _repository.UpdateIncomeType(IncomeType);

            IncomeTypeModel updatedModel = _repository.GetIncomeTypeById((Guid)IncomeType1.IncomeTypeID);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(IncomeType.Name, updatedModel.Name);
        }

        public void UpdateIncomeType_IncomeTypeNotExists()
        {
            IncomeTypeModel IncomeType1 = new IncomeTypeModel()
            {
                IncomeTypeID = Guid.NewGuid(),
                Name = "Test",
            };

            _repository.UpdateIncomeType(IncomeType1);

            IncomeTypeModel updatedModel = _repository.GetIncomeTypeById((Guid)IncomeType1.IncomeTypeID);

            Assert.IsNull(updatedModel);
        }
    }
}
