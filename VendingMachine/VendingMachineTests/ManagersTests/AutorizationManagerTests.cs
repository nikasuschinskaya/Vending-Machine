using Microsoft.EntityFrameworkCore;
using VendingMachine.BLL.Managers;
using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachineTests.ManagersTests
{
    [TestFixture]
    public class AutorizationManagerTests
    {
        private AutorizationManager _autorizationManager;
        private IRepository<AdminEntity> _adminRepository;
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
            _autorizationManager = new AutorizationManager(_adminRepository);

            _adminRepository.Create(new AdminEntity { Login = "nika", Password = "12345678" });
        }

        [Test]
        public void IsCorrectData_ShouldReturnTrue()
        {
            // Arrange
            string login = "nika";
            string pass = "12345678";

            // Act
            bool result = _autorizationManager.IsCorrectData(login, pass);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCorrectData_ShouldReturnFalse()
        {
            // Arrange
            string login = "nika";
            string pass = "3218";

            // Act
            bool result = _autorizationManager.IsCorrectData(login, pass);

            // Assert
            Assert.IsFalse(result);
        }
    }
}