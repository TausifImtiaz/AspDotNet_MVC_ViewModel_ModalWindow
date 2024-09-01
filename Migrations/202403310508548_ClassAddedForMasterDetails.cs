namespace MVC_ViewModel_ModalWindow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassAddedForMasterDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Customers", "Gender", c => c.String());
            AddColumn("dbo.Customers", "Image", c => c.String());
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropColumn("dbo.Customers", "Image");
            DropColumn("dbo.Customers", "Gender");
            DropColumn("dbo.Customers", "CustomerName");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
    }
}
