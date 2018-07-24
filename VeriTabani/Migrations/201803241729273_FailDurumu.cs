namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FailDurumu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.failDurums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        failDurumu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.olays", "failDurum_ID", c => c.Int());
            CreateIndex("dbo.olays", "failDurum_ID");
            AddForeignKey("dbo.olays", "failDurum_ID", "dbo.failDurums", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.olays", "failDurum_ID", "dbo.failDurums");
            DropIndex("dbo.olays", new[] { "failDurum_ID" });
            DropColumn("dbo.olays", "failDurum_ID");
            DropTable("dbo.failDurums");
        }
    }
}
