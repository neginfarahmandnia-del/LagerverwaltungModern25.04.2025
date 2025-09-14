using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LagerverwaltungModern25._04._2025.Models
{
    public class Kategorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; } = string.Empty;

        public int? OberkategorieId { get; set; }

        [ForeignKey("OberkategorieId")]
        public  Kategorie? Oberkategorie { get; set; }

        public List<Kategorie> Unterkategorien { get; set; } = new();
        public List<Artikel> Artikel { get; set; } = new();
    }
}
