using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories.Base;

namespace VendingMachine.DAL.Repositories
{
    public class DrinkRepository : BaseRepository<DrinkEntity>
    {
        public DrinkRepository(ApplicationDbContext context) : base(context) { }

        public override void Create(DrinkEntity entity)
        {
            _context.Drinks.Add(entity);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var drink = _context.Drinks.FirstOrDefault(entity => entity.Id.Equals(id));
            _context.Drinks.Remove(drink);
            _context.SaveChanges();
        }

        public override IEnumerable<DrinkEntity> GetAll() => _context.Drinks.ToList();

        public override DrinkEntity GetById(int id) => _context.Drinks.FirstOrDefault(entity => entity.Id.Equals(id));

        public override void Update(DrinkEntity entity)
        {
            _context.Drinks.Update(entity);
            _context.SaveChanges();
        }
    }
}
