using DocumentFormat.OpenXml.Wordprocessing;

namespace LagerverwaltungModern25._04._2025
{
    partial class LagerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxOberkategorie = new ComboBox();
            comboBoxUnterkategorie = new ComboBox();
            labelOberkategorie = new Label();
            labelUnterkategorie = new Label();
            dataGridView1 = new DataGridView();
            btnBerichte = new Button();
            btnBestellungen = new Button();
            btnWarenausgang = new Button();
            buttonHinzufügen = new Button();
            buttonLöschen = new Button();
            lblBegruessung = new Label();
            comboBoxKategorie = new ComboBox();
            ButtonKategorieHinzufuegen = new Button();
            ButtonAbmelden = new Button();
            txtSuche = new TextBox();
            numPreisMin = new NumericUpDown();
            numPreisMax = new NumericUpDown();
            cmbKategorieFilter = new ComboBox();
            numMindestBestand = new NumericUpDown();
            btnFilter = new Button();
            ButtonZurücksetzen = new Button();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            Bverwaltung = new Button();
            panel3 = new Panel();
            ButtonImport = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPreisMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPreisMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMindestBestand).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxOberkategorie
            // 
            comboBoxOberkategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOberkategorie.FormattingEnabled = true;
            comboBoxOberkategorie.Location = new Point(132, 14);
            comboBoxOberkategorie.Name = "comboBoxOberkategorie";
            comboBoxOberkategorie.Size = new Size(200, 23);
            comboBoxOberkategorie.TabIndex = 0;
            comboBoxOberkategorie.SelectedIndexChanged += comboBoxOberkategorie_SelectedIndexChanged;
            // 
            // comboBoxUnterkategorie
            // 
            comboBoxUnterkategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUnterkategorie.FormattingEnabled = true;
            comboBoxUnterkategorie.Location = new Point(132, 54);
            comboBoxUnterkategorie.Name = "comboBoxUnterkategorie";
            comboBoxUnterkategorie.Size = new Size(200, 23);
            comboBoxUnterkategorie.TabIndex = 1;
            comboBoxUnterkategorie.SelectedIndexChanged += comboBoxUnterkategorie_SelectedIndexChanged;
            // 
            // labelOberkategorie
            // 
            labelOberkategorie.AutoSize = true;
            labelOberkategorie.Location = new Point(12, 17);
            labelOberkategorie.Name = "labelOberkategorie";
            labelOberkategorie.Size = new Size(85, 15);
            labelOberkategorie.TabIndex = 2;
            labelOberkategorie.Text = "Oberkategorie:";
            // 
            // labelUnterkategorie
            // 
            labelUnterkategorie.AutoSize = true;
            labelUnterkategorie.Location = new Point(12, 57);
            labelUnterkategorie.Name = "labelUnterkategorie";
            labelUnterkategorie.Size = new Size(88, 15);
            labelUnterkategorie.TabIndex = 3;
            labelUnterkategorie.Text = "Unterkategorie:";
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(12, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(846, 211);
            dataGridView1.TabIndex = 0;
            // 
            // btnBerichte
            // 
            btnBerichte.Location = new Point(8, 127);
            btnBerichte.Name = "btnBerichte";
            btnBerichte.Size = new Size(122, 23);
            btnBerichte.TabIndex = 0;
            btnBerichte.Text = "Berichte";
            btnBerichte.Click += BtnBerichte_Click_1;
            // 
            // btnBestellungen
            // 
            btnBestellungen.Location = new Point(8, 38);
            btnBestellungen.Name = "btnBestellungen";
            btnBestellungen.Size = new Size(122, 23);
            btnBestellungen.TabIndex = 0;
            btnBestellungen.Text = "Bestellungen";
            btnBestellungen.Click += BtnBestellungen_Click;
            // 
            // btnWarenausgang
            // 
            btnWarenausgang.Location = new Point(8, 69);
            btnWarenausgang.Name = "btnWarenausgang";
            btnWarenausgang.Size = new Size(122, 23);
            btnWarenausgang.TabIndex = 0;
            btnWarenausgang.Text = "Warenausgang";
            btnWarenausgang.Click += BtnWarenausgang_Click;
            // 
            // buttonHinzufügen
            // 
            buttonHinzufügen.Location = new Point(370, 78);
            buttonHinzufügen.Name = "buttonHinzufügen";
            buttonHinzufügen.Size = new Size(114, 25);
            buttonHinzufügen.TabIndex = 0;
            buttonHinzufügen.Text = "Hinzufügen";
            buttonHinzufügen.Click += ButtonHinzufügen_Click_1;
            // 
            // buttonLöschen
            // 
            buttonLöschen.Location = new Point(371, 47);
            buttonLöschen.Name = "buttonLöschen";
            buttonLöschen.Size = new Size(114, 25);
            buttonLöschen.TabIndex = 0;
            buttonLöschen.Text = "Löschen";
            buttonLöschen.Click += ButtonLöschen_Click_1;
            // 
            // lblBegruessung
            // 
            lblBegruessung.Location = new Point(30, 19);
            lblBegruessung.Name = "lblBegruessung";
            lblBegruessung.Size = new Size(400, 23);
            lblBegruessung.TabIndex = 0;
            lblBegruessung.Text = "Willkommen!";
            // 
            // comboBoxKategorie
            // 
            comboBoxKategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKategorie.FormattingEnabled = true;
            comboBoxKategorie.Location = new Point(132, 86);
            comboBoxKategorie.Name = "comboBoxKategorie";
            comboBoxKategorie.Size = new Size(200, 23);
            comboBoxKategorie.TabIndex = 10;
            // 
            // ButtonKategorieHinzufuegen
            // 
            ButtonKategorieHinzufuegen.Location = new Point(370, 17);
            ButtonKategorieHinzufuegen.Name = "ButtonKategorieHinzufuegen";
            ButtonKategorieHinzufuegen.Size = new Size(114, 23);
            ButtonKategorieHinzufuegen.TabIndex = 11;
            ButtonKategorieHinzufuegen.Text = "Kategorie hinzufügen";
            ButtonKategorieHinzufuegen.UseVisualStyleBackColor = true;
            ButtonKategorieHinzufuegen.Click += ButtonKategorieHinzufuegen_Click;
            // 
            // ButtonAbmelden
            // 
            ButtonAbmelden.Location = new Point(8, 9);
            ButtonAbmelden.Name = "ButtonAbmelden";
            ButtonAbmelden.Size = new Size(122, 23);
            ButtonAbmelden.TabIndex = 12;
            ButtonAbmelden.Text = "Abmelden";
            ButtonAbmelden.UseVisualStyleBackColor = true;
            ButtonAbmelden.Click += ButtonAbmelden_Click;
            // 
            // txtSuche
            // 
            txtSuche.Location = new Point(57, 5);
            txtSuche.Name = "txtSuche";
            txtSuche.Size = new Size(100, 23);
            txtSuche.TabIndex = 14;
            // 
            // numPreisMin
            // 
            numPreisMin.Location = new Point(245, 6);
            numPreisMin.Name = "numPreisMin";
            numPreisMin.Size = new Size(120, 23);
            numPreisMin.TabIndex = 15;
            // 
            // numPreisMax
            // 
            numPreisMax.Location = new Point(455, 7);
            numPreisMax.Name = "numPreisMax";
            numPreisMax.Size = new Size(120, 23);
            numPreisMax.TabIndex = 16;
            // 
            // cmbKategorieFilter
            // 
            cmbKategorieFilter.FormattingEnabled = true;
            cmbKategorieFilter.Location = new Point(245, 37);
            cmbKategorieFilter.Name = "cmbKategorieFilter";
            cmbKategorieFilter.Size = new Size(121, 23);
            cmbKategorieFilter.TabIndex = 17;
            // 
            // numMindestBestand
            // 
            numMindestBestand.Location = new Point(491, 36);
            numMindestBestand.Name = "numMindestBestand";
            numMindestBestand.Size = new Size(120, 23);
            numMindestBestand.TabIndex = 18;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(5, 35);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(89, 23);
            btnFilter.TabIndex = 19;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += BtnFilter_Click;
            // 
            // ButtonZurücksetzen
            // 
            ButtonZurücksetzen.Location = new Point(96, 35);
            ButtonZurücksetzen.Name = "ButtonZurücksetzen";
            ButtonZurücksetzen.Size = new Size(89, 23);
            ButtonZurücksetzen.TabIndex = 20;
            ButtonZurücksetzen.Text = "Zurücksetzen";
            ButtonZurücksetzen.UseVisualStyleBackColor = true;
            ButtonZurücksetzen.Click += ButtonZurücksetzen_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(ButtonZurücksetzen);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnFilter);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbKategorieFilter);
            panel1.Controls.Add(numMindestBestand);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(numPreisMax);
            panel1.Controls.Add(txtSuche);
            panel1.Controls.Add(numPreisMin);
            panel1.Location = new Point(12, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 69);
            panel1.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(188, 40);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 19;
            label5.Text = "Kategorie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 45);
            label4.Name = "label4";
            label4.Size = new Size(113, 15);
            label4.TabIndex = 18;
            label4.Text = "Mindestens Bestand";
            label4.Click += Label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(371, 13);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 17;
            label3.Text = "Maximal Preis";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 10);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 16;
            label2.Text = "Minimal Preis";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 10);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 15;
            label1.Text = "Produkt";
            // 
            // panel2
            // 
            panel2.Controls.Add(ButtonImport);
            panel2.Controls.Add(Bverwaltung);
            panel2.Controls.Add(btnBestellungen);
            panel2.Controls.Add(btnWarenausgang);
            panel2.Controls.Add(ButtonAbmelden);
            panel2.Controls.Add(btnBerichte);
            panel2.Location = new Point(721, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(137, 195);
            panel2.TabIndex = 21;
            // 
            // Bverwaltung
            // 
            Bverwaltung.Location = new Point(8, 99);
            Bverwaltung.Name = "Bverwaltung";
            Bverwaltung.Size = new Size(122, 23);
            Bverwaltung.TabIndex = 12;
            Bverwaltung.Text = "Benutzerverwaltung";
            Bverwaltung.UseVisualStyleBackColor = true;
            Bverwaltung.Click += Bverwaltung_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(labelOberkategorie);
            panel3.Controls.Add(comboBoxOberkategorie);
            panel3.Controls.Add(comboBoxKategorie);
            panel3.Controls.Add(comboBoxUnterkategorie);
            panel3.Controls.Add(ButtonKategorieHinzufuegen);
            panel3.Controls.Add(buttonLöschen);
            panel3.Controls.Add(labelUnterkategorie);
            panel3.Controls.Add(buttonHinzufügen);
            panel3.Location = new Point(12, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(703, 120);
            panel3.TabIndex = 21;
            // 
            // ButtonImport
            // 
            ButtonImport.Location = new Point(8, 156);
            ButtonImport.Name = "ButtonImport";
            ButtonImport.Size = new Size(122, 23);
            ButtonImport.TabIndex = 13;
            ButtonImport.Text = "Import";
            ButtonImport.UseVisualStyleBackColor = true;
            ButtonImport.Click += ButtonImport_Click;
            // 
            // LagerForm
            // 
            ClientSize = new Size(870, 464);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblBegruessung);
            Controls.Add(dataGridView1);
            Name = "LagerForm";
            Text = "Lagerverwaltung";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPreisMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPreisMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMindestBestand).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOberkategorie;
        private System.Windows.Forms.ComboBox comboBoxUnterkategorie;
        private System.Windows.Forms.Label labelOberkategorie;
        private System.Windows.Forms.Label labelUnterkategorie;
        //private System.Windows.Forms.DataGridView dataGridViewArtikel;
        private System.Windows.Forms.ComboBox comboBoxKategorie;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBerichte;
        private System.Windows.Forms.Button btnBestellungen;
        private System.Windows.Forms.Button btnWarenausgang;
        private System.Windows.Forms.Button buttonHinzufügen;
        private System.Windows.Forms.Button buttonLöschen;
        private System.Windows.Forms.Label lblBegruessung;
        private Button ButtonKategorieHinzufuegen;
        private Button ButtonAbmelden;
        private TextBox txtSuche;
        private NumericUpDown numPreisMin;
        private NumericUpDown numPreisMax;
        private ComboBox cmbKategorieFilter;
        private NumericUpDown numMindestBestand;
        private Button btnFilter;
        private Button ButtonZurücksetzen;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Button Bverwaltung;
        private Button ButtonImport;
    }
}
