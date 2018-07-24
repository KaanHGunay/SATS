namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supheliDurumHataDuzeltme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.suphelis", "supheliDurum_ID", "dbo.supheliDurums");
            DropIndex("dbo.suphelis", new[] { "supheliDurum_ID" });
            DropColumn("dbo.suphelis", "supheliDurum_ID");
            DropTable("dbo.supheliDurums");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.supheliDurums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.suphelis", "supheliDurum_ID", c => c.Int());
            CreateIndex("dbo.suphelis", "supheliDurum_ID");
            AddForeignKey("dbo.suphelis", "supheliDurum_ID", "dbo.supheliDurums", "ID");
        }
    }
}
