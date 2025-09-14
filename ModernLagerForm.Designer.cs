namespace Lagerverwaltung
{
    partial class ModernLagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelSidebar;
        private Panel mainPanel;
        private Label lblWillkommen;
        private Button btnArtikel;
        private Button btnBestellungen;
        private Button btnAusgaenge;
        private Button btnBenutzerverwaltung;
        private Button btnBerichte;
        private Button btnAbmelden;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnAbmelden = new Button();
            btnBerichte = new Button();
            btnBenutzerverwaltung = new Button();
            btnAusgaenge = new Button();
            btnBestellungen = new Button();
            btnArtikel = new Button();
            mainPanel = new Panel();
            lblWillkommen = new Label();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.LightSteelBlue;
            panelSidebar.Controls.Add(btnAbmelden);
            panelSidebar.Controls.Add(btnBerichte);
            panelSidebar.Controls.Add(btnBenutzerverwaltung);
            panelSidebar.Controls.Add(btnAusgaenge);
            panelSidebar.Controls.Add(btnBestellungen);
            panelSidebar.Controls.Add(btnArtikel);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(160, 600);
            panelSidebar.TabIndex = 2;
            // 
            // btnAbmelden
            // 
            btnAbmelden.Dock = DockStyle.Top;
            btnAbmelden.FlatStyle = FlatStyle.Flat;
            btnAbmelden.Location = new Point(0, 225);
            btnAbmelden.Name = "btnAbmelden";
            btnAbmelden.Size = new Size(160, 45);
            btnAbmelden.TabIndex = 0;
            btnAbmelden.Text = "🚪 Abmelden";
            btnAbmelden.Click += btnAbmelden_Click;
            // 
            // btnBerichte
            // 
            btnBerichte.Dock = DockStyle.Top;
            btnBerichte.FlatStyle = FlatStyle.Flat;
            btnBerichte.Location = new Point(0, 180);
            btnBerichte.Name = "btnBerichte";
            btnBerichte.Size = new Size(160, 45);
            btnBerichte.TabIndex = 1;
            btnBerichte.Text = "📊 Berichte";
            btnBerichte.Click += btnBerichte_Click;
            // 
            // btnBenutzerverwaltung
            // 
            btnBenutzerverwaltung.Dock = DockStyle.Top;
            btnBenutzerverwaltung.FlatStyle = FlatStyle.Flat;
            btnBenutzerverwaltung.Location = new Point(0, 135);
            btnBenutzerverwaltung.Name = "btnBenutzerverwaltung";
            btnBenutzerverwaltung.Size = new Size(160, 45);
            btnBenutzerverwaltung.TabIndex = 2;
            btnBenutzerverwaltung.Text = "👤 Benutzer";
            btnBenutzerverwaltung.Click += btnBenutzerverwaltung_Click;
            // 
            // btnAusgaenge
            // 
            btnAusgaenge.Dock = DockStyle.Top;
            btnAusgaenge.FlatStyle = FlatStyle.Flat;
            btnAusgaenge.Location = new Point(0, 90);
            btnAusgaenge.Name = "btnAusgaenge";
            btnAusgaenge.Size = new Size(160, 45);
            btnAusgaenge.TabIndex = 3;
            btnAusgaenge.Text = "📤 Ausgänge";
            btnAusgaenge.Click += btnAusgaenge_Click;
            // 
            // btnBestellungen
            // 
            btnBestellungen.Dock = DockStyle.Top;
            btnBestellungen.FlatStyle = FlatStyle.Flat;
            btnBestellungen.Location = new Point(0, 45);
            btnBestellungen.Name = "btnBestellungen";
            btnBestellungen.Size = new Size(160, 45);
            btnBestellungen.TabIndex = 4;
            btnBestellungen.Text = "📋 Bestellungen";
            btnBestellungen.Click += btnBestellungen_Click;
            // 
            // btnArtikel
            // 
            btnArtikel.Dock = DockStyle.Top;
            btnArtikel.FlatStyle = FlatStyle.Flat;
            btnArtikel.Location = new Point(0, 0);
            btnArtikel.Name = "btnArtikel";
            btnArtikel.Size = new Size(160, 45);
            btnArtikel.TabIndex = 5;
            btnArtikel.Text = "📦 Artikel";
            btnArtikel.Click += btnArtikel_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(160, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(903, 600);
            mainPanel.TabIndex = 0;
            // 
            // lblWillkommen
            // 
            lblWillkommen.AutoSize = true;
            lblWillkommen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWillkommen.Location = new Point(170, 10);
            lblWillkommen.Name = "lblWillkommen";
            lblWillkommen.Size = new Size(0, 21);
            lblWillkommen.TabIndex = 1;
            // 
            // ModernLagerForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1063, 600);
            Controls.Add(mainPanel);
            Controls.Add(lblWillkommen);
            Controls.Add(panelSidebar);
            Name = "ModernLagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modernes Lagerverwaltungssystem";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
