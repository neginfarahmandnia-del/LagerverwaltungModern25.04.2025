using LagerverwaltungModern25._04._2025;
using LagerverwaltungModern25._04._2025.Data;
using LagerverwaltungModern25._04._2025.Models;
using System;
using System.Windows.Forms;

namespace Lagerverwaltung
{
    public partial class ModernLagerForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly Benutzer _benutzer;
        private Form _aktivesFormular;

        public ModernLagerForm(ApplicationDbContext context, Benutzer benutzer)
        {
            InitializeComponent();
            _context = context;
            _benutzer = benutzer;

            lblWillkommen.Text = $"Willkommen, {_benutzer.Benutzername}";

            if (_benutzer.Rolle?.Name != "Admin")
            {
                btnBenutzerverwaltung.Enabled = false;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (_aktivesFormular != null)
                _aktivesFormular.Close();

            _aktivesFormular = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnArtikel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LagerForm(_context, _benutzer));
        }

        private void btnBestellungen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BestellungsForm(_context, _benutzer));
        }

        private void btnAusgaenge_Click(object sender, EventArgs e)
        {
            OpenChildForm(new WarenausgangForm(_context, _benutzer));
        }

        private void btnBenutzerverwaltung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BenutzerverwaltungForm(_context, _benutzer));
        }

        private void btnBerichte_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BerichtForm(_context));
        }

        private void btnAbmelden_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().Show();
        }
    }
}
