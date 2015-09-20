namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Detail = c.String(maxLength: 500),
                        Logo = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "IX_FirstAndSecond");
            
            CreateTable(
                "dbo.CategoryMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Detail = c.String(maxLength: 500),
                        Logo = c.String(maxLength: 500),
                        PerentCategoryID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "IX_FirstAndSecond");
            
            CreateTable(
                "dbo.LocationMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        LocationName = c.String(nullable: false, maxLength: 50),
                        LocationCode = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.LocationCode, unique: true, name: "IX_FirstAndSecond");
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CategoryID = c.Long(),
                        SubCategoryID = c.Long(),
                        SubSubCategoryID = c.Long(),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        StandardCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCode = c.String(nullable: false, maxLength: 50),
                        ShortDescription = c.String(nullable: false, maxLength: 500),
                        FullDescription = c.String(nullable: false),
                        LocationCode = c.String(),
                        BrandID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BrandMaster", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.ProductCode, unique: true, name: "IX_FirstAndSecond")
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.ProductsImages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ImageURL = c.String(),
                        smallImageURL = c.String(),
                        IsMainImage = c.Boolean(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductsVideos",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ImageURL = c.String(),
                        smallImageURL = c.String(),
                        VideoURL = c.String(),
                        IsMainImage = c.Boolean(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BrandID", "dbo.BrandMaster");
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", "IX_FirstAndSecond");
            DropIndex("dbo.LocationMaster", "IX_FirstAndSecond");
            DropIndex("dbo.CategoryMaster", "IX_FirstAndSecond");
            DropIndex("dbo.BrandMaster", "IX_FirstAndSecond");
            DropTable("dbo.UserMaster");
            DropTable("dbo.ProductsVideos");
            DropTable("dbo.ProductsImages");
            DropTable("dbo.Products");
            DropTable("dbo.LocationMaster");
            DropTable("dbo.CategoryMaster");
            DropTable("dbo.BrandMaster");
        }
    }
}
