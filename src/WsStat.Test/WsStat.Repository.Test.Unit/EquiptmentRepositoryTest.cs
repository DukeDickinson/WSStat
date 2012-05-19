using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSStat.Repository;
using WSStat.Model;
using Rhino.Mocks;
using System.Data.Entity;
using WSStat.Test.Helpers;
using WSStat.Common.Logging;

namespace WSStat.Repository.Test.Unit
{
    [TestClass]
    public class EquiptmentRepositoryTest
    {
        private IWSStatContext stubEntities;
        private ILogger stubLogger;

        [TestInitialize]
        public void Initialise()
        {
            stubEntities = MockRepository.GenerateStub<IWSStatContext>();
            stubLogger = MockRepository.GenerateStub<ILogger>();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void AddManufacturer()
        {
            // Arrange
            var stubManufacturers = new InMemoryDbSet<Manufacturer>();
            var manufacturer = new Manufacturer() { Name = "Dummy" };
            stubEntities.Manufacturers = stubManufacturers;

            // Act
            var sut = new EquipmentRepository(stubEntities, stubLogger);
            sut.AddManufacturer(manufacturer);

            // Assert
            Assert.AreEqual(1, stubManufacturers.Count(), "Manufacturers count incorrect");
        }

        [TestMethod]
        public void AddBoard()
        {
            // Arrange
            var stubBoards = new InMemoryDbSet<Board>();
            var board = new Board() { Model = new BoardModel { Name = "Dummy" }, Volume = 1 };
            stubEntities.Boards = stubBoards;

            // Act
            var sut = new EquipmentRepository(stubEntities, stubLogger);
            sut.AddBoard(board);

            // Assert
            Assert.AreEqual(1, stubBoards.Count(), "Boards count incorrect");
        }

        [TestMethod]
        public void AddSail()
        {
            // Arrange
            var stubSails = new InMemoryDbSet<Sail>();
            var sail = new Sail() { Model = new SailModel { Name = "Dummy" }, Size = 4.7 };
            stubEntities.Sails = stubSails;

            // Act
            var sut = new EquipmentRepository(stubEntities, stubLogger);
            sut.AddSail(sail);

            // Assert
            Assert.AreEqual(1, stubSails.Count(), "Sails count incorrect");
        }



        //[TestMethod]
        //public void AddManufacturerThatAlreadyExistsDoesntAdd()
        //{ 
        //    // Arrange
        //    var stubManufacturers = new InMemoryDbSet<Manufacturer>();
        //    var manufacturer = new Manufacturer() { Name = "Dummy" };
        //    stubEntities.Manufacturers = stubManufacturers; 
        //    stubManufacturers.Add(manufacturer);
            
        //    // Act
        //    var sut = new EquipmentRepository(stubEntities, stubLogger);
        //    sut.AddManufacturer(new Manufacturer { Name = "dummy" });

        //    // Assert
        //    Assert.AreEqual(1, stubManufacturers.Count(), "Manufacturers count incorrect");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(RepositoryException))]
        //public void AddManufacturerThrowsRepositoryException()
        //{ 
        //    // Arrange
        //    var stubManufacturers = new InMemoryDbSet<Manufacturer>();
        //    stubManufacturers.Add(new Manufacturer() { Name = "Dummy" });
        //    stubManufacturers.Add(new Manufacturer() { Name = "Dummy" });
        //    stubEntities.Manufacturers = stubManufacturers;

        //    // Act
        //    var sut = new EquipmentRepository(stubEntities, stubLogger);
        //    sut.AddManufacturer(new Manufacturer { Name = "Dummy" });

        //    // Assert
            
        //}

        //[TestMethod]
        //public void AddManufacturerLogsErrorOnException()
        //{ 
        //    // Arrange
        //    var stubManufacturers = new InMemoryDbSet<Manufacturer>();
        //    stubManufacturers.Add(new Manufacturer() { Name = "Dummy" });
        //    stubManufacturers.Add(new Manufacturer() { Name = "Dummy" });
        //    stubEntities.Manufacturers = stubManufacturers;

        //    // Act
        //    var sut = new EquipmentRepository(stubEntities, stubLogger);
        //    try
        //    {
        //        sut.AddManufacturer(new Manufacturer { Name = "Dummy" });
        //    }
        //    catch { /* Expected */ }

        //    // Assert
        //    stubLogger.AssertWasCalled(l => l.Error("", new Exception(), Category.Data), o => o.IgnoreArguments());
        //}

        

       


        //[TestMethod]
        //public void Can_Get_Sailing_Session_By_Manufacturer()
        //{
        //    using (var context = new WSStatContext())
        //    {
        //        try
        //        {
        //            // Arrange
        //            InsertSampleData();
        //            DateTime expectedSessionStart = DateTime.Parse("2012-04-01T17:35:00.0000000+13:00");
        //            DateTime expectedSessionEnd = DateTime.Parse("2012-04-01T19:35:00.0000000+13:00");

        //            // Act
        //            var repository = new EquipmentRepository(context);
        //            var sessions = repository.GetSessionsForSailor("twigg");

        //            // Assert
        //            Assert.IsTrue(sessions.Where(s => s.StartTime == expectedSessionStart && s.EndTime == expectedSessionEnd && s.Location.Name == "Ditch").Any());
        //        }
        //        finally
        //        {
        //            // Cleanup
        //            DeleteSampleData();
        //        }
        //    }
        //}

        //[TestMethod]
        //public void Can_Get_Sailing_Session_By_Sailor()
        //{
        //    // Arrange
        //    IWSStatContext context = GetMockContext();
        //    DateTime expectedSessionStart = DateTime.Parse("2012-04-01T17:35:00.0000000+13:00");
        //    DateTime expectedSessionEnd = DateTime.Parse("2012-04-01T19:35:00.0000000+13:00");

        //    // Act
        //    var repository = new EquipmentRepository(context);
        //    var sessions = repository.GetSessionsForSailor("twigg");

        //    // Assert
        //    Assert.IsTrue(sessions.Where(s => s.StartTime == expectedSessionStart && s.EndTime == expectedSessionEnd && s.Location.Name == "Ditch").Any());
        //}

        
    }
}
