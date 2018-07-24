namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mesajlar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mesajs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Konu = c.String(),
                        Ileti = c.String(),
                        Personel_sicil = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Personels", t => t.Personel_sicil)
                .Index(t => t.Personel_sicil);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mesajs", "Personel_sicil", "dbo.Personels");
            DropIndex("dbo.Mesajs", new[] { "Personel_sicil" });
            DropTable("dbo.Mesajs");
        }
    }
}
