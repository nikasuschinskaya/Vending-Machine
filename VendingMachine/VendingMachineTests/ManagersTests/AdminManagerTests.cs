using Microsoft.EntityFrameworkCore;
using VendingMachine.BLL.Managers;
using VendingMachine.BLL.Models;
using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachineTests.ManagersTests
{
    [TestFixture]
    public class AdminManagerTests
    {
        private AdminManager _adminManager;
        private IRepository<CoinEntity> _coinRepository;
        private IRepository<DrinkEntity> _drinkRepository;
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
            _drinkRepository = new DrinkRepository(_dbContext);
            _adminManager = new AdminManager(_drinkRepository, _coinRepository);

            _dbContext.Database.EnsureDeleted();

            _coinRepository.Create(new CoinEntity { Denomination = 1, Count = 27, CoinState = State.None });
            _coinRepository.Create(new CoinEntity { Denomination = 2, Count = 37, CoinState = State.Block });
            _coinRepository.Create(new CoinEntity { Denomination = 4, Count = 0, CoinState = State.None });
            _coinRepository.Create(new CoinEntity { Denomination = 5, Count = 28, CoinState = State.None });
            _coinRepository.Create(new CoinEntity { Denomination = 10, Count = 25, CoinState = State.Unlock });

            _drinkRepository.Create(new DrinkEntity { Name = "pepsi", Count = 0, Cost = 9, DrinkState = State.None });
            _drinkRepository.Create(new DrinkEntity { Name = "water", Count = 5, Cost = 5, DrinkState = State.None });
            _drinkRepository.Create(new DrinkEntity { Name = "cola", Count = 5, Cost = 12, DrinkState = State.Unlock });
            _drinkRepository.Create(new DrinkEntity { Name = "sprite", Count = 5, Cost = 7, DrinkState = State.Block });
        }

        [Test]
        public void AddDrink_ShouldReturnDrink()
        {
            // Arrange
            var drink = new Drink(0, "fanta", 5, 8);

            // Act
            _adminManager.AddDrink(drink);

            // Assert
            Assert.AreEqual(drink.Name, _dbContext.Drinks.FirstOrDefault(x => x.Id == 5).Name);
            Assert.AreEqual(drink.Count, _dbContext.Drinks.FirstOrDefault(x => x.Id == 5).Count);
            Assert.AreEqual(drink.Cost, _dbContext.Drinks.FirstOrDefault(x => x.Id == 5).Cost);
            Assert.AreEqual(drink.DrinkState, State.None);
        }

        [Test]
        public void DeleteDrink_ShouldReturnCountListOfDrinksAfterDeleted()
        {
            // Arrange
            int id = 4;

            // Act
            _adminManager.DeleteDrink(id);

            // Assert
            var allDrinksAfterDelete = _drinkRepository.GetAll().ToList();
            Assert.AreEqual(3, allDrinksAfterDelete.Count);
        }

        [Test]
        public void UpdateDrinkCount_ShouldChangedDrinkCount()
        {
            // Arrange
            int id = 1;
            int newDrinkCount = 7;

            // Act
            _adminManager.UpdateDrinkCount(id, newDrinkCount);

            //Assert
            Assert.AreEqual(7, _dbContext.Drinks.First().Count);
        }

        [Test]
        public void UpdateDrinkCost_ShouldChangedDrinkCost()
        {
            // Arrange
            int id = 1;
            int newDrinkCost = 10;

            // Act
            _adminManager.UpdateDrinkCost(id, newDrinkCost);

            //Assert
            Assert.AreEqual(10, _dbContext.Drinks.First().Cost);
        }

        [Test]
        public void BlockDrink_ShouldChangedDrinkStateAfterBlock()
        {
            // Arrange
            int id = 1;

            // Act
            _adminManager.BlockDrink(id);

            //Assert
            Assert.AreEqual(State.Block, _dbContext.Drinks.First().DrinkState);
        }

        [Test]
        public void UnlockDrink_ShouldChangedDrinkStateAfterUnlock()
        {
            // Arrange
            int id = 4;

            // Act
            _adminManager.UnlockDrink(id);

            //Assert
            Assert.AreEqual(State.Unlock, _dbContext.Drinks.FirstOrDefault(x => x.Id == id).DrinkState);
        }

        [Test]
        public void UpdateCoinCount_ShouldChangedCoinCount()
        {
            // Arrange
            int id = 1;
            int newCoinCount = 40;

            // Act
            _adminManager.UpdateCoinCount(id, newCoinCount);

            //Assert
            Assert.AreEqual(40, _dbContext.Coins.First().Count);
        }


        [Test]
        public void BlockCoin_ShouldChangedCoinStateAfterBlock()
        {
            // Arrange
            int id = 1;

            // Act
            _adminManager.BlockCoin(id);

            //Assert
            Assert.AreEqual(State.Block, _dbContext.Coins.First().CoinState);
        }

        [Test]
        public void UnlockCoin_ShouldChangedCoinStateAfterUnlock()
        {
            // Arrange
            int id = 2;

            // Act
            _adminManager.UnlockCoin(id);

            //Assert
            Assert.AreEqual(State.Unlock, _dbContext.Coins.FirstOrDefault(x => x.Id == id).CoinState);
        }

        [Test]
        public void GetAllDrinks_ShouldReturnCountListOfDrinks()
        {
            // Act & Assert
            Assert.AreEqual(4, _adminManager.GetAllDrinks().Count);
        }

        [Test]
        public void GetAllCoins_ShouldReturnCountListOfCoins()
        {
            // Act & Assert
            Assert.AreEqual(5, _adminManager.GetAllCoins().Count);
        }
    }
}