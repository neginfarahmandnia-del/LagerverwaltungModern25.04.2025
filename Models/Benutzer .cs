using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LagerverwaltungModern25._04._2025.Models
{
    public class Benutzer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Benutzername { get; set; } = string.Empty;

        [Required]
        public string Passwort { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public int RolleId { get; set; }

        [ForeignKey("RolleId")]
        public Rolle Rolle { get; set; } = null!;
    }
}
