using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LagerverwaltungModern25._04._2025.Models
{
    public class Bestellung
    {
        public int Id { get; set; }

        public int ArtikelId { get; set; }
        public  Artikel Artikel { get; set; }

        public int BenutzerId { get; set; }
        public  Benutzer Benutzer { get; set; }


        public int Menge { get; set; }

        public DateTime Bestelldatum { get; set; } = DateTime.Now;
    }
}
