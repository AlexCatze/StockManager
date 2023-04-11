using AlexCatze.StockManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexCatze.StockManager.Server
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ThingType> Things => Set<ThingType>();
        public DatabaseContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}
