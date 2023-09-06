using Bogus;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Repositories;

namespace VendingMachineTests.RepositoriesTests
{
    [TestFixture]
    public class CoinRepositoryTests
    {
        private CoinRepository _coinRepository;
        private List<CoinEntity> _stub;
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

            _stub = GenerateData(4);

            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_ShouldReturnCoinEntity()
        {
            // Arrange
            var coin = _stub[0];

            // Act
            _coinRepository.Create(coin);

            // Assert
            Assert.AreEqual(1, _dbContext.Coins.Count());
            Assert.AreEqual(coin.Count, _dbContext.Coins.First().Count);
            Assert.AreEqual(coin.Denomination, _dbContext.Coins.First().Denomination);
            Assert.AreEqual(coin.CoinState, _dbContext.Coins.First().CoinState);
        }

        [Test]
        public void Update_ShouldReturnNewCountAfterUpdated()
        {
            // Arrange
            var coin = _stub[2];

            // Act
            _coinRepository.Create(coin);
            coin.Count = 27;
            _coinRepository.Update(coin);

            // Assert
            Assert.AreEqual(27, _dbContext.Coins.First().Count);
        }

        [Test]
        public void GetById_ShouldReturnCoinEntityById()
        {
            // Arrange
            var coin = _stub[3];

            // Act
            _coinRepository.Create(coin);
            var result = _coinRepository.GetById(coin.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(coin.Id, result.Id);
            Assert.AreEqual(coin.Count, result.Count);
            Assert.AreEqual(coin.Denomination, result.Denomination);
            Assert.AreEqual(coin.CoinState, result.CoinState);
        }

        [Test]
        public void Delete_ShouldReturnEmptyListOfCoinEntityAfterDeleted()
        {
            // Arrange
            var coin = _stub[1];

            // Act
            _coinRepository.Create(coin);
            _coinRepository.Delete(coin.Id);

            // Assert
            var allCoinsAfterDelete = _coinRepository.GetAll().ToList();
            Assert.AreEqual(0, allCoinsAfterDelete.Count);
        }


        private List<CoinEntity> GenerateData(int count)
        {
            var faker = new Faker<CoinEntity>()
                        .RuleFor(c => c.Id, f => f.UniqueIndex)
                        .RuleFor(c => c.Count, f => f.Random.Int())
                        .RuleFor(c => c.Denomination, f => f.PickRandom(1, 2, 5, 10))
                        .RuleFor(c => c.CoinState, State.None);

            return faker.Generate(count);
        }

    }
}
