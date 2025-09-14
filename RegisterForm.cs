using System;
using System.Linq;
using System.Windows.Forms;
using LagerverwaltungModern25._04._2025.Data;

using LagerverwaltungModern25._04._2025.Models;
namespace LagerverwaltungModern25._04._2025
{
    public partial class RegistrierenForm : Form
    {
        private readonly ApplicationDbContext context;

        public RegistrierenForm()
        {
            InitializeComponent();
            context = new ApplicationDbContext();
            LadeRollen();
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
        private void LadeRollen()
        {
            var rollen = context.Rollen.ToList();
            comboBoxRolle.DataSource = rollen;
            comboBoxRolle.DisplayMember = "Name";
            comboBoxRolle.ValueMember = "Id";
        }

        private void buttonRegistrieren_Click(object sender, EventArgs e)
        {
            string benutzername = textBoxBenutzername.Text;
            string passwort = textBoxPasswort.Text;
            string email = textBoxEmail.Text;

            if (string.IsNullOrWhiteSpace(benutzername) ||
                string.IsNullOrWhiteSpace(passwort) ||
                string.IsNullOrWhiteSpace(email) ||
                comboBoxRolle.SelectedValue == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen und eine Rolle auswählen.");
                return;
            }

            int rolleId = (int)comboBoxRolle.SelectedValue;

            var benutzer = new Benutzer
            {
                Benutzername = benutzername,
                Passwort = passwort,
                Email = email,
                RolleId = rolleId
            };

            context.Benutzer.Add(benutzer);
            context.SaveChanges();

            MessageBox.Show("Registrierung erfolgreich!");
            this.Close(); // Fenster schließen nach Registrierung
        }

        private void RegistrierenForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);

            var rollen = context.Rollen.ToList();
            comboBoxRolle.DataSource = rollen;
            comboBoxRolle.DisplayMember = "Name";
            comboBoxRolle.ValueMember = "Id";
        }
    }
}
