using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LagerverwaltungModern25._04._2025.Models
{
    public class Artikel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Bestand { get; set; }
        public int Mindestbestand { get; set; } // <- neu

        [Range(0, double.MaxValue)]
        [Precision(18, 2)]
        public decimal Preis { get; set; }

        public int KategorieId { get; set; }

        [ForeignKey("KategorieId")]
        public Kategorie Kategorie { get; set; } = null!;
    }
}
