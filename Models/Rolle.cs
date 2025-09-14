using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LagerverwaltungModern25._04._2025.Models
{
    public class Rolle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<Benutzer> Benutzer { get; set; } = new();
    }
}
