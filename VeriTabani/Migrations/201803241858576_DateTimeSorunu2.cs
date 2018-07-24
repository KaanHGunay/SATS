namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeSorunu2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.olays", name: "datetime2", newName: "tarih");
            AlterColumn("dbo.olays", "tarih", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.olays", "tarih", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.olays", name: "tarih", newName: "datetime2");
        }
    }
}
