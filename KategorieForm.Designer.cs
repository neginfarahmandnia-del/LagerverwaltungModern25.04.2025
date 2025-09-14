namespace LagerverwaltungModern25._04._2025
{
    partial class KategorieForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelBezeichnung;
        private System.Windows.Forms.TextBox textBoxBezeichnung;
        private System.Windows.Forms.Label labelOberkategorie;
        private System.Windows.Forms.ComboBox comboBoxOberkategorie;
        private System.Windows.Forms.Label labelUnterkategorie;
        private System.Windows.Forms.ComboBox comboBoxUnterkategorie;
        private System.Windows.Forms.Button buttonSpeichern;
     

        private RadioButton radioButtonOberkategorie;
        private RadioButton radioButtonUnterkategorie;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelBezeichnung = new Label();
            textBoxBezeichnung = new TextBox();
            radioButtonOberkategorie = new RadioButton();
            radioButtonUnterkategorie = new RadioButton();
            labelOberkategorie = new Label();
            comboBoxOberkategorie = new ComboBox();
            labelUnterkategorie = new Label();
            comboBoxUnterkategorie = new ComboBox();
            buttonSpeichern = new Button();
            SuspendLayout();
            // 
            // labelBezeichnung
            // 
            labelBezeichnung.AutoSize = true;
            labelBezeichnung.Location = new Point(20, 20);
            labelBezeichnung.Name = "labelBezeichnung";
            labelBezeichnung.Size = new Size(78, 15);
            labelBezeichnung.TabIndex = 0;
            labelBezeichnung.Text = "Bezeichnung:";
            // 
            // textBoxBezeichnung
            // 
            textBoxBezeichnung.Location = new Point(120, 17);
            textBoxBezeichnung.Name = "textBoxBezeichnung";
            textBoxBezeichnung.Size = new Size(200, 23);
            textBoxBezeichnung.TabIndex = 1;
            // 
            // radioButtonOberkategorie
            // 
            radioButtonOberkategorie.Checked = true;
            radioButtonOberkategorie.Location = new Point(20, 50);
            radioButtonOberkategorie.Name = "radioButtonOberkategorie";
            radioButtonOberkategorie.Size = new Size(104, 24);
            radioButtonOberkategorie.TabIndex = 2;
            radioButtonOberkategorie.TabStop = true;
            radioButtonOberkategorie.Text = "Oberkategorie";
            radioButtonOberkategorie.CheckedChanged += radioButtonOberkategorie_CheckedChanged;
            // 
            // radioButtonUnterkategorie
            // 
            radioButtonUnterkategorie.Location = new Point(150, 50);
            radioButtonUnterkategorie.Name = "radioButtonUnterkategorie";
            radioButtonUnterkategorie.Size = new Size(104, 24);
            radioButtonUnterkategorie.TabIndex = 3;
            radioButtonUnterkategorie.Text = "Unterkategorie";
            radioButtonUnterkategorie.CheckedChanged += radioButtonUnterkategorie_CheckedChanged;
            // 
            // labelOberkategorie
            // 
            labelOberkategorie.AutoSize = true;
            labelOberkategorie.Location = new Point(20, 85);
            labelOberkategorie.Name = "labelOberkategorie";
            labelOberkategorie.Size = new Size(85, 15);
            labelOberkategorie.TabIndex = 4;
            labelOberkategorie.Text = "Oberkategorie:";
            // 
            // comboBoxOberkategorie
            // 
            comboBoxOberkategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOberkategorie.Enabled = false;
            comboBoxOberkategorie.Location = new Point(120, 82);
            comboBoxOberkategorie.Name = "comboBoxOberkategorie";
            comboBoxOberkategorie.Size = new Size(200, 23);
            comboBoxOberkategorie.TabIndex = 5;
            // 
            // labelUnterkategorie
            // 
            labelUnterkategorie.AutoSize = true;
            labelUnterkategorie.Location = new Point(20, 120);
            labelUnterkategorie.Name = "labelUnterkategorie";
            labelUnterkategorie.Size = new Size(88, 15);
            labelUnterkategorie.TabIndex = 6;
            labelUnterkategorie.Text = "Unterkategorie:";
            // 
            // comboBoxUnterkategorie
            // 
            comboBoxUnterkategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUnterkategorie.Location = new Point(120, 117);
            comboBoxUnterkategorie.Name = "comboBoxUnterkategorie";
            comboBoxUnterkategorie.Size = new Size(200, 23);
            comboBoxUnterkategorie.TabIndex = 7;
            // 
            // buttonSpeichern
            // 
            buttonSpeichern.Location = new Point(120, 160);
            buttonSpeichern.Name = "buttonSpeichern";
            buttonSpeichern.Size = new Size(100, 33);
            buttonSpeichern.TabIndex = 8;
            buttonSpeichern.Text = "Speichern";
            buttonSpeichern.Click += buttonSpeichern_Click;
            // 
            // KategorieForm
            // 
            ClientSize = new Size(360, 220);
            Controls.Add(labelBezeichnung);
            Controls.Add(textBoxBezeichnung);
            Controls.Add(radioButtonOberkategorie);
            Controls.Add(radioButtonUnterkategorie);
            Controls.Add(labelOberkategorie);
            Controls.Add(comboBoxOberkategorie);
            Controls.Add(labelUnterkategorie);
            Controls.Add(comboBoxUnterkategorie);
            Controls.Add(buttonSpeichern);
            Name = "KategorieForm";
            Text = "Kategorie hinzufügen";
            Load += KategorieForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}