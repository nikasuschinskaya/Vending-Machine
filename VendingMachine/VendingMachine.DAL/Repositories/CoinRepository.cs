using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.DAL.Repositories
{
    public class CoinRepository : BaseRepository<CoinEntity>
    {
        public CoinRepository(ApplicationDbContext context) : base(context) { }

        public override void Create(CoinEntity entity)
        {
            _context.Coins.Add(entity);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var coin = _context.Coins.FirstOrDefault(entity => entity.Id.Equals(id));
            _context.Coins.Remove(coin);
            _context.SaveChanges();
        }

        public override IEnumerable<CoinEntity> GetAll() => _context.Coins.ToList();

        public override CoinEntity GetById(int id) => _context.Coins.FirstOrDefault(entity => entity.Id.Equals(id));

        public override void Update(CoinEntity entity)
        {
            _context.Coins.Update(entity);
            _context.SaveChanges();
        }
    }
}
