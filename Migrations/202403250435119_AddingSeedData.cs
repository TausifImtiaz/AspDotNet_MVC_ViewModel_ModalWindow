namespace MVC_ViewModel_ModalWindow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSeedData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Supplliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Supplliers");
            DropTable("dbo.Customers");
        }
    }
}
