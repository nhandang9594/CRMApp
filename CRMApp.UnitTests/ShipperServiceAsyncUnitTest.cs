using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class ShipperServiceAsyncUnitTest
    {
        /*
         * Arrange: Initializes objects, creates mock with arguments that are passed to the method under test and adds expectations.
         * Act: Invokes the method or property under test with the arranged parameters
         * Assert: Verifies that the action of the method under test behaves as expected
         */
        private ShipperServiceAsync _sut;
        private static List<Shipper> _shippers;
        //Run in runtime, create class IShipperRepositoryAsync
        private Mock<IShipperRepositoryAsync> _mockShipperRepositoryAsync;

        [TestInitialize]
        //[OneTimeSetup] in
        //It's gonna call before each and every test method runs
        public void OneTimeSetup() //Use this method to set up fake data
        {
            _mockShipperRepositoryAsync = new Mock<IShipperRepositoryAsync>();

            //Dependency injection
            _sut = new ShipperServiceAsync(_mockShipperRepositoryAsync.Object);

            //Whoever someone call GetAllAsync(), return _shippers obj
            _mockShipperRepositoryAsync.Setup(m => m.GetAllAsync()).ReturnsAsync(_shippers);
        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _shippers = new List<Shipper>
            {
                new Shipper {Id = 1, Name = "Hulk", Phone = "2233222332" },
                new Shipper {Id = 2, Name = "Thor", Phone = "9489382935"},
                new Shipper {Id = 3, Name = "Iron Man", Phone = "2323445223"},
            };
        }


        [TestMethod]
        public async Task TestGetAllAsyncListOfShippersFromFakeData()
        {
            // SUT System under Test ProductServiceAsync => GetAllAsync()

            // Arranging:
            // mock objects, data, methods, .etc
            //Dependency injection
            //_sut = new ShipperServiceAsync(new MockShipperRepositoryAsync());


            // Act: calling the actual method we testing
            var shippers = await _sut.GetAllAsync();

            // check the actual output with expected data.
            // AAA:
            // Arrange, Act, Assert 

            // Assert: checking the expected value with actual value
            // do multiple condition checks (nullValue, dataTypes, .etc)
            //if one assert fail, the whole test fail (so do around 2-3 asserts)
            Assert.IsNotNull(shippers);
            Assert.IsInstanceOfType(shippers, typeof(IEnumerable<ShipperModel>)); 
            Assert.AreEqual(3, shippers.Count());
        }

        //public class MockShipperRepositoryAsync : IShipperRepositoryAsync
        //{
        //    public Task<int> DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Shipper>> GetAllAsync()
        //    {
        //        //This method will get fake data
        //        List<Shipper> _shippers = new List<Shipper>
        //        {
        //            new Shipper {Id = 1, Name = "Hulk", Phone = "2233222332" },
        //            new Shipper {Id = 2, Name = "Thor", Phone = "9489382935"},
        //            new Shipper {Id = 3, Name = "Iron Man", Phone = "2323445223"},
        //        };

        //        return _shippers;
        //    }

        //    public Task<Shipper> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> InsertAsync(Shipper entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> UpdateAsync(Shipper entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}