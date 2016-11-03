namespace WebApplicationEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductType_ProductTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_ProductTypeID)
                .Index(t => t.ProductType_ProductTypeID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductType_ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductType_ProductTypeID" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
        }
    }
}
