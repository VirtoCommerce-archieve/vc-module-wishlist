namespace VirtoCommerce.WishlistModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wishlist",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 1024),
                        Type = c.String(maxLength: 1024),
                        MemberId = c.String(maxLength: 64),
                        StoreId = c.String(maxLength: 64),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 64),
                        ModifiedBy = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WishlistItem",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductId = c.String(nullable: false, maxLength: 64),
                        ProductSku = c.String(maxLength: 64),
                        ProductName = c.String(maxLength: 256),
                        ProductType = c.String(maxLength: 64),
                        ImageUrl = c.String(maxLength: 1028),
                        Quantity = c.Int(nullable: false),
                        ListId = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 64),
                        ModifiedBy = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wishlist", t => t.ListId, cascadeDelete: true)
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.WishlistLink",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 1024),
                        Type = c.String(maxLength: 1024),
                        OwnerName = c.String(maxLength: 256),
                        OwnerId = c.String(maxLength: 64),
                        MemberId = c.String(maxLength: 64),
                        Permission = c.String(maxLength: 64),
                        ListId = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 64),
                        ModifiedBy = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wishlist", t => t.ListId, cascadeDelete: true)
                .Index(t => t.ListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishlistLink", "ListId", "dbo.Wishlist");
            DropForeignKey("dbo.WishlistItem", "ListId", "dbo.Wishlist");
            DropIndex("dbo.WishlistLink", new[] { "ListId" });
            DropIndex("dbo.WishlistItem", new[] { "ListId" });
            DropTable("dbo.WishlistLink");
            DropTable("dbo.WishlistItem");
            DropTable("dbo.Wishlist");
        }
    }
}
