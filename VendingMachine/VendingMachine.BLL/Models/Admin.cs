using System.ComponentModel;

namespace VendingMachine.BLL.Models
{
    public class Admin
    {
        public int AdminId { get; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Admin(int adminId, string login, string password)
        {
            AdminId = adminId;
            Login = login;
            Password = password;
        }
    }
}
