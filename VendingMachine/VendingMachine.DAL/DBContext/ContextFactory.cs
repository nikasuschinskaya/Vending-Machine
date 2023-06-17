using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace VendingMachine.DAL.DBContext
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sqlServerDB"].ConnectionString;
            var optionsBulder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBulder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new ApplicationDbContext(optionsBulder.Options);
        }
    }
}
