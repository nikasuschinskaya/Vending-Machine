using Bogus;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories;

namespace VendingMachineTests.RepositoriesTests
{
    [TestFixture]
    public class DrinkRepositoryTests
    {
        private DrinkRepository _drinkRepository;
        private List<DrinkEntity> _stub;
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

            _stub = GenerateData(4);

            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_ShouldReturnDrinkEntity()
        {
            // Arrange
            var drink = _stub[0];

            // Act
            _drinkRepository.Create(drink);

            // Assert
            Assert.AreEqual(1, _dbContext.Drinks.Count());
            Assert.AreEqual(drink.Count, _dbContext.Drinks.First().Count);
            Assert.AreEqual(drink.Name, _dbContext.Drinks.First().Name);
            Assert.AreEqual(drink.Cost, _dbContext.Drinks.First().Cost);
            Assert.AreEqual(drink.DrinkState, _dbContext.Drinks.First().DrinkState);
        }

        [Test]
        public void Update_ShouldReturnNewCostAndCountAfterUpdated()
        {
            // Arrange
            var drink = _stub[2];

            // Act
            _drinkRepository.Create(drink);
            drink.Cost = 8;
            drink.Count = 5;
            _drinkRepository.Update(drink);

            // Assert
            Assert.AreEqual(8, _dbContext.Drinks.First().Cost);
            Assert.AreEqual(5, _dbContext.Drinks.First().Count);
        }

        [Test]
        public void GetById_ShouldReturnDrinkEntityById()
        {
            // Arrange
            var drink = _stub[3];

            // Act
            _drinkRepository.Create(drink);
            var result = _drinkRepository.GetById(drink.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(drink.Id, result.Id);
            Assert.AreEqual(drink.Count, result.Count);
            Assert.AreEqual(drink.Name, result.Name);
            Assert.AreEqual(drink.Cost, result.Cost);
            Assert.AreEqual(drink.DrinkState, result.DrinkState);
        }

        [Test]
        public void Delete_ShouldReturnEmptyListOfDrinkEntityAfterDeleted()
        {
            // Arrange
            var drink = _stub[1];

            // Act
            _drinkRepository.Create(drink);
            _drinkRepository.Delete(drink.Id);

            // Assert
            var allDrinksAfterDelete = _drinkRepository.GetAll().ToList();
            Assert.AreEqual(0, allDrinksAfterDelete.Count);
        }

        private List<DrinkEntity> GenerateData(int count)
        {
            var faker = new Faker<DrinkEntity>()
                        .RuleFor(c => c.Id, f => f.UniqueIndex)
                        .RuleFor(c => c.Count, f => f.Random.Int(1 - 60))
                        .RuleFor(c => c.Name, f => f.Random.Word())
                        .RuleFor(c => c.Cost, f => f.Random.Int(5 - 20))
                        .RuleFor(c => c.DrinkState, State.None);

            return faker.Generate(count);
        }
    }
}
