using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerverwaltungModern25._04._2025.Data;

using LagerverwaltungModern25._04._2025.Models;  // nur 1x

namespace LagerverwaltungModern25._04._2025.Models
{
    public class Warenausgang
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public Artikel Artikel { get; set; } = null!;
        public int? BenutzerId { get; set; }  // Nullable Benutzer
        public Benutzer Benutzer { get; set; } = null!;
        public int Menge { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public string? Kommentar { get; set; }
        public DateTime Ausgangsdatum { get; set; }  // ← HIER hinzufügen
    }
}
