namespace WebApplicationEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductType_ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductType_ProductTypeID" });
            RenameColumn(table: "dbo.Products", name: "ProductType_ProductTypeID", newName: "ProductTypeId");
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductTypeId");
            AddForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes", "ProductTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "ProductTypeId", newName: "ProductType_ProductTypeID");
            CreateIndex("dbo.Products", "ProductType_ProductTypeID");
            AddForeignKey("dbo.Products", "ProductType_ProductTypeID", "dbo.ProductTypes", "ProductTypeID");
        }
    }
}
