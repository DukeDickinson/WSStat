using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSStat.Repository;
using WSStat.Common.Logging;
using Rhino.Mocks;
using WSStat.Test.Helpers;
using System.Data.Entity;
using System.Linq.Expressions;

namespace WSStat.Repository.Test.Unit
{
    [TestClass]
    public class RepositoryBaseTest
    {
        private ILogger stubLogger;
        private IDbSet<string> stubEntities;

        /// <summary>
        /// Used for testing behavior of abstract repository base class.
        /// </summary>
        private class RepositoryBaseHost : RepositoryBase
        {
            // Local entities store
            private IDbSet<string> _entities;

            public RepositoryBaseHost(IDbSet<string> entities, ILogger log)
                : base (log)
            {
                _entities = entities;
            }

            public string AddItem(string item)
            {
                return Add(_entities, item, i => String.Compare(i, item, true) == 0);
            }

            public string GetItem(string item)
            {
                return Get(_entities, i => String.Compare(i, item, true) == 0);
            }

            public IQueryable<string> GetItems(string beginsWith)
            {
                return GetList(_entities, i => String.Compare(i, 0, beginsWith, 0, beginsWith.Length) == 0);
            }

            public IQueryable<string> GetItemsPredicate(Expression<Func<string, bool>> predicate)
            {
                return GetList(_entities, predicate);
            }
        }


        [TestInitialize]
        public void Initialise()
        {
            stubLogger = MockRepository.GenerateStub<ILogger>();
            stubEntities = new InMemoryDbSet<string>();
        }

        [TestCleanup]
        public void Cleanup()
        { }

        [TestMethod]
        public void AddItem()
        {
            // Arrange
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            sut.AddItem("Something");

            // Assert
            Assert.AreEqual(1, stubEntities.Count(), "Entities count incorrect");
        }

        [TestMethod]
        public void AddExistingItemDoesntAdd()
        {
            // Arrange
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);
            sut.AddItem("Something");

            // Act
            sut.AddItem("something");

            // Assert
            Assert.AreEqual(1, stubEntities.Count(), "Entities count incorrect");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void AddThrowsRepositoryException()
        {
            // Arrange
            stubEntities.Add("Something");
            stubEntities.Add("Something");
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            sut.AddItem("Something");

            // Assert
            // Expected Exception Attribute
        }

        [TestMethod]
        public void AddLogsErrorOnException()
        {
            // Arrange
            stubEntities.Add("Something");
            stubEntities.Add("Something");
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            try
            {
                sut.AddItem("Something");
            }
            catch { /* Expected */ }

            // Assert
            stubLogger.AssertWasCalled(l => l.Error("Doesn't matter - ignored", new Exception(), Category.Data), o => o.IgnoreArguments());
        }

        [TestMethod]
        public void GetItem()
        { 
            // Arrange
            var expected = "AValue";
            stubEntities.Add(expected);
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            string actual = sut.GetItem(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void GetItemThrowsRepositoryExceptionOnMultipleItems()
        { 
            // Arrange
            var testVal = "AValue";
            stubEntities.Add(testVal);
            stubEntities.Add(testVal);
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            sut.GetItem(testVal);

            // Assert
            // Expected Exception Attribute
        }

        [TestMethod]
        public void GetItemLogsErrorOnException()
        { 
            // Arrange
            var testVal = "AValue";
            stubEntities.Add(testVal);
            stubEntities.Add(testVal);
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            try
            {
                sut.GetItem(testVal);
            }
            catch { /* Expected */ }

            // Assert
            stubLogger.AssertWasCalled(l => l.Error("Doesn't matter - ignored", new Exception(), Category.Data), o => o.IgnoreArguments());
        }

        [TestMethod]
        public void GetItemCollection()
        { 
            // Arrange
            var expected = new string[] {"AValue", "AnotherValue"};
            stubEntities.Add(expected[0]);
            stubEntities.Add(expected[1]);
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            IEnumerable<string> actual = sut.GetItems("A");

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual)); 
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void GetItemsThrowRespositoryException()
        { 
            // Arrange
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            sut.GetItemsPredicate(null);

            // Assert
        }

        [TestMethod]
        public void GetItemsLogsErrorOnException()
        { 
            // Arrange
            var sut = new RepositoryBaseHost(stubEntities, stubLogger);

            // Act
            try
            {
                sut.GetItemsPredicate(null);
            }
            catch { /* Expected */ }
            
            // Assert
            stubLogger.AssertWasCalled(l => l.Error("", new Exception(), Category.Data), o => o.IgnoreArguments());
        }

        //[TestMethod]
        //public void CanGet()
        //{ 
        //    // Arrange
        //    var testVal = "AValue";
        //    var dbset = new InMemoryDbSet<string>();
        //    dbset.Add(testVal);

        //    // Act
        //    string actual = sut.Get(dbset, s => s == testVal);

        //    // Assert
        //    Assert.IsTrue(!String.IsNullOrEmpty(actual), "String is null or empty");
        //    Assert.AreEqual(testVal, actual, "String is not same as expected");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(RepositoryException))]
        //public void GetThrowsRepositoryException()
        //{ 
        //    // Arrange
        //    var testVal = "AValue";
        //    var dbset = new InMemoryDbSet<string>();
        //    dbset.Add(testVal);
        //    dbset.Add(testVal);

        //    // Act
        //    string actual = sut.Get(dbset, s => s == testVal);

        //    // Assert
        //}

        //[TestMethod]
        //public void GetLogsOnError()
        //{ 
        //    // Arrange
        //    var testVal = "AValue";
        //    var dbset = new InMemoryDbSet<string>();
        //    dbset.Add(testVal);
        //    dbset.Add(testVal);

        //    // Act
        //    try
        //    {
        //        string actual = sut.Get(dbset, s => s == testVal);
        //    }
        //    catch
        //    {
        //        // Expected
        //    }

        //    // Assert
        //    stubLogger.AssertWasCalled(x => x.Error("Exception in data access.", new Exception(), Category.Data), o => o.IgnoreArguments());
        //}
    }
}
