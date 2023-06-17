using VendingMachine.DAL.DBContext;

namespace VendingMachine.DAL.Repositories.Base
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context) => _context = context;

        public abstract bool Create(T entity);
        public abstract bool Delete(int id);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(int id);
        public abstract bool Update(T entity);
    }
}
