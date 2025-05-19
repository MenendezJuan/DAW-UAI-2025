namespace UI.Recognitions
{
    partial class FrmReviewPendingNominations
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
            btnRejectNomination = new Button();
            btnAcceptNomination = new Button();
            rtbComments = new RichTextBox();
            lblComments = new Label();
            cmbNominee = new ComboBox();
            lblNominee = new Label();
            lblHistory = new Label();
            dgvNominates = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNominates).BeginInit();
            SuspendLayout();
            // 
            // btnRejectNomination
            // 
            btnRejectNomination.BackColor = Color.ForestGreen;
            btnRejectNomination.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRejectNomination.ForeColor = SystemColors.ButtonHighlight;
            btnRejectNomination.Location = new Point(308, 738);
            btnRejectNomination.Margin = new Padding(4, 5, 4, 5);
            btnRejectNomination.Name = "btnRejectNomination";
            btnRejectNomination.Size = new Size(209, 49);
            btnRejectNomination.TabIndex = 59;
            btnRejectNomination.Tag = "";
            btnRejectNomination.Text = "Rechazar";
            btnRejectNomination.UseVisualStyleBackColor = false;
            btnRejectNomination.Click += btnRejectNomination_Click;
            // 
            // btnAcceptNomination
            // 
            btnAcceptNomination.BackColor = Color.ForestGreen;
            btnAcceptNomination.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAcceptNomination.ForeColor = SystemColors.ButtonHighlight;
            btnAcceptNomination.Location = new Point(77, 738);
            btnAcceptNomination.Margin = new Padding(4, 5, 4, 5);
            btnAcceptNomination.Name = "btnAcceptNomination";
            btnAcceptNomination.Size = new Size(223, 49);
            btnAcceptNomination.TabIndex = 58;
            btnAcceptNomination.Tag = "";
            btnAcceptNomination.Text = "Aprobar";
            btnAcceptNomination.UseVisualStyleBackColor = false;
            btnAcceptNomination.Click += btnAcceptNomination_Click;
            // 
            // rtbComments
            // 
            rtbComments.Location = new Point(77, 433);
            rtbComments.Name = "rtbComments";
            rtbComments.Size = new Size(1247, 297);
            rtbComments.TabIndex = 57;
            rtbComments.Text = "";
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblComments.ForeColor = Color.ForestGreen;
            lblComments.Location = new Point(77, 398);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(170, 32);
            lblComments.TabIndex = 56;
            lblComments.Tag = "";
            lblComments.Text = "Comentarios:";
            // 
            // cmbNominee
            // 
            cmbNominee.FormattingEnabled = true;
            cmbNominee.Location = new Point(440, 59);
            cmbNominee.Name = "cmbNominee";
            cmbNominee.Size = new Size(246, 33);
            cmbNominee.TabIndex = 61;
            cmbNominee.SelectedValueChanged += cmbNominee_SelectedValueChanged;
            // 
            // lblNominee
            // 
            lblNominee.AutoSize = true;
            lblNominee.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblNominee.ForeColor = Color.ForestGreen;
            lblNominee.Location = new Point(77, 59);
            lblNominee.Name = "lblNominee";
            lblNominee.Size = new Size(337, 32);
            lblNominee.TabIndex = 60;
            lblNominee.Tag = "";
            lblNominee.Text = "Seleccionar un colaborador:";
            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;
            lblHistory.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblHistory.ForeColor = Color.ForestGreen;
            lblHistory.Location = new Point(77, 106);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(323, 32);
            lblHistory.TabIndex = 63;
            lblHistory.Tag = "";
            lblHistory.Text = "Nominaciones pendientes:";
            // 
            // dgvNominates
            // 
            dgvNominates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNominates.Location = new Point(77, 153);
            dgvNominates.Name = "dgvNominates";
            dgvNominates.RowHeadersWidth = 62;
            dgvNominates.Size = new Size(1247, 225);
            dgvNominates.TabIndex = 62;
            // 
            // FrmReviewPendingNominations
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1610, 1054);
            Controls.Add(lblHistory);
            Controls.Add(dgvNominates);
            Controls.Add(cmbNominee);
            Controls.Add(lblNominee);
            Controls.Add(btnRejectNomination);
            Controls.Add(btnAcceptNomination);
            Controls.Add(rtbComments);
            Controls.Add(lblComments);
            Name = "FrmReviewPendingNominations";
            Text = "FrmReviewPendingNominations";
            FormClosed += FrmReviewPendingNominations_FormClosed;
            Load += FrmReviewPendingNominations_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNominates).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRejectNomination;
        private Button btnAcceptNomination;
        private RichTextBox rtbComments;
        private Label lblComments;
        private ComboBox cmbNominee;
        private Label lblNominee;
        private Label lblHistory;
        private DataGridView dgvNominates;
    }
}