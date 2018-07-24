namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.magdurs", "TC", c => c.String(maxLength: 11));
            AlterColumn("dbo.suphelis", "TC", c => c.String(maxLength: 11));
            CreateIndex("dbo.magdurs", "TC", unique: true);
            CreateIndex("dbo.suphelis", "TC", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.suphelis", new[] { "TC" });
            DropIndex("dbo.magdurs", new[] { "TC" });
            AlterColumn("dbo.suphelis", "TC", c => c.String());
            AlterColumn("dbo.magdurs", "TC", c => c.String());
        }
    }
}
