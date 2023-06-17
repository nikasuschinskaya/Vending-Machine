using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.DAL.Repositories
{
    public class AdminRepository : BaseRepository<AdminEntity>
    {
        public AdminRepository(ApplicationDbContext context) : base(context) { }

        public override void Create(AdminEntity entity)
        {
            _context.Admins.Add(entity);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var admin = _context.Admins.FirstOrDefault(entity => entity.Id.Equals(id));
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }

        public override IEnumerable<AdminEntity> GetAll() => _context.Admins.ToList();

        public override AdminEntity GetById(int id) => _context.Admins.FirstOrDefault(entity => entity.Id.Equals(id));

        public override void Update(AdminEntity entity)
        {
            _context.Admins.Update(entity);
            _context.SaveChanges();
        }
    }
}
