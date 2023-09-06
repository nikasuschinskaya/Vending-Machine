using Bogus;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories;

namespace VendingMachineTests.RepositoriesTests
{
    [TestFixture]
    public class AdminRepositoryTests
    {
        private AdminRepository _adminRepository;
        private List<AdminEntity> _stub;
        private ApplicationDbContext _dbContext;
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(databaseName: "TestDatabase")
                                .Options;
            _dbContext = new ApplicationDbContext(_dbContextOptions);
            _adminRepository = new AdminRepository(_dbContext);

            _stub = GenerateData(4);
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_ShouldThrowArgumentNullException_IfDbContextIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _adminRepository.Create(null));
        }

        [Test]
        public void Create_ShouldReturnAdminEntity()
        {
            // Arrange
            var admin = _stub[0];

            // Act
            _adminRepository.Create(admin);

            // Assert
            Assert.AreEqual(1, _dbContext.Admins.Count());
            Assert.AreEqual(admin.Login, _dbContext.Admins.First().Login);
            Assert.AreEqual(admin.Password, _dbContext.Admins.First().Password);
        }

        [Test]
        public void Update_ShouldReturnNewLoginAfterUpdated()
        {
            // Arrange
            var admin = _stub[2];

            // Act
            _adminRepository.Create(admin);
            admin.Login = "Babababa";
            _adminRepository.Update(admin);

            // Assert
            Assert.AreEqual("Babababa", _dbContext.Admins.First().Login);
        }

        [Test]
        public void GetById_ShouldReturnAdminEntityById()
        {
            // Arrange
            var admin = _stub[3];

            // Act
            _adminRepository.Create(admin);
            var result = _adminRepository.GetById(admin.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(admin.Id, result.Id);
            Assert.AreEqual(admin.Login, result.Login);
            Assert.AreEqual(admin.Password, result.Password);
        }

        [Test]
        public void Delete_ShouldReturnEmptyListOfAdminEntityAfterDeleted()
        {
            // Arrange
            var admin = _stub[1];

            // Act
            _adminRepository.Create(admin);
            _adminRepository.Delete(admin.Id);

            // Assert
            var allAdminsAfterDelete = _adminRepository.GetAll().ToList();
            Assert.AreEqual(0, allAdminsAfterDelete.Count);
        }

        private List<AdminEntity> GenerateData(int count)
        {
            var faker = new Faker<AdminEntity>()
                        .RuleFor(c => c.Id, f => f.UniqueIndex)
                        .RuleFor(c => c.Login, f => f.Internet.UserName())
                        .RuleFor(c => c.Password, f => f.Internet.Password());

            return faker.Generate(count);
        }
    }
}