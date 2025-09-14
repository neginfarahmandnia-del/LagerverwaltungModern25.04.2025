namespace LagerverwaltungModern25._04._2025
{
    partial class WarenausgangForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxArtikel;
        private System.Windows.Forms.NumericUpDown numericUpDownMenge;
        private System.Windows.Forms.DataGridView dataGridViewAusgaenge;
        private System.Windows.Forms.Button buttonSpeichern;
        private System.Windows.Forms.Button buttonRückbuchen;
        private System.Windows.Forms.Label labelArtikel;
        private System.Windows.Forms.Label labelMenge;
        private System.Windows.Forms.ComboBox comboBoxArtikelFilter;
        private System.Windows.Forms.DateTimePicker dateTimePickerVon;
        private System.Windows.Forms.DateTimePicker dateTimePickerBis;
        private System.Windows.Forms.Button buttonFiltern;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.TextBox textBoxSuche;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxArtikel = new ComboBox();
            numericUpDownMenge = new NumericUpDown();
            buttonSpeichern = new Button();
            labelArtikel = new Label();
            labelMenge = new Label();
            dataGridViewAusgaenge = new DataGridView();
            buttonRückbuchen = new Button();
            comboBoxArtikelFilter = new ComboBox();
            dateTimePickerVon = new DateTimePicker();
            dateTimePickerBis = new DateTimePicker();
            buttonFiltern = new Button();
            buttonExportExcel = new Button();
            textBoxSuche = new TextBox();
            buttonWarenausgangChart = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMenge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAusgaenge).BeginInit();
            SuspendLayout();
            // 
            // comboBoxArtikel
            // 
            comboBoxArtikel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxArtikel.FormattingEnabled = true;
            comboBoxArtikel.Location = new Point(187, 32);
            comboBoxArtikel.Name = "comboBoxArtikel";
            comboBoxArtikel.Size = new Size(250, 23);
            comboBoxArtikel.TabIndex = 3;
            // 
            // numericUpDownMenge
            // 
            numericUpDownMenge.Location = new Point(266, 67);
            numericUpDownMenge.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownMenge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownMenge.Name = "numericUpDownMenge";
            numericUpDownMenge.Size = new Size(100, 23);
            numericUpDownMenge.TabIndex = 5;
            numericUpDownMenge.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonSpeichern
            // 
            buttonSpeichern.Location = new Point(497, 20);
            buttonSpeichern.Name = "buttonSpeichern";
            buttonSpeichern.Size = new Size(120, 35);
            buttonSpeichern.TabIndex = 6;
            buttonSpeichern.Text = "Speichern";
            buttonSpeichern.UseVisualStyleBackColor = true;
            buttonSpeichern.Click += buttonSpeichern_Click;
            // 
            // labelArtikel
            // 
            labelArtikel.AutoSize = true;
            labelArtikel.Location = new Point(12, 40);
            labelArtikel.Name = "labelArtikel";
            labelArtikel.Size = new Size(44, 15);
            labelArtikel.TabIndex = 2;
            labelArtikel.Text = "Artikel:";
            // 
            // labelMenge
            // 
            labelMenge.AutoSize = true;
            labelMenge.Location = new Point(213, 75);
            labelMenge.Name = "labelMenge";
            labelMenge.Size = new Size(47, 15);
            labelMenge.TabIndex = 4;
            labelMenge.Text = "Menge:";
            // 
            // dataGridViewAusgaenge
            // 
            dataGridViewAusgaenge.AllowUserToAddRows = false;
            dataGridViewAusgaenge.AllowUserToDeleteRows = false;
            dataGridViewAusgaenge.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAusgaenge.Location = new Point(12, 99);
            dataGridViewAusgaenge.MultiSelect = false;
            dataGridViewAusgaenge.Name = "dataGridViewAusgaenge";
            dataGridViewAusgaenge.ReadOnly = true;
            dataGridViewAusgaenge.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAusgaenge.Size = new Size(685, 259);
            dataGridViewAusgaenge.TabIndex = 0;
            // 
            // buttonRückbuchen
            // 
            buttonRückbuchen.Location = new Point(12, 369);
            buttonRückbuchen.Name = "buttonRückbuchen";
            buttonRückbuchen.Size = new Size(150, 38);
            buttonRückbuchen.TabIndex = 1;
            buttonRückbuchen.Text = "Rückbuchung";
            buttonRückbuchen.UseVisualStyleBackColor = true;
            buttonRückbuchen.Click += buttonRückbuchen_Click;
            // 
            // comboBoxArtikelFilter
            // 
            comboBoxArtikelFilter.FormattingEnabled = true;
            comboBoxArtikelFilter.Location = new Point(12, 70);
            comboBoxArtikelFilter.Name = "comboBoxArtikelFilter";
            comboBoxArtikelFilter.Size = new Size(200, 23);
            comboBoxArtikelFilter.TabIndex = 3;
            // 
            // dateTimePickerVon
            // 
            dateTimePickerVon.Location = new Point(372, 67);
            dateTimePickerVon.Name = "dateTimePickerVon";
            dateTimePickerVon.Size = new Size(200, 23);
            dateTimePickerVon.TabIndex = 4;
            // 
            // dateTimePickerBis
            // 
            dateTimePickerBis.Location = new Point(578, 67);
            dateTimePickerBis.Name = "dateTimePickerBis";
            dateTimePickerBis.Size = new Size(200, 23);
            dateTimePickerBis.TabIndex = 5;
            // 
            // buttonFiltern
            // 
            buttonFiltern.Location = new Point(784, 55);
            buttonFiltern.Name = "buttonFiltern";
            buttonFiltern.Size = new Size(100, 35);
            buttonFiltern.TabIndex = 6;
            buttonFiltern.Text = "Filtern";
            buttonFiltern.UseVisualStyleBackColor = true;
            buttonFiltern.Click += buttonFiltern_Click;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Location = new Point(324, 369);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(150, 38);
            buttonExportExcel.TabIndex = 7;
            buttonExportExcel.Text = "Export nach Excel";
            buttonExportExcel.UseVisualStyleBackColor = true;
            buttonExportExcel.Click += buttonExportExcel_Click;
            // 
            // textBoxSuche
            // 
            textBoxSuche.Location = new Point(62, 32);
            textBoxSuche.Name = "textBoxSuche";
            textBoxSuche.Size = new Size(100, 23);
            textBoxSuche.TabIndex = 0;
            // 
            // buttonWarenausgangChart
            // 
            buttonWarenausgangChart.Location = new Point(168, 369);
            buttonWarenausgangChart.Name = "buttonWarenausgangChart";
            buttonWarenausgangChart.Size = new Size(150, 38);
            buttonWarenausgangChart.TabIndex = 8;
            buttonWarenausgangChart.Text = "Warenausgang Chart";
            buttonWarenausgangChart.UseVisualStyleBackColor = true;
            buttonWarenausgangChart.Click += ButtonWarenausgangChart_Click;
            // 
            // WarenausgangForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 436);
            Controls.Add(buttonWarenausgangChart);
            Controls.Add(textBoxSuche);
            Controls.Add(buttonExportExcel);
            Controls.Add(buttonFiltern);
            Controls.Add(dateTimePickerBis);
            Controls.Add(dateTimePickerVon);
            Controls.Add(comboBoxArtikelFilter);
            Controls.Add(dataGridViewAusgaenge);
            Controls.Add(buttonRückbuchen);
            Controls.Add(labelArtikel);
            Controls.Add(comboBoxArtikel);
            Controls.Add(labelMenge);
            Controls.Add(numericUpDownMenge);
            Controls.Add(buttonSpeichern);
            Name = "WarenausgangForm";
            Text = "Warenausgang erfassen";
            Load += WarenausgangForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownMenge).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAusgaenge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button buttonWarenausgangChart;
    }
}
