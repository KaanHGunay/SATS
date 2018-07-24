namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBaseBuild : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ilces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                        İl_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ils", t => t.İl_ID)
                .Index(t => t.İl_ID);
            
            CreateTable(
                "dbo.ils",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.polisMerkezis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                        ilce_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ilces", t => t.ilce_ID)
                .Index(t => t.ilce_ID);
            
            CreateTable(
                "dbo.mahalles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                        polisMerkezi_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.polisMerkezis", t => t.polisMerkezi_ID)
                .Index(t => t.polisMerkezi_ID);
            
            CreateTable(
                "dbo.olays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tarih = c.DateTime(nullable: false),
                        mahalle_ID = c.Int(),
                        suc_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.mahalles", t => t.mahalle_ID)
                .ForeignKey("dbo.sucs", t => t.suc_ID)
                .Index(t => t.mahalle_ID)
                .Index(t => t.suc_ID);
            
            CreateTable(
                "dbo.magdurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TC = c.String(),
                        adi = c.String(),
                        soyadi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.sucs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.suphelis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TC = c.String(),
                        adi = c.String(),
                        soyadi = c.String(),
                        supheliDurum_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.supheliDurums", t => t.supheliDurum_ID)
                .Index(t => t.supheliDurum_ID);
            
            CreateTable(
                "dbo.supheliDurums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.personels",
                c => new
                    {
                        sicil = c.Int(nullable: false, identity: false),
                        adi = c.String(),
                        soyadi = c.String(),
                        sifre = c.String(),
                        polisMerkezi_ID = c.Int(),
                        rutbe_ID = c.Int(),
                    })
                .PrimaryKey(t => t.sicil)
                .ForeignKey("dbo.polisMerkezis", t => t.polisMerkezi_ID)
                .ForeignKey("dbo.rutbes", t => t.rutbe_ID)
                .Index(t => t.polisMerkezi_ID)
                .Index(t => t.rutbe_ID);
            
            CreateTable(
                "dbo.rutbes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.magdurolays",
                c => new
                    {
                        magdur_ID = c.Int(nullable: false),
                        olay_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.magdur_ID, t.olay_ID })
                .ForeignKey("dbo.magdurs", t => t.magdur_ID, cascadeDelete: true)
                .ForeignKey("dbo.olays", t => t.olay_ID, cascadeDelete: true)
                .Index(t => t.magdur_ID)
                .Index(t => t.olay_ID);
            
            CreateTable(
                "dbo.supheliolays",
                c => new
                    {
                        supheli_ID = c.Int(nullable: false),
                        olay_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.supheli_ID, t.olay_ID })
                .ForeignKey("dbo.suphelis", t => t.supheli_ID, cascadeDelete: true)
                .ForeignKey("dbo.olays", t => t.olay_ID, cascadeDelete: true)
                .Index(t => t.supheli_ID)
                .Index(t => t.olay_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.personels", "rutbe_ID", "dbo.rutbes");
            DropForeignKey("dbo.personels", "polisMerkezi_ID", "dbo.polisMerkezis");
            DropForeignKey("dbo.mahalles", "polisMerkezi_ID", "dbo.polisMerkezis");
            DropForeignKey("dbo.suphelis", "supheliDurum_ID", "dbo.supheliDurums");
            DropForeignKey("dbo.supheliolays", "olay_ID", "dbo.olays");
            DropForeignKey("dbo.supheliolays", "supheli_ID", "dbo.suphelis");
            DropForeignKey("dbo.olays", "suc_ID", "dbo.sucs");
            DropForeignKey("dbo.olays", "mahalle_ID", "dbo.mahalles");
            DropForeignKey("dbo.magdurolays", "olay_ID", "dbo.olays");
            DropForeignKey("dbo.magdurolays", "magdur_ID", "dbo.magdurs");
            DropForeignKey("dbo.polisMerkezis", "ilce_ID", "dbo.ilces");
            DropForeignKey("dbo.ilces", "İl_ID", "dbo.ils");
            DropIndex("dbo.supheliolays", new[] { "olay_ID" });
            DropIndex("dbo.supheliolays", new[] { "supheli_ID" });
            DropIndex("dbo.magdurolays", new[] { "olay_ID" });
            DropIndex("dbo.magdurolays", new[] { "magdur_ID" });
            DropIndex("dbo.personels", new[] { "rutbe_ID" });
            DropIndex("dbo.personels", new[] { "polisMerkezi_ID" });
            DropIndex("dbo.suphelis", new[] { "supheliDurum_ID" });
            DropIndex("dbo.olays", new[] { "suc_ID" });
            DropIndex("dbo.olays", new[] { "mahalle_ID" });
            DropIndex("dbo.mahalles", new[] { "polisMerkezi_ID" });
            DropIndex("dbo.polisMerkezis", new[] { "ilce_ID" });
            DropIndex("dbo.ilces", new[] { "İl_ID" });
            DropTable("dbo.supheliolays");
            DropTable("dbo.magdurolays");
            DropTable("dbo.rutbes");
            DropTable("dbo.personels");
            DropTable("dbo.supheliDurums");
            DropTable("dbo.suphelis");
            DropTable("dbo.sucs");
            DropTable("dbo.magdurs");
            DropTable("dbo.olays");
            DropTable("dbo.mahalles");
            DropTable("dbo.polisMerkezis");
            DropTable("dbo.ils");
            DropTable("dbo.ilces");
        }
    }
}
