using VendingMachine.DAL.Entities.Base;

namespace VendingMachine.DAL.Entities
{
    public class AdminEntity : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public AdminEntity(int id, string login, string password) : base(id)
        {
            Login = login;
            Password = password;
        }
    }
}
