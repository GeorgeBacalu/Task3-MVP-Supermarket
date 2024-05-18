using Supermarket.Core.Entities;
using System.Data.Entity;

namespace Supermarket.Core.Context
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext() : base("name=SupermarketDBConnectionString") => Database.SetInitializer(new CreateDatabaseIfNotExists<SupermarketDbContext>());

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
    }
}