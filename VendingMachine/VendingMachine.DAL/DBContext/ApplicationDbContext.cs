using Microsoft.EntityFrameworkCore;
using VendingMachine.DAL.Entities;

namespace VendingMachine.DAL.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CoinEntity> Coins { get; set; }
        public DbSet<DrinkEntity> Drinks { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();
    }
}
