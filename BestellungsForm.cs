using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using LagerverwaltungModern25._04._2025.Models;
using LagerverwaltungModern25._04._2025.Data;

namespace LagerverwaltungModern25._04._2025
{
    public partial class BestellungsForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly Benutzer _aktuellerBenutzer;

        public BestellungsForm(ApplicationDbContext context, Benutzer benutzer)
        {
            InitializeComponent();
            _aktuellerBenutzer = benutzer;
            _context = new ApplicationDbContext();

            LoadArtikel();
        }
        public BestellungsForm(Benutzer benutzer)
    : this(new ApplicationDbContext(), benutzer)
        {
        }
        public static class UIStyler
        {
            public static void ApplyModernStyle(Form form)
            {
                form.BackColor = Color.WhiteSmoke;

                foreach (Control ctrl in form.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.BackColor = Color.LightSlateGray;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }

                    if (ctrl is Label lbl)
                    {
                        lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    }
                }
            }
        }
        private void LoadArtikel()
        {
            comboBoxArtikel.DataSource = _context.Artikel.ToList();
            comboBoxArtikel.DisplayMember = "Name";
            comboBoxArtikel.ValueMember = "Id";
        }

        private void buttonBestellen_Click(object sender, EventArgs e)
        {
            if (comboBoxArtikel.SelectedItem == null || !int.TryParse(textBoxMenge.Text, out int menge) || menge <= 0)
            {
                MessageBox.Show("Bitte alle Felder korrekt ausfüllen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var artikel = (Artikel)comboBoxArtikel.SelectedItem;
            if (artikel.Bestand < menge)
            {
                MessageBox.Show("Nicht genügend Bestand vorhanden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var bestellung = new Bestellung
            {
                ArtikelId = artikel.Id,
                Menge = menge,
                Bestelldatum = DateTime.Now,
                BenutzerId = _aktuellerBenutzer.Id // <<< ID direkt setzen statt ganzes Objekt
            };

            artikel.Bestand -= menge;

            _context.Bestellungen.Add(bestellung);
            _context.Artikel.Update(artikel);

            try
            {
                _context.SaveChanges();
                MessageBox.Show("Bestellung gespeichert!");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Fehler beim Speichern: {ex.InnerException?.Message ?? ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAusgang_Click(object sender, EventArgs e)
        {
            if (comboBoxArtikel.SelectedItem is Artikel artikel &&
                int.TryParse(textBoxMenge.Text, out int menge) && menge > 0)
            {
                if (artikel.Bestand < menge)
                {
                    MessageBox.Show("Nicht genug Bestand!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                artikel.Bestand -= menge;

                var ausgang = new Warenausgang
                {
                    ArtikelId = artikel.Id,
                    BenutzerId = _aktuellerBenutzer.Id,
                    Menge = menge,
                    Ausgangsdatum = DateTime.Now
                };

                try
                {
                    _context.Warenausgaenge.Add(ausgang);
                    _context.Artikel.Update(artikel);
                    _context.SaveChanges();

                    MessageBox.Show("Warenausgang erfolgreich verbucht.");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Fehler beim Speichern: " + ex.InnerException?.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bitte gültige Artikel und Menge angeben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BestellungsForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);

        }
    }
}
