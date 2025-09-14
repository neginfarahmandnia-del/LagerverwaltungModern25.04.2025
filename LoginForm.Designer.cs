namespace LagerverwaltungModern25._04._2025
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelBenutzername;
        private System.Windows.Forms.Label labelPasswort;
        private System.Windows.Forms.TextBox textBoxBenutzername;
        private System.Windows.Forms.TextBox textBoxPasswort;
        private System.Windows.Forms.Button buttonLogin;

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
            labelBenutzername = new Label();
            labelPasswort = new Label();
            textBoxBenutzername = new TextBox();
            textBoxPasswort = new TextBox();
            buttonLogin = new Button();
            btnRegistrieren = new Button();
            SuspendLayout();
            // 
            // labelBenutzername
            // 
            labelBenutzername.AutoSize = true;
            labelBenutzername.Location = new Point(30, 30);
            labelBenutzername.Name = "labelBenutzername";
            labelBenutzername.Size = new Size(86, 15);
            labelBenutzername.TabIndex = 0;
            labelBenutzername.Text = "Benutzername:";
            // 
            // labelPasswort
            // 
            labelPasswort.AutoSize = true;
            labelPasswort.Location = new Point(30, 80);
            labelPasswort.Name = "labelPasswort";
            labelPasswort.Size = new Size(57, 15);
            labelPasswort.TabIndex = 1;
            labelPasswort.Text = "Passwort:";
            // 
            // textBoxBenutzername
            // 
            textBoxBenutzername.Location = new Point(140, 27);
            textBoxBenutzername.Name = "textBoxBenutzername";
            textBoxBenutzername.Size = new Size(200, 23);
            textBoxBenutzername.TabIndex = 2;
            // 
            // textBoxPasswort
            // 
            textBoxPasswort.Location = new Point(140, 77);
            textBoxPasswort.Name = "textBoxPasswort";
            textBoxPasswort.PasswordChar = '*';
            textBoxPasswort.Size = new Size(200, 23);
            textBoxPasswort.TabIndex = 3;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(121, 136);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(100, 35);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Anmelden";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += btnAnmelden_Click;
            // 
            // btnRegistrieren
            // 
            btnRegistrieren.Location = new Point(227, 136);
            btnRegistrieren.Name = "btnRegistrieren";
            btnRegistrieren.Size = new Size(100, 35);
            btnRegistrieren.TabIndex = 5;
            btnRegistrieren.Text = "Registieren";
            btnRegistrieren.UseVisualStyleBackColor = true;
            btnRegistrieren.Click += BtnRegistrieren_Click;
            // 
            // LoginForm
            // 
            AcceptButton = buttonLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(btnRegistrieren);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPasswort);
            Controls.Add(textBoxBenutzername);
            Controls.Add(labelPasswort);
            Controls.Add(labelBenutzername);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        internal Button btnRegistrieren;
    }
}
