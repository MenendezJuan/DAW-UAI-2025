namespace UI
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            BtnLogin = new Button();
            TxtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TxtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            LblError = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.ForestGreen;
            BtnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnLogin.ForeColor = SystemColors.ButtonHighlight;
            BtnLogin.Location = new Point(16, 469);
            BtnLogin.Margin = new Padding(4, 5, 4, 5);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(347, 70);
            BtnLogin.TabIndex = 0;
            BtnLogin.Text = "Iniciar sesión";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.BorderStyle = BorderStyle.FixedSingle;
            TxtUsername.Location = new Point(17, 280);
            TxtUsername.Margin = new Padding(4, 5, 4, 5);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(346, 31);
            TxtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(17, 250);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 2;
            label1.Text = "Nombre de usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(17, 337);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // TxtPassword
            // 
            TxtPassword.BorderStyle = BorderStyle.FixedSingle;
            TxtPassword.Location = new Point(17, 367);
            TxtPassword.Margin = new Padding(4, 5, 4, 5);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(346, 31);
            TxtPassword.TabIndex = 3;
            TxtPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(135, 73);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 172);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // LblError
            // 
            LblError.AutoSize = true;
            LblError.BackColor = Color.Transparent;
            LblError.ForeColor = Color.Firebrick;
            LblError.Location = new Point(17, 412);
            LblError.Name = "LblError";
            LblError.Size = new Size(281, 25);
            LblError.TabIndex = 9;
            LblError.Text = "Usuario y/o contraseña incorrecta.";
            LblError.TextAlign = ContentAlignment.MiddleLeft;
            LblError.Visible = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(377, 602);
            Controls.Add(LblError);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(TxtPassword);
            Controls.Add(label1);
            Controls.Add(TxtUsername);
            Controls.Add(BtnLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesión";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnLogin;
        private TextBox TxtUsername;
        private Label label1;
        private Label label2;
        private TextBox TxtPassword;
        private PictureBox pictureBox1;
        private Label LblError;
    }
}