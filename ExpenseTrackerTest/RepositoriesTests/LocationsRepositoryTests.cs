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

            LocationModel Location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            LocationModel Location2 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            LocationModel Location3 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<LocationModel> list = new List<LocationModel>();
            list.Add(Location1);
            list.Add(Location2);
            list.Add(Location3);
            Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location1);
            Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location2);
            Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location3);


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

            LocationModel Location1 = new LocationModel()
            {
                IdLocation = id,
                Name = "Test",
            };

            LocationModel Location2 = new LocationModel()
            {
                IdLocation = id,
                Name = "Test",
            };

            //ExpenseModel expense = Helpers.DBContextHelpers.AddExpense(_contextInMemory, expense1);
            List<LocationModel> list = new List<LocationModel>();
            list.Add(Location1);
            list.Add(Location2);

            Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location1);
            Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location2);



            //Act
            List<LocationModel> dbLocation = _repository.GetLocations().ToList();

            //Assert
            //Expected to fail since there cannot be 2 Location with the same ID
            Assert.AreEqual(list.Count, dbLocation.Count);
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
            LocationModel Location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };
            LocationModel Location = Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location1);

            Guid id = (Guid)Location1.IdLocation;

            //Act
            var result = _repository.GetLocationById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Location1.IdLocation, result.IdLocation);
            Assert.AreEqual(Location1.Name, result.Name);
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

            LocationModel Location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };
            LocationModel Location = Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location1);

            //Act
            _repository.DeleteLocationById(id);
            var result = _repository.GetLocationById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateLocation_LocationExist()
        {
            LocationModel Location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };
            LocationModel Location = Helpers.DBContextHelpers.AddLocation(_contextInMemory, Location1);
            Location.Name = "NameUpdated";
            _repository.UpdateLocation(Location);

            LocationModel updatedModel = _repository.GetLocationById((Guid)Location1.LocationID);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(Location.Name, updatedModel.Name);
        }

        public void UpdateLocation_LocationNotExists()
        {
            LocationModel Location1 = new LocationModel()
            {
                IdLocation = Guid.NewGuid(),
                Name = "Test",
            };

            _repository.UpdateLocation(Location1);

            LocationModel updatedModel = _repository.GetLocationById((Guid)Location1.LocationID);

            Assert.IsNull(updatedModel);
        }
    }
}
