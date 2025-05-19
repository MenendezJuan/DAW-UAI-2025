namespace UI.Objectives
{
    partial class FrmEvaluateObjectives
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
            lblObjectives = new Label();
            dgvObjectives = new DataGridView();
            cmbNominee = new ComboBox();
            lblNominee = new Label();
            btnHold = new Button();
            btnAdjust = new Button();
            rtbComments = new RichTextBox();
            lblComments = new Label();
            btnAssign = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvObjectives).BeginInit();
            SuspendLayout();
            // 
            // lblObjectives
            // 
            lblObjectives.AutoSize = true;
            lblObjectives.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblObjectives.ForeColor = Color.ForestGreen;
            lblObjectives.Location = new Point(82, 122);
            lblObjectives.Name = "lblObjectives";
            lblObjectives.Size = new Size(268, 32);
            lblObjectives.TabIndex = 71;
            lblObjectives.Tag = "";
            lblObjectives.Text = "Objetivos pendientes:";
            // 
            // dgvObjectives
            // 
            dgvObjectives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvObjectives.Location = new Point(82, 169);
            dgvObjectives.Name = "dgvObjectives";
            dgvObjectives.RowHeadersWidth = 62;
            dgvObjectives.Size = new Size(1247, 225);
            dgvObjectives.TabIndex = 70;
            // 
            // cmbNominee
            // 
            cmbNominee.FormattingEnabled = true;
            cmbNominee.Location = new Point(445, 75);
            cmbNominee.Name = "cmbNominee";
            cmbNominee.Size = new Size(246, 33);
            cmbNominee.TabIndex = 69;
            cmbNominee.SelectedValueChanged += cmbNominee_SelectedValueChanged;
            // 
            // lblNominee
            // 
            lblNominee.AutoSize = true;
            lblNominee.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblNominee.ForeColor = Color.ForestGreen;
            lblNominee.Location = new Point(82, 75);
            lblNominee.Name = "lblNominee";
            lblNominee.Size = new Size(337, 32);
            lblNominee.TabIndex = 68;
            lblNominee.Tag = "";
            lblNominee.Text = "Seleccionar un colaborador:";
            // 
            // btnHold
            // 
            btnHold.BackColor = Color.ForestGreen;
            btnHold.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHold.ForeColor = SystemColors.ButtonHighlight;
            btnHold.Location = new Point(313, 754);
            btnHold.Margin = new Padding(4, 5, 4, 5);
            btnHold.Name = "btnHold";
            btnHold.Size = new Size(209, 49);
            btnHold.TabIndex = 67;
            btnHold.Tag = "";
            btnHold.Text = "En espera";
            btnHold.UseVisualStyleBackColor = false;
            btnHold.Click += btnHold_Click;
            // 
            // btnAdjust
            // 
            btnAdjust.BackColor = Color.ForestGreen;
            btnAdjust.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdjust.ForeColor = SystemColors.ButtonHighlight;
            btnAdjust.Location = new Point(82, 754);
            btnAdjust.Margin = new Padding(4, 5, 4, 5);
            btnAdjust.Name = "btnAdjust";
            btnAdjust.Size = new Size(223, 49);
            btnAdjust.TabIndex = 66;
            btnAdjust.Tag = "";
            btnAdjust.Text = "Ajustar";
            btnAdjust.UseVisualStyleBackColor = false;
            btnAdjust.Click += btnAdjust_Click;
            // 
            // rtbComments
            // 
            rtbComments.Location = new Point(82, 449);
            rtbComments.Name = "rtbComments";
            rtbComments.Size = new Size(1247, 297);
            rtbComments.TabIndex = 65;
            rtbComments.Text = "";
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblComments.ForeColor = Color.ForestGreen;
            lblComments.Location = new Point(82, 414);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(170, 32);
            lblComments.TabIndex = 64;
            lblComments.Tag = "";
            lblComments.Text = "Comentarios:";
            // 
            // btnAssign
            // 
            btnAssign.BackColor = Color.ForestGreen;
            btnAssign.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAssign.ForeColor = SystemColors.ButtonHighlight;
            btnAssign.Location = new Point(530, 754);
            btnAssign.Margin = new Padding(4, 5, 4, 5);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(209, 49);
            btnAssign.TabIndex = 72;
            btnAssign.Tag = "";
            btnAssign.Text = "Asignar";
            btnAssign.UseVisualStyleBackColor = false;
            btnAssign.Click += btnAssign_Click;
            // 
            // FrmEvaluateObjectives
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 946);
            Controls.Add(btnAssign);
            Controls.Add(lblObjectives);
            Controls.Add(dgvObjectives);
            Controls.Add(cmbNominee);
            Controls.Add(lblNominee);
            Controls.Add(btnHold);
            Controls.Add(btnAdjust);
            Controls.Add(rtbComments);
            Controls.Add(lblComments);
            Name = "FrmEvaluateObjectives";
            Text = "FrmEvaluateObjectives";
            FormClosed += FrmEvaluateObjectives_FormClosed;
            Load += FrmEvaluateObjectives_Load;
            ((System.ComponentModel.ISupportInitialize)dgvObjectives).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblObjectives;
        private DataGridView dgvObjectives;
        private ComboBox cmbNominee;
        private Label lblNominee;
        private Button btnHold;
        private Button btnAdjust;
        private RichTextBox rtbComments;
        private Label lblComments;
        private Button btnAssign;
    }
}