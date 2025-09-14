using LagerverwaltungModern25._04._2025.Data;
using LagerverwaltungModern25._04._2025.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LagerverwaltungModern25._04._2025
{
    public partial class LagerForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly Benutzer _aktuellerBenutzer;

        public LagerForm(ApplicationDbContext context, Benutzer benutzer)
        {
            InitializeComponent();
          
            _context = context;
            _aktuellerBenutzer = benutzer;

            lblBegruessung.Text = $"Willkommen, {_aktuellerBenutzer.Benutzername}!";
            RollenbasierteNavigation();
            SetzeZugriffsrechte();

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.DataError += dataGridView1_DataError;
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

        private void SetzeZugriffsrechte()
        {
            string rolle = _aktuellerBenutzer.Rolle.Name;

            switch (rolle)
            {
                case "Admin":
                    // Alles sichtbar, keine Einschränkungen
                    break;

                case "Manager":
                    Bverwaltung.Enabled = false;
                    break;

                case "Mitarbeiter":
                    Bverwaltung.Enabled = false;
                    btnBerichte.Enabled = false;
                    break;

                case "Lagerleiter":
                    Bverwaltung.Enabled = false;
                    btnBerichte.Enabled = false;
                    break;

                case "Buchhaltung":
                    Bverwaltung.Enabled = false;
                    break;

                case "Gast":
                    Bverwaltung.Enabled = false;
                    btnBerichte.Enabled = true;
                    break;

                default:
                    MessageBox.Show("Unbekannte Rolle: Zugriff verweigert.");
                    this.Close();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);
            LadeKategorien();
            LadeDaten();
            LadeKategorienFilter();
        }
        private void LadeKategorienFilter()
        {
            var kategorien = _context.Kategorien.ToList();
            kategorien.Insert(0, new Kategorie { Id = 0, Name = "Alle Kategorien" });

            cmbKategorieFilter.DataSource = kategorien;
            cmbKategorieFilter.DisplayMember = "Name";
            cmbKategorieFilter.ValueMember = "Id";
        }

        private void LadeUnterkategorien(int oberkategorieId)
        {
            using (var context = new ApplicationDbContext())
            {
                var unterkategorien = context.Kategorien
                    .Where(k => k.OberkategorieId == oberkategorieId)
                    .ToList();

                comboBoxUnterkategorie.DataSource = unterkategorien;
                comboBoxUnterkategorie.DisplayMember = "Name";
                comboBoxUnterkategorie.ValueMember = "Id";
            }
        }
        private void LadeKategorien()
        {
            try
            {
                comboBoxKategorie.DataSource = _context.Kategorien.ToList();
                comboBoxKategorie.DisplayMember = "Name";
                comboBoxKategorie.ValueMember = "Id";
                var kategorien = _context.Kategorien.ToList();

                var oberkategorien = kategorien.Where(k => k.OberkategorieId == null).ToList();
                comboBoxOberkategorie.DataSource = oberkategorien;
                comboBoxOberkategorie.DisplayMember = "Name";
                comboBoxOberkategorie.ValueMember = "Id";

                comboBoxOberkategorie.SelectedIndexChanged -= comboBoxOberkategorie_SelectedIndexChanged;
                comboBoxOberkategorie.SelectedIndexChanged += comboBoxOberkategorie_SelectedIndexChanged;
                comboBoxOberkategorie.SelectedIndexChanged += (s, e) =>
                {
                    int oberId = Convert.ToInt32(comboBoxOberkategorie.SelectedValue);
                    var unterkategorien = kategorien.Where(k => k.OberkategorieId == oberId).ToList();

                    comboBoxUnterkategorie.DataSource = unterkategorien;
                    comboBoxUnterkategorie.DisplayMember = "Name";
                    comboBoxUnterkategorie.ValueMember = "Id";
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Kategorien: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxOberkategorie_SelectedIndexChanged(object? sender, EventArgs e) // ❌
        {
            if (comboBoxOberkategorie.SelectedItem is Kategorie ausgewaehlte)
            {
                LadeUnterkategorien(ausgewaehlte.Id);
            }
            if (comboBoxOberkategorie.SelectedValue is int oberId)
            {
                var unterkategorien = _context.Kategorien
                    .Where(k => k.OberkategorieId == oberId)
                    .ToList();

                comboBoxUnterkategorie.DataSource = unterkategorien;
                comboBoxUnterkategorie.DisplayMember = "Name";
                comboBoxUnterkategorie.ValueMember = "Id";
            }
        }

        private void RollenbasierteNavigation()
        {
            if (_aktuellerBenutzer.Rolle?.Name != "Admin")
                Bverwaltung.Visible = false;

            if (_aktuellerBenutzer.Rolle?.Name == "Gast")
            {
                Bverwaltung.Visible = false;
                btnBerichte.Enabled = false;
                btnBestellungen.Enabled = false;
                btnWarenausgang.Enabled = false;
                buttonHinzufügen.Enabled = false;
                buttonLöschen.Enabled = false;
            }
        }

        private void LadeDaten()
        {
            try
            {
                var artikelListe = _context.Artikel.Include(a => a.Kategorie).ToList();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;

                dataGridView1.Columns.Clear();

                // Spalten neu definieren
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Artikelname",
                    Name = "Name"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Bestand",
                    HeaderText = "Bestand",
                    Name = "Bestand"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Preis",
                    HeaderText = "Preis",
                    Name = "Preis"
                });

                // Kategorien-Spalte
                var kategorieColumn = new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "KategorieId",
                    HeaderText = "Kategorie",
                    Name = "Kategorie",
                    DisplayMember = "Name",
                    ValueMember = "Id",
                    DataSource = _context.Kategorien.ToList()
                };
                dataGridView1.Columns.Add(kategorieColumn);

                // Datenbindung
                dataGridView1.DataSource = artikelListe;

                // Farbige Markierung: rote Zeile bei niedrigem Bestand
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Bestand"].Value is int bestand && bestand < 5)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Daten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.BeginEdit(true);
            }
        }
        private void comboBoxUnterkategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logik bei Auswahl einer Unterkategorie
        }


        private void dataGridView1_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Artikel geänderterArtikel)
                {
                    var artikel = _context.Artikel.FirstOrDefault(a => a.Id == geänderterArtikel.Id);
                    if (artikel != null)
                    {
                        artikel.Name = geänderterArtikel.Name;
                        artikel.Bestand = geänderterArtikel.Bestand;
                        artikel.Preis = geänderterArtikel.Preis;
                        artikel.KategorieId = geänderterArtikel.KategorieId;

                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Fehler beim Speichern: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void dataGridView1_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ungültiger Wert eingegeben.");
            e.Cancel = true;
        }




        private void ButtonLöschen_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Artikel artikel)
            {
                try
                {
                    _context.Artikel.Remove(artikel);
                    _context.SaveChanges();
                    LadeDaten();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonHinzufügen_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxKategorie.SelectedValue == null)
                {
                    MessageBox.Show("Bitte eine Kategorie auswählen.");
                    return;
                }
                var artikel = new Artikel
                {
                    Name = "Neuer Artikel",
                    Bestand = 0,
                    Preis = 0,
                    KategorieId = Convert.ToInt32(comboBoxKategorie.SelectedValue)
                };

                _context.Artikel.Add(artikel);
                _context.SaveChanges();
                LadeDaten();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Hinzufügen: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBerichte_Click_1(object sender, EventArgs e)
        {
            new BerichtForm(_context).ShowDialog();
        }

        private void BtnBestellungen_Click(object sender, EventArgs e)
        {
            var bestellungForm = new BestellungsForm(_aktuellerBenutzer);
            bestellungForm.ShowDialog();

        }

        private void BtnWarenausgang_Click(object sender, EventArgs e)
        {
            new WarenausgangForm(_context, _aktuellerBenutzer).ShowDialog();
        }

        private void ButtonKategorieHinzufuegen_Click(object sender, EventArgs e)
        {
            var kategorieForm = new KategorieForm(_context);
            if (kategorieForm.ShowDialog() == DialogResult.OK)
            {
                LadeDaten();
                LadeKategorien();
            }
        }

        private void ButtonAbmelden_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // Schließe MainForm
            this.Close();
        }


        private void FilterArtikel()
        {
            var query = _context.Artikel.Include(a => a.Kategorie).AsQueryable();

            // Name-Filter (optional)
            if (!string.IsNullOrWhiteSpace(txtSuche.Text))
            {
                string suchbegriff = txtSuche.Text.Trim().ToLower();
                query = query.Where(a => a.Name.ToLower().Contains(suchbegriff));
            }

            // Kategorie-Filter (optional)
            if (cmbKategorieFilter.SelectedItem is Kategorie ausgewaehlteKategorie)
            {
                query = query.Where(a => a.KategorieId == ausgewaehlteKategorie.Id);
            }

            // Preisbereich (optional, nur wenn Min <= Max)
            if (numPreisMin.Value <= numPreisMax.Value)
            {
                query = query.Where(a => a.Preis >= numPreisMin.Value && a.Preis <= numPreisMax.Value);
            }

            // Mindestbestand (optional)
            if (numMindestBestand.Value > 0)
            {
                query = query.Where(a => a.Bestand >= numMindestBestand.Value);
            }

            var gefilterteArtikel = query.ToList();

            // Ergebnis anzeigen
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = gefilterteArtikel;
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            FilterArtikel();
        }

        private void ButtonZurücksetzen_Click(object sender, EventArgs e)
        {
            txtSuche.Clear();

            // Setze erst Min/Max korrekt
            numPreisMin.Minimum = 0;
            numPreisMin.Maximum = 10000;
            numPreisMin.Value = 0;

            numPreisMax.Minimum = 0;
            numPreisMax.Maximum = 10000;
            numPreisMax.Value = 1000;

            numMindestBestand.Minimum = 0;
            numMindestBestand.Maximum = 10000;
            numMindestBestand.Value = 0;

            cmbKategorieFilter.SelectedIndex = 0;

            LadeDaten();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Bverwaltung_Click(object sender, EventArgs e)
        {
            var benutzerForm = new BenutzerverwaltungForm(_context, _aktuellerBenutzer);
            benutzerForm.ShowDialog();
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV-Dateien (*.csv)|*.csv";
                dialog.Title = "Artikel aus CSV importieren";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ImportiereArtikelAusCsv(dialog.FileName);
                }
            }
        }
        private void ImportiereArtikelAusCsv(string pfad)
        {
            try
            {
                var artikelListe = new List<Artikel>();

                using (var reader = new StreamReader(pfad))
                {
                    string header = reader.ReadLine(); // optional: Header überspringen

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var werte = line.Split(';');

                        // Sicherstellen, dass 4 Spalten vorhanden sind
                        if (werte.Length < 4)
                        {
                            MessageBox.Show("Ungültige Zeile in der CSV-Datei:\n" + line, "CSV-Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        try
                        {
                            var artikel = new Artikel
                            {
                                Name = werte[0],
                                Bestand = int.Parse(werte[1]),
                                Preis = decimal.Parse(werte[2]),
                                KategorieId = int.Parse(werte[3])
                            };

                            artikelListe.Add(artikel);
                            _context.Artikel.Add(artikel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Fehler beim Verarbeiten der Zeile:\n{line}\n{ex.Message}", "Verarbeitungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                    _context.SaveChanges(); // Nur wenn Artikel gespeichert werden sollen
                }

                // DataGridView aktualisieren
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _context.Artikel.Include(a => a.Kategorie).ToList();

                MarkiereNiedrigeBestände(); // Optional visuelle Warnung

                MessageBox.Show("Import erfolgreich abgeschlossen.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Daten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MarkiereNiedrigeBestände()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Bestand"].Value != null && int.TryParse(row.Cells["Bestand"].Value.ToString(), out int bestand))
                {
                    if (bestand < 5) // Mindestgrenze für Warnung
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }


    }
}


