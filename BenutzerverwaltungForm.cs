using LagerverwaltungModern25._04._2025.Data;
using LagerverwaltungModern25._04._2025.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LagerverwaltungModern25._04._2025
{
    public partial class BenutzerverwaltungForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly Benutzer _aktuellerBenutzer;
        private List<Rolle> _rollen;

        public BenutzerverwaltungForm(ApplicationDbContext context, Benutzer aktuellerBenutzer)
        {
            InitializeComponent();
            _context = context;
            _aktuellerBenutzer = aktuellerBenutzer;

            dataGridViewBenutzer.CellDoubleClick += DataGridViewBenutzer_CellDoubleClick;
            dataGridViewBenutzer.CellValueChanged += DataGridViewBenutzer_CellValueChanged;
            dataGridViewBenutzer.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dataGridViewBenutzer.IsCurrentCellDirty)
                    dataGridViewBenutzer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            LadeBenutzer();
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
        private void LadeBenutzer()
        {
            _rollen = _context.Rollen.ToList();

            dataGridViewBenutzer.Columns.Clear();
            dataGridViewBenutzer.AutoGenerateColumns = false;
            dataGridViewBenutzer.ReadOnly = _aktuellerBenutzer.Rolle?.Name != "Admin";

            dataGridViewBenutzer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                ReadOnly = true
            });

            dataGridViewBenutzer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Benutzername",
                HeaderText = "Benutzername",
                ReadOnly = false
            });

            var rollenSpalte = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "RolleId",
                HeaderText = "Rolle",
                DataSource = _rollen,
                ValueMember = "Id",
                DisplayMember = "Name",
                Name = "RolleId",
                ReadOnly = false
            };
            dataGridViewBenutzer.Columns.Add(rollenSpalte);

            var benutzerViewModels = _context.Benutzer
                .Select(b => new BenutzerViewModel
                {
                    Id = b.Id,
                    Benutzername = b.Benutzername,
                    RolleId = b.RolleId
                })
                .ToList();

            dataGridViewBenutzer.DataSource = benutzerViewModels;
        }

        private void DataGridViewBenutzer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewBenutzer.Columns["Benutzername"].Index)
            {
                var row = dataGridViewBenutzer.Rows[e.RowIndex];
                if (row.DataBoundItem is BenutzerViewModel viewModel)
                {
                    string neuerName = Microsoft.VisualBasic.Interaction.InputBox(
                        "Neuen Benutzernamen eingeben:",
                        "Benutzer bearbeiten",
                        viewModel.Benutzername);

                    if (!string.IsNullOrWhiteSpace(neuerName))
                    {
                        viewModel.Benutzername = neuerName;

                        var original = _context.Benutzer.FirstOrDefault(b => b.Id == viewModel.Id);
                        if (original != null)
                        {
                            original.Benutzername = neuerName;
                            _context.SaveChanges();
                            LadeBenutzer();
                        }
                    }
                }
            }
        }

        private void DataGridViewBenutzer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewBenutzer.Rows[e.RowIndex];
                if (row.DataBoundItem is BenutzerViewModel viewModel)
                {
                    var benutzer = _context.Benutzer.FirstOrDefault(b => b.Id == viewModel.Id);
                    if (benutzer != null)
                    {
                        benutzer.Benutzername = viewModel.Benutzername;
                        benutzer.RolleId = viewModel.RolleId;
                        _context.SaveChanges();
                    }
                }
            }
        }

        private void ButtonBenutzerLoeschen_Click(object sender, EventArgs e)
        {
            if (dataGridViewBenutzer.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewBenutzer.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                var benutzer = _context.Benutzer.FirstOrDefault(b => b.Id == id);

                if (benutzer != null)
                {
                    var result = MessageBox.Show($"Benutzer '{benutzer.Benutzername}' wirklich löschen?",
                        "Bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _context.Benutzer.Remove(benutzer);
                        _context.SaveChanges();
                        LadeBenutzer();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte wähle einen Benutzer aus.");
            }
        }

        private void buttonSchließen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BenutzerverwaltungForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);
        }
    }
}
