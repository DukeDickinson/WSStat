using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSStat.Repository;
using WSStat.Model;
using WSStat.Common.Logging;
using Rhino.Mocks;

namespace WSStat.Repository.Test.Integration
{
    [TestClass]
    public class EquiptmentRepositoryIntegrationTest
    {
        private WSStatContext _context;
        private ILogger _stubLogger;

        [TestInitialize]
        public void Initialise()
        {
            _context = new WSStatContext();
            _stubLogger = MockRepository.GenerateStub<ILogger>();
            InsertTestDataToDatabase();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DeleteTestDataFromDatabase();
            _context.Dispose();
        }

        [TestMethod]
        public void AddManufacturer()
        {
            // Arrange
            int expected = _context.Manufacturers.Count() + 1;
            var manufacturer = new Manufacturer() { Name = "Dummy" };
            var sut = new EquipmentRepository(_context, _stubLogger);

            // Act
            sut.AddManufacturer(manufacturer);
            _context.Save();
            int actual = _context.Manufacturers.Count();

            // Assert
            Assert.AreEqual(expected, actual, "Manufacturers count incorrect");
        }

        [TestMethod]
        public void AddBoard()
        { 
            // Arrange
            int expected = _context.Boards.Count() + 1;
            var board = new Board() { Model = new BoardModel() { Manufacturer = _context.Manufacturers.Single(m => m.Name == "JP"), Name = "Dummy" }, Volume = 74 };
            var sut = new EquipmentRepository(_context, _stubLogger);

            // Act
            sut.AddBoard(board);
            _context.Save();

            // Assert
            Assert.AreEqual(expected, _context.Boards.Count(), "Boards count incorrect");
        }

        [TestMethod]
        public void AddSail()
        {
            // Arrange
            int expected = _context.Sails.Count() + 1;
            var sail = new Sail() { Size = 4.7, Model = new SailModel() { Name = "Dummy", Manufacturer = _context.Manufacturers.Single(m => m.Name == "Tushingham") } };
            var sut = new EquipmentRepository(_context, _stubLogger);

            // Act
            sut.AddSail(sail);
            _context.Save();

            // Assert
            Assert.AreEqual(expected, _context.Sails.Count(), "Sails count incorrect");
        }



        private void InsertTestDataToDatabase()
        {
            using (var context = new WSStatContext())
            {
                Manufacturer tushing = context.Manufacturers.Add(new Manufacturer { Name = "Tushingham" });
                Manufacturer severne = context.Manufacturers.Add(new Manufacturer { Name = "Severne" });
                Manufacturer jp = context.Manufacturers.Add(new Manufacturer { Name = "JP" });

                SailModel rock = context.SailModels.Add(new SailModel { Name = "Rock", Manufacturer = tushing });
                SailModel blade = context.SailModels.Add(new SailModel { Name = "Blade", Manufacturer = severne });

                BoardModel rww = context.BoardModels.Add(new BoardModel { Name = "Real World Wave", Manufacturer = jp });
                BoardModel fsw = context.BoardModels.Add(new BoardModel { Name = "Freestyle Wave", Manufacturer = jp });

                Sail rock40 = context.Sails.Add(new Sail { Model = rock, Size = 4.0 });
                Sail rock47 = context.Sails.Add(new Sail { Model = rock, Size = 4.7 });
                Sail rock52 = context.Sails.Add(new Sail { Model = rock, Size = 5.2 });

                Board rww76 = context.Boards.Add(new Board { Model = rww, Volume = 76 });
                Board rww83 = context.Boards.Add(new Board { Model = rww, Volume = 83 });
                Board fsw102 = context.Boards.Add(new Board { Model = fsw, Volume = 102 });

                Location ditch = context.Locations.Add(new Location { Name = "Ditch" });
                Location plimi = context.Locations.Add(new Location { Name = "Plimi" });

                Sailor twigg = context.Sailors.Add(new Sailor { FirstName = "Andrew", LastName = "Twigg" });
                Sailor sweeting = context.Sailors.Add(new Sailor { FirstName = "David", LastName = "Sweeting" });

                DateTime sessionStart = DateTime.Parse("2012-04-01T17:35:00.0000000+13:00");
                DateTime sessionEnd = DateTime.Parse("2012-04-01T19:35:00.0000000+13:00");

                SailingSession session1 = context.Sessions.Add(new SailingSession { Sailor = twigg, StartTime = sessionStart, EndTime = sessionEnd, Location = ditch, });
                SailingSession session2 = context.Sessions.Add(new SailingSession { Sailor = twigg, StartTime = sessionStart, EndTime = sessionEnd, Location = plimi });
                SailingSession session3 = context.Sessions.Add(new SailingSession { Sailor = twigg, StartTime = sessionStart, EndTime = sessionEnd, Location = ditch });

                session1.Sails.Add(rock40);
                session1.Boards.Add(fsw102);
                session2.Sails.Add(rock40);
                session2.Boards.Add(rww76);
                session3.Sails.Add(rock52);
                session3.Boards.Add(fsw102);

                context.Save();
            }
        }

        private void DeleteTestDataFromDatabase()
        {
            using (var context = new WSStatContext())
            {
                context.Database.ExecuteSqlCommand("delete from SessionBoards");
                context.Database.ExecuteSqlCommand("delete from SessionSails");
                context.Database.ExecuteSqlCommand("delete from SailingSession");
                context.Database.ExecuteSqlCommand("delete from Sailor");
                context.Database.ExecuteSqlCommand("delete from Location");
                context.Database.ExecuteSqlCommand("delete from Board");
                context.Database.ExecuteSqlCommand("delete from Sail");
                context.Database.ExecuteSqlCommand("delete from SailModel");
                context.Database.ExecuteSqlCommand("delete from BoardModel");
                context.Database.ExecuteSqlCommand("delete from Manufacturer");
            }
        }
    }
}
