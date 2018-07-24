namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeSorunu : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.olays", name: "tarih", newName: "datetime2");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.olays", name: "datetime2", newName: "tarih");
        }
    }
}
