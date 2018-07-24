using System.Data.Entity;

namespace SATS.VeriTabani
{
    public class Context : DbContext
    {
        public DbSet<Il> iller { get; set; }
        public DbSet<Ilce> ilceler { get; set; }
        public DbSet<Magdur> magdurlar { get; set; }
        public DbSet<Mahalle> mahalleler { get; set; }
        public DbSet<Olay> olaylar { get; set; }
        public DbSet<Personel> personeller { get; set; }
        public DbSet<PolisMerkezi> polisMerkezleri { get; set; }
        public DbSet<Rutbe> rutbeler { get; set; }
        public DbSet<Suc> suclar { get; set; }
        public DbSet<Supheli> supheliler { get; set; }
        public DbSet<FailDurum> failDurumu { get; set; }
        public DbSet<Mesaj> mesajlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Olay>()
                .Property(f => f.tarih)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Magdur>()
                .HasIndex(x => x.TC)
                .IsUnique();

            modelBuilder.Entity<Supheli>()
                .HasIndex(x => x.TC)
                .IsUnique();
        }
    }
}
