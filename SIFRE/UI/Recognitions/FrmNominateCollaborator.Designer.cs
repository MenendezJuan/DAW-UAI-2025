namespace UI.Recognitions
{
    partial class FrmNominateCollaborator
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
            lblNominee = new Label();
            cmbNominee = new ComboBox();
            cmbCategory = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            rtbComments = new RichTextBox();
            btnClearControls = new Button();
            btnAddNominee = new Button();
            SuspendLayout();
            // 
            // lblNominee
            // 
            lblNominee.AutoSize = true;
            lblNominee.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblNominee.ForeColor = Color.ForestGreen;
            lblNominee.Location = new Point(22, 84);
            lblNominee.Name = "lblNominee";
            lblNominee.Size = new Size(337, 32);
            lblNominee.TabIndex = 24;
            lblNominee.Tag = "";
            lblNominee.Text = "Seleccionar un colaborador:";
            // 
            // cmbNominee
            // 
            cmbNominee.FormattingEnabled = true;
            cmbNominee.Location = new Point(385, 84);
            cmbNominee.Name = "cmbNominee";
            cmbNominee.Size = new Size(246, 33);
            cmbNominee.TabIndex = 25;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(385, 139);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(246, 33);
            cmbCategory.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(22, 136);
            label1.Name = "label1";
            label1.Size = new Size(357, 32);
            label1.TabIndex = 26;
            label1.Tag = "";
            label1.Text = "Categoría de reconocimiento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(22, 191);
            label2.Name = "label2";
            label2.Size = new Size(170, 32);
            label2.TabIndex = 28;
            label2.Tag = "";
            label2.Text = "Comentarios:";
            // 
            // rtbComments
            // 
            rtbComments.Location = new Point(22, 226);
            rtbComments.Name = "rtbComments";
            rtbComments.Size = new Size(1247, 297);
            rtbComments.TabIndex = 29;
            rtbComments.Text = "";
            // 
            // btnClearControls
            // 
            btnClearControls.BackColor = Color.ForestGreen;
            btnClearControls.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearControls.ForeColor = SystemColors.ButtonHighlight;
            btnClearControls.Location = new Point(253, 531);
            btnClearControls.Margin = new Padding(4, 5, 4, 5);
            btnClearControls.Name = "btnClearControls";
            btnClearControls.Size = new Size(209, 49);
            btnClearControls.TabIndex = 43;
            btnClearControls.Tag = "";
            btnClearControls.Text = "Limpiar";
            btnClearControls.UseVisualStyleBackColor = false;
            btnClearControls.Click += btnClearControls_Click;
            // 
            // btnAddNominee
            // 
            btnAddNominee.BackColor = Color.ForestGreen;
            btnAddNominee.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNominee.ForeColor = SystemColors.ButtonHighlight;
            btnAddNominee.Location = new Point(22, 531);
            btnAddNominee.Margin = new Padding(4, 5, 4, 5);
            btnAddNominee.Name = "btnAddNominee";
            btnAddNominee.Size = new Size(223, 49);
            btnAddNominee.TabIndex = 42;
            btnAddNominee.Tag = "";
            btnAddNominee.Text = "Enviar nominación";
            btnAddNominee.UseVisualStyleBackColor = false;
            btnAddNominee.Click += btnAddNominee_Click;
            // 
            // FrmNominateCollaborator
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1800, 1466);
            Controls.Add(btnClearControls);
            Controls.Add(btnAddNominee);
            Controls.Add(rtbComments);
            Controls.Add(label2);
            Controls.Add(cmbCategory);
            Controls.Add(label1);
            Controls.Add(cmbNominee);
            Controls.Add(lblNominee);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmNominateCollaborator";
            Text = "Nominar a un colaborador";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmNominateCollaborator_FormClosed;
            Load += FrmNominateCollaborator_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNominee;
        private ComboBox cmbNominee;
        private ComboBox cmbCategory;
        private Label label1;
        private Label label2;
        private RichTextBox rtbComments;
        private Button btnClearControls;
        private Button btnAddNominee;
    }
}