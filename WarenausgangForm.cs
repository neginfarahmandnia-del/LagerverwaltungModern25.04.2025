using LagerverwaltungModern25._04._2025.Data;
using LagerverwaltungModern25._04._2025.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using System.ComponentModel;

namespace LagerverwaltungModern25._04._2025
{
    public partial class WarenausgangForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly Benutzer _aktuellerBenutzer;

        public WarenausgangForm(ApplicationDbContext context, Benutzer benutzer)
        {
            InitializeComponent();
            _context = context;
            _aktuellerBenutzer = benutzer;
          
            LadeArtikel();
            LoadWarenausgaenge();

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
        private void buttonFiltern_Click(object sender, EventArgs e)
        {
            LadeGefilterteWarenausgaenge();
        }
        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewAusgaenge.Rows.Count == 0)
            {
                MessageBox.Show("Keine Daten zum Exportieren.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Warenausgänge");

            for (int i = 0; i < dataGridViewAusgaenge.Columns.Count; i++)
            {
                ws.Cell(1, i + 1).Value = dataGridViewAusgaenge.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridViewAusgaenge.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewAusgaenge.Columns.Count; j++)
                {
                    ws.Cell(i + 2, j + 1).Value = dataGridViewAusgaenge.Rows[i].Cells[j].Value?.ToString();
                }
            }

