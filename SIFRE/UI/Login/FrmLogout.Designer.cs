namespace UI.Login
{
    partial class FrmLogout
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
            BtnAceptar = new Button();
            BtnCancelar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // BtnAceptar
            // 
            BtnAceptar.BackColor = Color.ForestGreen;
            BtnAceptar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAceptar.ForeColor = SystemColors.ButtonHighlight;
            BtnAceptar.Location = new Point(60, 86);
            BtnAceptar.Margin = new Padding(4, 5, 4, 5);
            BtnAceptar.Name = "BtnAceptar";
            BtnAceptar.Size = new Size(154, 49);
            BtnAceptar.TabIndex = 1;
            BtnAceptar.Tag = "ACCEPT";
            BtnAceptar.Text = "Aceptar";
            BtnAceptar.UseVisualStyleBackColor = false;
            BtnAceptar.Click += BtnAceptar_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.ForestGreen;
            BtnCancelar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnCancelar.ForeColor = SystemColors.ButtonHighlight;
            BtnCancelar.Location = new Point(222, 86);
            BtnCancelar.Margin = new Padding(4, 5, 4, 5);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(154, 49);
            BtnCancelar.TabIndex = 2;
            BtnCancelar.Tag = "CANCEL";
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(44, 26);
            label1.Name = "label1";
            label1.Size = new Size(348, 36);
            label1.TabIndex = 3;
            label1.Tag = "CONFIRM_LOGOUT";
            label1.Text = "¿Está seguro que desea salir?";
            // 
            // FrmLogout
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(434, 161);
            Controls.Add(label1);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnAceptar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmLogout";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "MENU_LOGOUT";
            Text = "Cerrar sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAceptar;
        private Button BtnCancelar;
        private Label label1;
    }
}