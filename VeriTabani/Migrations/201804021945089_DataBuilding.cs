namespace SATS.VeriTabani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBuilding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FailDurums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        failDurumu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Olays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        failDurum_ID = c.Int(),
                        mahalle_ID = c.Int(),
                        suc_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FailDurums", t => t.failDurum_ID)
                .ForeignKey("dbo.Mahalles", t => t.mahalle_ID)
                .ForeignKey("dbo.Sucs", t => t.suc_ID)
                .Index(t => t.failDurum_ID)
                .Index(t => t.mahalle_ID)
                .Index(t => t.suc_ID);
            
            CreateTable(
                "dbo.Magdurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TC = c.String(maxLength: 11),
                        adi = c.String(),
                        soyadi = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.TC, unique: true);
            
            CreateTable(
                "dbo.Mahalles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                        polisMerkezi_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PolisMerkezis", t => t.polisMerkezi_ID)
                .Index(t => t.polisMerkezi_ID);
            
            CreateTable(
                "dbo.PolisMerkezis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                        ilce_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ilces", t => t.ilce_ID)
                .Index(t => t.ilce_ID);
            
            CreateTable(
                "dbo.Ilces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                        İl_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ils", t => t.İl_ID)
                .Index(t => t.İl_ID);
            
            CreateTable(
                "dbo.Ils",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Personels",
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
                .ForeignKey("dbo.PolisMerkezis", t => t.polisMerkezi_ID)
                .ForeignKey("dbo.Rutbes", t => t.rutbe_ID)
                .Index(t => t.polisMerkezi_ID)
                .Index(t => t.rutbe_ID);
            
            CreateTable(
                "dbo.Rutbes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sucs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suphelis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TC = c.String(maxLength: 11),
                        adi = c.String(),
                        soyadi = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.TC, unique: true);
            
            CreateTable(
                "dbo.MagdurOlays",
                c => new
                    {
                        Magdur_ID = c.Int(nullable: false),
                        Olay_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Magdur_ID, t.Olay_ID })
                .ForeignKey("dbo.Magdurs", t => t.Magdur_ID, cascadeDelete: true)
                .ForeignKey("dbo.Olays", t => t.Olay_ID, cascadeDelete: true)
                .Index(t => t.Magdur_ID)
                .Index(t => t.Olay_ID);
            
            CreateTable(
                "dbo.SupheliOlays",
                c => new
                    {
                        Supheli_ID = c.Int(nullable: false),
                        Olay_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supheli_ID, t.Olay_ID })
                .ForeignKey("dbo.Suphelis", t => t.Supheli_ID, cascadeDelete: true)
                .ForeignKey("dbo.Olays", t => t.Olay_ID, cascadeDelete: true)
                .Index(t => t.Supheli_ID)
                .Index(t => t.Olay_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupheliOlays", "Olay_ID", "dbo.Olays");
            DropForeignKey("dbo.SupheliOlays", "Supheli_ID", "dbo.Suphelis");
            DropForeignKey("dbo.Olays", "suc_ID", "dbo.Sucs");
            DropForeignKey("dbo.Personels", "rutbe_ID", "dbo.Rutbes");
            DropForeignKey("dbo.Personels", "polisMerkezi_ID", "dbo.PolisMerkezis");
            DropForeignKey("dbo.Mahalles", "polisMerkezi_ID", "dbo.PolisMerkezis");
            DropForeignKey("dbo.PolisMerkezis", "ilce_ID", "dbo.Ilces");
            DropForeignKey("dbo.Ilces", "İl_ID", "dbo.Ils");
            DropForeignKey("dbo.Olays", "mahalle_ID", "dbo.Mahalles");
            DropForeignKey("dbo.MagdurOlays", "Olay_ID", "dbo.Olays");
            DropForeignKey("dbo.MagdurOlays", "Magdur_ID", "dbo.Magdurs");
            DropForeignKey("dbo.Olays", "failDurum_ID", "dbo.FailDurums");
            DropIndex("dbo.SupheliOlays", new[] { "Olay_ID" });
            DropIndex("dbo.SupheliOlays", new[] { "Supheli_ID" });
            DropIndex("dbo.MagdurOlays", new[] { "Olay_ID" });
            DropIndex("dbo.MagdurOlays", new[] { "Magdur_ID" });
            DropIndex("dbo.Suphelis", new[] { "TC" });
            DropIndex("dbo.Personels", new[] { "rutbe_ID" });
            DropIndex("dbo.Personels", new[] { "polisMerkezi_ID" });
            DropIndex("dbo.Ilces", new[] { "İl_ID" });
            DropIndex("dbo.PolisMerkezis", new[] { "ilce_ID" });
            DropIndex("dbo.Mahalles", new[] { "polisMerkezi_ID" });
            DropIndex("dbo.Magdurs", new[] { "TC" });
            DropIndex("dbo.Olays", new[] { "suc_ID" });
            DropIndex("dbo.Olays", new[] { "mahalle_ID" });
            DropIndex("dbo.Olays", new[] { "failDurum_ID" });
            DropTable("dbo.SupheliOlays");
            DropTable("dbo.MagdurOlays");
            DropTable("dbo.Suphelis");
            DropTable("dbo.Sucs");
            DropTable("dbo.Rutbes");
            DropTable("dbo.Personels");
            DropTable("dbo.Ils");
            DropTable("dbo.Ilces");
            DropTable("dbo.PolisMerkezis");
            DropTable("dbo.Mahalles");
            DropTable("dbo.Magdurs");
            DropTable("dbo.Olays");
            DropTable("dbo.FailDurums");
        }
    }
}
