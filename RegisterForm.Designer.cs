namespace LagerverwaltungModern25._04._2025
{
    partial class RegistrierenForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxBenutzername;
        private System.Windows.Forms.TextBox textBoxPasswort;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.ComboBox comboBoxRolle;
        private System.Windows.Forms.Button buttonRegistrieren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxBenutzername = new TextBox();
            textBoxPasswort = new TextBox();
            textBoxEmail = new TextBox();
            comboBoxRolle = new ComboBox();
            buttonRegistrieren = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxBenutzername
            // 
            textBoxBenutzername.Location = new Point(130, 30);
            textBoxBenutzername.Name = "textBoxBenutzername";
            textBoxBenutzername.Size = new Size(200, 23);
            textBoxBenutzername.TabIndex = 1;
            // 
            // textBoxPasswort
            // 
            textBoxPasswort.Location = new Point(130, 70);
            textBoxPasswort.Name = "textBoxPasswort";
            textBoxPasswort.PasswordChar = '*';
            textBoxPasswort.Size = new Size(200, 23);
            textBoxPasswort.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(130, 110);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 23);
            textBoxEmail.TabIndex = 5;
            // 
            // comboBoxRolle
            // 
            comboBoxRolle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRolle.Location = new Point(130, 150);
            comboBoxRolle.Name = "comboBoxRolle";
            comboBoxRolle.Size = new Size(200, 23);
            comboBoxRolle.TabIndex = 7;
            // 
            // buttonRegistrieren
            // 
            buttonRegistrieren.Location = new Point(130, 190);
            buttonRegistrieren.Name = "buttonRegistrieren";
            buttonRegistrieren.Size = new Size(200, 48);
            buttonRegistrieren.TabIndex = 8;
            buttonRegistrieren.Text = "Registrieren";
            buttonRegistrieren.Click += buttonRegistrieren_Click;
            // 
            // label1
            // 
            label1.Location = new Point(20, 33);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Benutzername:";
            // 
            // label2
            // 
            label2.Location = new Point(20, 73);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Passwort:";
            // 
            // label3
            // 
            label3.Location = new Point(20, 113);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "E-Mail:";
            // 
            // label4
            // 
            label4.Location = new Point(20, 153);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 6;
            label4.Text = "Rolle:";
            // 
            // RegistrierenForm
            // 
            ClientSize = new Size(370, 250);
            Controls.Add(label1);
            Controls.Add(textBoxBenutzername);
            Controls.Add(label2);
            Controls.Add(textBoxPasswort);
            Controls.Add(label3);
            Controls.Add(textBoxEmail);
            Controls.Add(label4);
            Controls.Add(comboBoxRolle);
            Controls.Add(buttonRegistrieren);
            Name = "RegistrierenForm";
            Text = "Benutzer registrieren";
            Load += RegistrierenForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
