using StockData.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockData.Infrastructure.DbContexts
{
    public class StockDbContext : DbContext, IStockDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public StockDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Company> Companies { get; set; }
    }
}