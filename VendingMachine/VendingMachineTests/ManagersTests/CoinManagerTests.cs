using Microsoft.EntityFrameworkCore;
using VendingMachine.BLL.Managers;
using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachineTests.ManagersTests
{
    [TestFixture]
    public class CoinManagerTests
    {
        private CoinManager _coinManager;
        private IRepository<CoinEntity> _coinRepository;
        private ApplicationDbContext _dbContext;
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                               .UseInMemoryDatabase(databaseName: "TestDatabase")
                               .Options;
            _dbContext = new ApplicationDbContext(_dbContextOptions);
            _coinRepository = new CoinRepository(_dbContext);
            _coinManager = new CoinManager(_coinRepository);


            _dbContext.Database.EnsureDeleted();

            _coinRepository.Create(new CoinEntity { Denomination = 1, Count = 27, CoinState = State.None });
            _coinRepository.Create(new CoinEntity { Denomination = 2, Count = 37, CoinState = State.Block });
            _coinRepository.Create(new CoinEntity { Denomination = 4, Count = 0, CoinState = State.None });
            _coinRepository.Create(new CoinEntity { Denomination = 5, Count = 28, CoinState = State.None });
            _coinRepository.Create(new CoinEntity { Denomination = 10, Count = 25, CoinState = State.Unlock });
        }

        [Test]
        public void DepositCoin_ShouldChangedCountOfCoin()
        {
            // Arrange
            int id = 1;

            // Act
            _coinManager.DepositCoin(id);

            // Assert
            Assert.AreEqual(28, _dbContext.Coins.First().Count);
        }

        [Test]
        public void GetAvaliableCoins_ShouldReturnCountAvaliableCoins()
        {
            // Act & Assert
            Assert.AreEqual(3, _coinManager.GetAvaliableCoins().Count);
        }

        [Test]
        public void GetCoinDenomination_ShouldGetCoinDenominationById()
        {
            // Arrange
            int id = 1;

            // Act
            var coinDenomination = _coinManager.GetCoinDenomination(id);

            // Assert
            Assert.AreEqual(1, coinDenomination);
        }

        [Test]
        public void UpdateCoinCount_ShouldChangedCoinCount()
        {
            // Arrange
            int denomination = 1;
            int newCoinCount = 25;

            // Act
            _coinManager.UpdateCoinCount(denomination, newCoinCount);

            // Assert
            Assert.AreEqual(2, _dbContext.Coins.First().Count);
        }

        [Test]
        public void GetChange_ShouldGotCorrectChange()
        {
            // Arrange
            decimal changeInCash = 11;
            Dictionary<int, int> correctChange = new Dictionary<int, int>() { { 10, 1 }, { 1, 1 } };

            // Act
            var change = _coinManager.GetChange(changeInCash);

            //Assert
            Assert.AreEqual(correctChange, change);
        }
    }
}