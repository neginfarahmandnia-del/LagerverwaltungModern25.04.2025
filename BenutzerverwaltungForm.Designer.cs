namespace LagerverwaltungModern25._04._2025
{
    partial class BenutzerverwaltungForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewBenutzer;
        private System.Windows.Forms.Button buttonSchließen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewBenutzer = new DataGridView();
            buttonSchließen = new Button();
            buttonBenutzerLoeschen = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBenutzer).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBenutzer
            // 
            dataGridViewBenutzer.AllowUserToAddRows = false;
            dataGridViewBenutzer.AllowUserToDeleteRows = false;
            dataGridViewBenutzer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBenutzer.Location = new Point(18, 15);
            dataGridViewBenutzer.Margin = new Padding(3, 2, 3, 2);
            dataGridViewBenutzer.Name = "dataGridViewBenutzer";
            dataGridViewBenutzer.ReadOnly = true;
            dataGridViewBenutzer.RowHeadersWidth = 51;
            dataGridViewBenutzer.RowTemplate.Height = 29;
            dataGridViewBenutzer.Size = new Size(438, 225);
            dataGridViewBenutzer.TabIndex = 0;
            // 
            // buttonSchließen
            // 
            buttonSchließen.Location = new Point(368, 255);
            buttonSchließen.Margin = new Padding(3, 2, 3, 2);
            buttonSchließen.Name = "buttonSchließen";
            buttonSchließen.Size = new Size(88, 33);
            buttonSchließen.TabIndex = 1;
            buttonSchließen.Text = "Schließen";
            buttonSchließen.UseVisualStyleBackColor = true;
            buttonSchließen.Click += buttonSchließen_Click;
            // 
            // buttonBenutzerLoeschen
            // 
            buttonBenutzerLoeschen.Location = new Point(287, 255);
            buttonBenutzerLoeschen.Name = "buttonBenutzerLoeschen";
            buttonBenutzerLoeschen.Size = new Size(75, 33);
            buttonBenutzerLoeschen.TabIndex = 2;
            buttonBenutzerLoeschen.Text = "löschen";
            buttonBenutzerLoeschen.UseVisualStyleBackColor = true;
            buttonBenutzerLoeschen.Click += ButtonBenutzerLoeschen_Click;
            // 
            // BenutzerverwaltungForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 300);
            Controls.Add(buttonBenutzerLoeschen);
            Controls.Add(buttonSchließen);
            Controls.Add(dataGridViewBenutzer);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BenutzerverwaltungForm";
            Text = "Benutzerverwaltung";
            Load += BenutzerverwaltungForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBenutzer).EndInit();
            ResumeLayout(false);
        }
        private Button buttonBenutzerLoeschen;
    }
}
