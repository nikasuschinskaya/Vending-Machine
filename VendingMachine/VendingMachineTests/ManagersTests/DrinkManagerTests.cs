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
    public class DrinkManagerTests
    {
        private DrinkManager _drinkManager;
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
            _drinkRepository = new DrinkRepository(_dbContext);
            _drinkManager = new DrinkManager(_drinkRepository);


            _dbContext.Database.EnsureDeleted();

            _drinkRepository.Create(new DrinkEntity { Name = "pepsi", Count = 0, Cost = 9, DrinkState = State.None });
            _drinkRepository.Create(new DrinkEntity { Name = "water", Count = 5, Cost = 5, DrinkState = State.None });
            _drinkRepository.Create(new DrinkEntity { Name = "cola", Count = 5, Cost = 12, DrinkState = State.Unlock });
            _drinkRepository.Create(new DrinkEntity { Name = "sprite", Count = 5, Cost = 7, DrinkState = State.Block });
        }

        [Test]
        public void GetAvaliableDrinks_ShouldReturnCountAvaliableDrinks()
        {
            // Act & Assert
            Assert.AreEqual(2, _drinkManager.GetAvaliableDrinks().Count);
        }

        [Test]
        public void GetDrinkById_ShouldReturnDrinkById()
        {
            // Arrange
            int id = 1;

            // Act
            var drink = _drinkManager.GetDrinkById(id);

            // Assert
            Assert.IsNotNull(drink);
            Assert.AreEqual("pepsi", drink.Name);
            Assert.AreEqual(0, drink.Count);
            Assert.AreEqual(9, drink.Cost);
            Assert.AreEqual(State.None, drink.DrinkState);
        }

        [Test]
        public void BuyDrink_ShouldChangedCountOfDrink()
        {
            // Arrange
            int id = 2;

            // Act
            var drink = _drinkManager.BuyDrink(id);

            // Assert
            Assert.IsNotNull(drink);
            Assert.AreEqual(4, drink.Count);
        }

        [Test]
        public void GetDrinkCost_ShouldReturnDrinkCostById()
        {
            // Arrange
            int id = 3;

            // Act
            var drinkCost = _drinkManager.GetDrinkCost(id);

            //Assert
            Assert.AreEqual(12, drinkCost);
        }
    }
}