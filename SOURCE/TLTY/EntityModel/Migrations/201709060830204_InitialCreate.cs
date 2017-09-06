namespace EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountGroup",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                        AccountGroupID = c.String(maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 250),
                        LastName = c.String(maxLength: 250),
                        Birthday = c.DateTime(nullable: false, storeType: "date"),
                        Email = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 15),
                        Avatar = c.String(maxLength: 250),
                        Address = c.String(maxLength: 500),
                        CreateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccountGroup", t => t.AccountGroupID)
                .Index(t => t.AccountGroupID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        Address = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        ViewCount = c.Int(),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                        Description = c.String(nullable: false, maxLength: 500),
                        Images = c.String(maxLength: 250),
                        MoreImages = c.String(storeType: "xml"),
                        Category = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        MoreImage = c.String(storeType: "xml"),
                        ContentID = c.Long(),
                        Detail = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Content", t => t.ContentID)
                .Index(t => t.ContentID);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        DisplayOrder = c.Int(nullable: false),
                        Link = c.String(maxLength: 250),
                        ContentID = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Content", t => t.ContentID)
                .Index(t => t.ContentID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 15),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupPath",
                c => new
                    {
                        AccountGroupID = c.String(nullable: false, maxLength: 50),
                        PathID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.AccountGroupID, t.PathID });
            
            CreateTable(
                "dbo.Instruction",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                        Images = c.String(maxLength: 250),
                        MoreImages = c.String(storeType: "xml"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Path",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ticker",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        Type = c.Boolean(),
                        Quantity = c.Long(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slider", "ContentID", "dbo.Content");
            DropForeignKey("dbo.Request", "ContentID", "dbo.Content");
            DropForeignKey("dbo.Account", "AccountGroupID", "dbo.AccountGroup");
            DropIndex("dbo.Slider", new[] { "ContentID" });
            DropIndex("dbo.Request", new[] { "ContentID" });
            DropIndex("dbo.Account", new[] { "AccountGroupID" });
            DropTable("dbo.Ticker");
            DropTable("dbo.Path");
            DropTable("dbo.Instruction");
            DropTable("dbo.GroupPath");
            DropTable("dbo.Feedback");
            DropTable("dbo.Slider");
            DropTable("dbo.Request");
            DropTable("dbo.Content");
            DropTable("dbo.Contact");
            DropTable("dbo.Account");
            DropTable("dbo.AccountGroup");
        }
    }
}
