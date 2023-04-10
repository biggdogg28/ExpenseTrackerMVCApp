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
    public class LocationsRepositoryTests
    {
        private readonly LocationsRepository _repository;
        private readonly ExpenseTrackerDataContext _contextInMemory;

        public LocationsRepositoryTests()
        {
            _contextInMemory = DBContextHelpers.GetDatabaseContext();
            _repository = new LocationsRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllLocation_ExistExpenses()
        {
            //Arrange
            //Guid id = Guid.NewGuid();

            LocationModel location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            LocationModel location2 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            LocationModel location3 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<LocationModel> list = new List<LocationModel>();
            list.Add(location1);
            list.Add(location2);
            list.Add(location3);
            DBContextHelpers.AddLocation(_contextInMemory, location1);
            DBContextHelpers.AddLocation(_contextInMemory, location2);
            DBContextHelpers.AddLocation(_contextInMemory, location3);


            //Act
            List<LocationModel> dbLocation = _repository.GetLocations().ToList();

            //Assert
            Assert.AreEqual(list.Count, dbLocation.Count);
        }

        [TestMethod]
        public void SameLocationId_ExistExpenses()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            LocationModel location1 = new LocationModel()
            {
                IdLocation = id,
                Name = "Test",
            };

            LocationModel location2 = new LocationModel()
            {
                IdLocation = id,
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<LocationModel> list = new List<LocationModel>();
            list.Add(location1);
            list.Add(location2);

            DBContextHelpers.AddLocation(_contextInMemory, location1);
            DBContextHelpers.AddLocation(_contextInMemory, location2);



            //Act
            List<LocationModel> dbLocation = _repository.GetLocations().ToList();

            //Assert
            
            Assert.AreEqual(1, dbLocation.Count);
        }

        [TestMethod]
        public void GetLocation_WithoutDataInDB()
        {
            //Act
            List<LocationModel> dbLocation = _repository.GetLocations().ToList();

            //Assert
            Assert.AreEqual(0, dbLocation.Count);
        }

        [TestMethod]
        public void GetLocationCategoriesById()
        {
            //Arrange
            LocationModel location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };
            LocationModel location = DBContextHelpers.AddLocation(_contextInMemory, location1);

            Guid id = (Guid)location1.IdLocation;

            //Act
            var result = _repository.GetLocationById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(location1.IdLocation, result.IdLocation);
            Assert.AreEqual(location1.Name, result.Name);
        }

        [TestMethod]
        public void GetLocationById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetLocationById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteLocation_LocationNotExist()
        {

            //Arrage
            Guid id = Guid.NewGuid();


            //Act
            _repository.DeleteLocationById(id);
            var result = _repository.GetLocationById(id);

            //Assert
            Assert.IsNull(result);


        }

        [TestMethod]
        public void DeleteLocation_LocationExist()
        {
            //Assert
            Guid id = Guid.NewGuid();

            LocationModel location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };
            LocationModel Location = DBContextHelpers.AddLocation(_contextInMemory, location1);

            //Act
            _repository.DeleteLocationById(id);
            var result = _repository.GetLocationById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateLocation_LocationExist()
        {
            LocationModel location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };
            LocationModel location = DBContextHelpers.AddLocation(_contextInMemory, location1);
            location.Name = "NameUpdated";
            _repository.UpdateLocation(location);

            LocationModel updatedModel = _repository.GetLocationById((Guid)location1.IdLocation);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(location.Name, updatedModel.Name);
        }

        public void UpdateLocation_LocationNotExists()
        {
            LocationModel location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            _repository.UpdateLocation(location1);

            LocationModel updatedModel = _repository.GetLocationById((Guid)location1.IdLocation);

            Assert.IsNull(updatedModel);
        }
    }
}
