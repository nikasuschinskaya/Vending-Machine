using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BLL.Models;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.BLL.Managers
{
    public class AdminManager
    {
        private readonly IRepository<AdminEntity> _adminRepository;

        public AdminManager(IRepository<AdminEntity> adminRepository) => _adminRepository = adminRepository;

        public bool IsCorrectData(string login, string pass)
        {
            var admin = _adminRepository.GetAll().FirstOrDefault(admin => admin.Login.Equals(login) && admin.Password.Equals(pass));
            if (admin != null) return true;
            return false;
        }

        public Admin Autorization(string login, string pass)
        {
            var admin = _adminRepository.GetAll().FirstOrDefault(admin => admin.Login.Equals(login) && admin.Password.Equals(pass));
            return new Admin(admin.Id, admin.Login, admin.Password);
        }
    }
}
