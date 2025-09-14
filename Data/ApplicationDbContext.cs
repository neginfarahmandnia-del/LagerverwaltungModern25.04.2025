using Microsoft.EntityFrameworkCore;
using LagerverwaltungModern25._04._2025.Models;

namespace LagerverwaltungModern25._04._2025.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Rolle> Rollen { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Warenausgang> Warenausgaenge { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LagerverwaltungDb;Trusted_Connection=True;");
            }
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rolle>().HasData(
                new Rolle { Id = 1, Name = "Admin" },
                new Rolle { Id = 2, Name = "Manager" },
                new Rolle { Id = 3, Name = "Mitarbeiter" },
                new Rolle { Id = 4, Name = "Lagerleiter" },
                new Rolle { Id = 5, Name = "Buchhaltung" },
                new Rolle { Id = 6, Name = "Gast" }
            );

            modelBuilder.Entity<Kategorie>().HasData(
                new Kategorie { Id = 1, Name = "Elektronik" },
                new Kategorie { Id = 2, Name = "Werkzeuge" }
            );

            modelBuilder.Entity<Benutzer>()
                .HasOne(b => b.Rolle)
                .WithMany(r => r.Benutzer)
                .HasForeignKey(b => b.RolleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Artikel>()
                .HasOne(a => a.Kategorie)
                .WithMany(k => k.Artikel)
                .HasForeignKey(a => a.KategorieId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kategorie>()
                .HasMany(k => k.Unterkategorien)
                .WithOne(k => k.Oberkategorie)
                .HasForeignKey(k => k.OberkategorieId);
        }
    }
}
