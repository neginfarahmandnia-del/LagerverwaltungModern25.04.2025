using LagerverwaltungModern25._04._2025.Models;
using Microsoft.EntityFrameworkCore;

namespace LagerverwaltungModern25._04._2025
{
    public class LagerContext : DbContext
    {
        public DbSet<Artikel> Artikel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LagerDB;Trusted_Connection=True;");
        }
    }
}