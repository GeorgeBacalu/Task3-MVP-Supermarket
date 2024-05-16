namespace Supermarket.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1_CoreDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        OriginCountry = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Reason = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartsAt = c.DateTime(nullable: false),
                        EndsAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BarCode = c.String(),
                        Category = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Manufacturer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Manufacturer_Id);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IssuedAt = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Issuer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Issuer_Id)
                .Index(t => t.Issuer_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Password = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SoldProducts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Product_Id = c.Guid(),
                        Receipt_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Receipts", t => t.Receipt_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Receipt_Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        MeasureUnit = c.Int(nullable: false),
                        SuppliedAt = c.DateTime(nullable: false),
                        ExpiresAt = c.DateTime(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockReceipts",
                c => new
                    {
                        Stock_Id = c.Guid(nullable: false),
                        Receipt_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stock_Id, t.Receipt_Id })
                .ForeignKey("dbo.Stocks", t => t.Stock_Id, cascadeDelete: true)
                .ForeignKey("dbo.Receipts", t => t.Receipt_Id, cascadeDelete: true)
                .Index(t => t.Stock_Id)
                .Index(t => t.Receipt_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockReceipts", "Receipt_Id", "dbo.Receipts");
            DropForeignKey("dbo.StockReceipts", "Stock_Id", "dbo.Stocks");
            DropForeignKey("dbo.SoldProducts", "Receipt_Id", "dbo.Receipts");
            DropForeignKey("dbo.SoldProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Receipts", "Issuer_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Offers", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.StockReceipts", new[] { "Receipt_Id" });
            DropIndex("dbo.StockReceipts", new[] { "Stock_Id" });
            DropIndex("dbo.SoldProducts", new[] { "Receipt_Id" });
            DropIndex("dbo.SoldProducts", new[] { "Product_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Receipts", new[] { "Issuer_Id" });
            DropIndex("dbo.Products", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Offers", new[] { "Product_Id" });
            DropTable("dbo.StockReceipts");
            DropTable("dbo.Stocks");
            DropTable("dbo.SoldProducts");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Receipts");
            DropTable("dbo.Products");
            DropTable("dbo.Offers");
            DropTable("dbo.Manufacturers");
        }
    }
}
