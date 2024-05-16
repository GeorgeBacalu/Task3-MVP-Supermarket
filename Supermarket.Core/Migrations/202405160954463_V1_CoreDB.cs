namespace Supermarket.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V1_CoreDB : DbMigration
    {
        public override void Up() => CreateTable("dbo.Users", c => new { Id = c.Int(nullable: false, identity: true), Name = c.String() }).PrimaryKey(t => t.Id);
        
        public override void Down() => DropTable("dbo.Users");
    }
}