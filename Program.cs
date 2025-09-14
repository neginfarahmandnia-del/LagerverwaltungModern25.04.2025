using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using LagerverwaltungModern25._04._2025.Data;
using LagerverwaltungModern25._04._2025.Models;
using Lagerverwaltung;


namespace LagerverwaltungModern25._04._2025
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var context = new ApplicationDbContext())
            {

                context.Database.Migrate();
                Console.WriteLine("Datenbankverbindung funktioniert.");

                // Nur initial hinzufügen, wenn noch keine Kategorien existieren
                if (!context.Kategorien.Any())
                {
                    var elektronik = new Kategorie { Name = "Elektronik" };
                    var werkzeuge = new Kategorie { Name = "Werkzeuge" };

                    var smartphones = new Kategorie { Name = "Smartphones", Oberkategorie = elektronik };
                    var tablets = new Kategorie { Name = "Tablets", Oberkategorie = elektronik };

                    var bohrmaschinen = new Kategorie { Name = "Bohrmaschinen", Oberkategorie = werkzeuge };

                    context.Kategorien.AddRange(elektronik, werkzeuge, smartphones, tablets, bohrmaschinen);
                    context.SaveChanges();
                }
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

    }
}
