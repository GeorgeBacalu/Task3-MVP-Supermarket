using Supermarket.Core.Entities;
using System.Data.Entity;

namespace Supermarket.Core.Context
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext() : base("name=SupermarketDBConnectionString") => Database.SetInitializer(new CreateDatabaseIfNotExists<SupermarketDbContext>());
    
        public DbSet<User> Users { get; set; }
    }
}