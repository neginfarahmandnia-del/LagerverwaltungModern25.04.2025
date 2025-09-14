using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LagerverwaltungModern25._04._2025.Data;
using LagerverwaltungModern25._04._2025.Models;

namespace LagerverwaltungModern25._04._2025
{
    public partial class KategorieForm : Form
    {
        private readonly ApplicationDbContext _context;

        public KategorieForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;

            LadeOberkategorien();
            comboBoxUnterkategorie.Visible = false;
            labelUnterkategorie.Visible = false;
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
        private void LadeOberkategorien()
        {
            var oberkategorien = _context.Kategorien
                .Where(k => k.OberkategorieId == null)
                .ToList();

            comboBoxOberkategorie.DataSource = oberkategorien;
            comboBoxOberkategorie.DisplayMember = "Name";
            comboBoxOberkategorie.ValueMember = "Id";
        }
        private void radioButtonOberkategorie_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxOberkategorie.Enabled = false;
        }
        private void radioButtonUnterkategorie_CheckedChanged(object sender, EventArgs e)
        {
            bool istUnterkategorie = radioButtonUnterkategorie.Checked;
            comboBoxOberkategorie.Enabled = istUnterkategorie;
            comboBoxOberkategorie.Visible = istUnterkategorie;
            labelOberkategorie.Visible = istUnterkategorie;
        }

        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            string bezeichnung = textBoxBezeichnung.Text.Trim();

            if (string.IsNullOrWhiteSpace(bezeichnung))
            {
                MessageBox.Show("Bitte geben Sie eine Bezeichnung ein.");
                return;
            }

            var neueKategorie = new Kategorie
            {
                Name = bezeichnung
            };

            if (radioButtonUnterkategorie.Checked)
            {
                if (comboBoxOberkategorie.SelectedItem is Kategorie oberkategorie)
                {
                    neueKategorie.OberkategorieId = oberkategorie.Id;
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Oberkategorie aus.");
                    return;
                }
            }

            _context.Kategorien.Add(neueKategorie);
            _context.SaveChanges();
            LadeOberkategorien(); // ComboBox neu befüllen

            MessageBox.Show("Kategorie gespeichert.");
            this.Close();
        }

        private void KategorieForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);

        }
    }
}
