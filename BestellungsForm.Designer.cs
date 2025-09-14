﻿namespace LagerverwaltungModern25._04._2025
{
    partial class BestellungsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxArtikel;
        private System.Windows.Forms.TextBox textBoxMenge;
        private System.Windows.Forms.Button buttonBestellen;
        private System.Windows.Forms.Button buttonAusgang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxArtikel = new ComboBox();
            textBoxMenge = new TextBox();
            buttonBestellen = new Button();
            buttonAusgang = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBoxArtikel
            // 
            comboBoxArtikel.FormattingEnabled = true;
            comboBoxArtikel.Location = new Point(30, 40);
            comboBoxArtikel.Name = "comboBoxArtikel";
            comboBoxArtikel.Size = new Size(220, 23);
            comboBoxArtikel.TabIndex = 2;
            // 
            // textBoxMenge
            // 
            textBoxMenge.Location = new Point(30, 100);
            textBoxMenge.Name = "textBoxMenge";
            textBoxMenge.Size = new Size(100, 23);
            textBoxMenge.TabIndex = 3;
            // 
            // buttonBestellen
            // 
            buttonBestellen.Location = new Point(30, 150);
            buttonBestellen.Name = "buttonBestellen";
            buttonBestellen.Size = new Size(100, 32);
            buttonBestellen.TabIndex = 4;
            buttonBestellen.Text = "Bestellen";
            buttonBestellen.UseVisualStyleBackColor = true;
            buttonBestellen.Click += buttonBestellen_Click;
            // 
            // buttonAusgang
            // 
            buttonAusgang.Location = new Point(150, 150);
            buttonAusgang.Name = "buttonAusgang";
            buttonAusgang.Size = new Size(100, 32);
            buttonAusgang.TabIndex = 5;
            buttonAusgang.Text = "Ausgang";
            buttonAusgang.UseVisualStyleBackColor = true;
            buttonAusgang.Click += buttonAusgang_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 20);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Artikel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 80);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Menge:";
            // 
            // BestellungsForm
            // 
            ClientSize = new Size(292, 211);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(comboBoxArtikel);
            Controls.Add(textBoxMenge);
            Controls.Add(buttonBestellen);
            Controls.Add(buttonAusgang);
            Name = "BestellungsForm";
            Text = "Bestellungen & Warenausgang";
            Load += BestellungsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
