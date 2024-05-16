namespace Supermarket.Core.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.SupermarketDbContext>
    {
        public Configuration() => AutomaticMigrationsEnabled = true;

        protected override void Seed(Context.SupermarketDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}