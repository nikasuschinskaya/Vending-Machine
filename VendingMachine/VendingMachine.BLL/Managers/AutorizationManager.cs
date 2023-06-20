using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.BLL.Managers
{
    public class AutorizationManager
    {
        private readonly IRepository<AdminEntity> _adminRepository;

        public AutorizationManager(IRepository<AdminEntity> adminRepository) => _adminRepository = adminRepository;

        /// <summary>
        /// Проверяет правильно ли введены данные
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="pass">Пароль</param>
        /// <returns>Да или нет</returns>
        public bool IsCorrectData(string login, string pass)
        {
            var admin = _adminRepository.GetAll().FirstOrDefault(admin => admin.Login.Equals(login) && admin.Password.Equals(pass));
            if (admin != null) return true;
            return false;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="pass">Пароль</param>
        /// <returns>Админ</returns>
        public Admin Autorization(string login, string pass)
        {
            var admin = _adminRepository.GetAll().FirstOrDefault(admin => admin.Login.Equals(login) && admin.Password.Equals(pass));
            return new Admin(admin.Id, admin.Login, admin.Password);
        }
    }
}
