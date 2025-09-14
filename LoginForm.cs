using System;
using System.Linq;
using System.Windows.Forms;
using LagerverwaltungModern25._04._2025.Models;
using LagerverwaltungModern25._04._2025.Data;
using Microsoft.EntityFrameworkCore;
using Lagerverwaltung;


namespace LagerverwaltungModern25._04._2025
{
    public partial class LoginForm : Form
    {
        private readonly ApplicationDbContext _context;
        public Benutzer AngemeldeterBenutzer { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
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
        private void btnAnmelden_Click(object sender, EventArgs e)
        {
            string benutzername = textBoxBenutzername.Text;
            string passwort = textBoxPasswort.Text;

            var benutzer = _context.Benutzer
                .Include(b => b.Rolle) // ← Das lädt die verknüpfte Rolle mit
                .FirstOrDefault(b => b.Benutzername == benutzername && b.Passwort == passwort);

            if (benutzer != null)
            {
                /*  var hauptForm = new LagerForm(_context, benutzer); // ← FIX: Beide Parameter
                  this.Hide();
                  hauptForm.ShowDialog();
                  this.Show();*/
                this.Hide();
                var mainForm = new ModernLagerForm(_context, benutzer); // Übergabe des Benutzers
                mainForm.FormClosed += (s, args) => this.Close(); // App beenden bei Hauptform schließen
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Benutzername oder Passwort ist falsch.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegistrieren_Click(object sender, EventArgs e)
        {
            RegistrierenForm registrierenForm = new RegistrierenForm();
            registrierenForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);

        }
    }
}
