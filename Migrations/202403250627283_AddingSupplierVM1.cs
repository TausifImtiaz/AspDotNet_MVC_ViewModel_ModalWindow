namespace MVC_ViewModel_ModalWindow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSupplierVM1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierVMs",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SupplierVMs");
        }
    }
}