            using var sfd = new SaveFileDialog { Filter = "Excel-Datei (*.xlsx)|*.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(sfd.FileName);
                MessageBox.Show("Export erfolgreich.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LadeGefilterteWarenausgaenge()
        {
            DateTime von = dateTimePickerVon.Value.Date;
            DateTime bis = dateTimePickerBis.Value.Date.AddDays(1).AddTicks(-1);

            var query = _context.Warenausgaenge
                .Include(w => w.Artikel)
                .Include(w => w.Benutzer)
                .Where(w => w.Ausgangsdatum >= von && w.Ausgangsdatum <= bis);

            if (comboBoxArtikelFilter.SelectedItem is Artikel artikel)
            {
                query = query.Where(w => w.ArtikelId == artikel.Id);
            }

            if (!string.IsNullOrWhiteSpace(textBoxSuche.Text))
            {
                string suchtext = textBoxSuche.Text.ToLower();
                query = query.Where(w =>
                    w.Artikel.Name.ToLower().Contains(suchtext) ||
                    w.Benutzer.Benutzername.ToLower().Contains(suchtext));
            }

            var daten = query
                .OrderByDescending(w => w.Ausgangsdatum)
                .Select(w => new
                {
                    Datum = w.Ausgangsdatum,
                    Artikel = w.Artikel.Name,
                    Menge = w.Menge,
                    Benutzer = w.Benutzer.Benutzername
                })
                .ToList();

            dataGridViewAusgaenge.DataSource = daten;
        }

        private void LadeArtikel()
        {
            comboBoxArtikel.DataSource = _context.Artikel.ToList();
            comboBoxArtikel.DisplayMember = "Name";
            comboBoxArtikel.ValueMember = "Id";
        }
        private void LoadWarenausgaenge()
        {
            using (var db = new ApplicationDbContext())
            {
                var warenausgaenge = db.Warenausgaenge
                    .Include(w => w.Artikel)
                    .Include(w => w.Benutzer)
                    .OrderByDescending(w => w.Datum)
                    .ToList();

                dataGridViewAusgaenge.DataSource = new BindingList<Warenausgang>(warenausgaenge);

                // Sichtbare Spalten anpassen
                dataGridViewAusgaenge.Columns["Id"].Visible = false;
                dataGridViewAusgaenge.Columns["ArtikelId"].Visible = false;
                dataGridViewAusgaenge.Columns["BenutzerId"].Visible = false;
                dataGridViewAusgaenge.Columns["Benutzer"].Visible = false;
                dataGridViewAusgaenge.Columns["Kommentar"].Visible = false;

                dataGridViewAusgaenge.Columns["Datum"].HeaderText = "Datum";
                dataGridViewAusgaenge.Columns["Artikel"].HeaderText = "Artikel";
                dataGridViewAusgaenge.Columns["Menge"].HeaderText = "Menge";

                dataGridViewAusgaenge.Columns["Datum"].DisplayIndex = 0;
                dataGridViewAusgaenge.Columns["Artikel"].DisplayIndex = 1;
                dataGridViewAusgaenge.Columns["Menge"].DisplayIndex = 2;
            }
        }
           
           private void buttonRückbuchen_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewAusgaenge.CurrentRow?.DataBoundItem is not null)
            {
                string artikelName = dataGridViewAusgaenge.CurrentRow.Cells["Artikel"]?.Value?.ToString();
                DateTime datum = (DateTime)dataGridViewAusgaenge.CurrentRow.Cells["Datum"].Value;

                var ausgang = _context.Warenausgaenge
                    .Include(w => w.Artikel)
                    .FirstOrDefault(w => w.Artikel.Name == artikelName && w.Ausgangsdatum == datum);

                if (ausgang != null)
                {
                    ausgang.Artikel.Bestand += ausgang.Menge;
                    _context.Warenausgaenge.Remove(ausgang);
                    _context.SaveChanges();

                    MessageBox.Show("Rückbuchung erfolgreich.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LadeGefilterteWarenausgaenge();
                }
                else
                {
                    MessageBox.Show("Ausgang konnte nicht gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        





        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            if (comboBoxArtikel.SelectedItem is Artikel artikel && numericUpDownMenge.Value > 0)
            {
                int menge = (int)numericUpDownMenge.Value;

                artikel = _context.Artikel.Find(artikel.Id); // Neu laden

                if (artikel != null && artikel.Bestand >= menge)
                {
                    artikel.Bestand -= menge;

                    var ausgang = new Warenausgang
                    {
                        ArtikelId = artikel.Id,
                        BenutzerId = _aktuellerBenutzer.Id,
                        Menge = menge,
                        Ausgangsdatum = DateTime.Now
                    };

                    _context.Warenausgaenge.Add(ausgang);
                    _context.SaveChanges();

                    if (artikel.Bestand < artikel.Mindestbestand)
                    {
                        MessageBox.Show($"Warnung: Bestand von '{artikel.Name}' niedrig ({artikel.Bestand}).", "Bestandswarnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    MessageBox.Show("Warenausgang gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LadeGefilterteWarenausgaenge();
                }
                else
                {
                    MessageBox.Show("Nicht genügend Bestand vorhanden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bitte Artikel und Menge korrekt auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WarenausgangForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);

            comboBoxArtikel.DataSource = _context.Artikel.ToList();
            comboBoxArtikel.DisplayMember = "Name";
            comboBoxArtikel.ValueMember = "Id";

            comboBoxArtikelFilter.DataSource = _context.Artikel.ToList();
            comboBoxArtikelFilter.DisplayMember = "Name";
            comboBoxArtikelFilter.ValueMember = "Id";

            dateTimePickerVon.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerBis.Value = DateTime.Now;

            LadeGefilterteWarenausgaenge();

        }
        private void LadeAusgaenge()
        {
            int? artikelId = comboBoxArtikelFilter.SelectedItem is Artikel artikel ? artikel.Id : (int?)null;
            DateTime von = dateTimePickerVon.Value.Date;
            DateTime bis = dateTimePickerBis.Value.Date.AddDays(1).AddTicks(-1);

            var query = _context.Warenausgaenge
                .Include(w => w.Artikel)
                .Include(w => w.Benutzer)
                .Where(w => w.Ausgangsdatum >= von && w.Ausgangsdatum <= bis);

            if (artikelId.HasValue)
                query = query.Where(w => w.ArtikelId == artikelId.Value);

            var liste = query.OrderByDescending(w => w.Ausgangsdatum).ToList();

            dataGridViewAusgaenge.DataSource = new BindingList<Warenausgang>(liste);

            // Sichtbare Spalten anpassen
            dataGridViewAusgaenge.Columns["Id"].Visible = false;
            dataGridViewAusgaenge.Columns["ArtikelId"].Visible = false;
            dataGridViewAusgaenge.Columns["BenutzerId"].Visible = false;
            dataGridViewAusgaenge.Columns["Benutzer"].Visible = false;
            dataGridViewAusgaenge.Columns["Kommentar"].Visible = false;

            dataGridViewAusgaenge.Columns["Ausgangsdatum"].HeaderText = "Datum";
            dataGridViewAusgaenge.Columns["Artikel"].HeaderText = "Artikel";
            dataGridViewAusgaenge.Columns["Menge"].HeaderText = "Menge";

            dataGridViewAusgaenge.Columns["Ausgangsdatum"].DisplayIndex = 0;
            dataGridViewAusgaenge.Columns["Artikel"].DisplayIndex = 1;
            dataGridViewAusgaenge.Columns["Menge"].DisplayIndex = 2;
        }

        private void ButtonWarenausgangChart_Click(object sender, EventArgs e)
        {
            var chartForm = new WarenausgangChartForm();
            chartForm.ShowDialog();
        }
    }
}
