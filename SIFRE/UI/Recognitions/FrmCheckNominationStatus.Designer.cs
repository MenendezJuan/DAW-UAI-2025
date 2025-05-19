namespace UI.Recognitions
{
    partial class FrmCheckNominationStatus
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
            lblHistory = new Label();
            dgvNominates = new DataGridView();
            lblNominationComment = new Label();
            dgvNominationComment = new DataGridView();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNominates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNominationComment).BeginInit();
            SuspendLayout();
            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;
            lblHistory.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblHistory.ForeColor = Color.ForestGreen;
            lblHistory.Location = new Point(94, 75);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(304, 32);
            lblHistory.TabIndex = 59;
            lblHistory.Tag = "";
            lblHistory.Text = "Estado de nominaciones:";
            // 
            // dgvNominates
            // 
            dgvNominates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNominates.Location = new Point(94, 122);
            dgvNominates.Name = "dgvNominates";
            dgvNominates.RowHeadersWidth = 62;
            dgvNominates.Size = new Size(1247, 225);
            dgvNominates.TabIndex = 58;
            // 
            // lblNominationComment
            // 
            lblNominationComment.AutoSize = true;
            lblNominationComment.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblNominationComment.ForeColor = Color.ForestGreen;
            lblNominationComment.Location = new Point(94, 350);
            lblNominationComment.Name = "lblNominationComment";
            lblNominationComment.Size = new Size(482, 32);
            lblNominationComment.TabIndex = 57;
            lblNominationComment.Tag = "";
            lblNominationComment.Text = "Comentarios asociados a la nominación:";
            // 
            // dgvNominationComment
            // 
            dgvNominationComment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNominationComment.Location = new Point(94, 397);
            dgvNominationComment.Name = "dgvNominationComment";
            dgvNominationComment.RowHeadersWidth = 62;
            dgvNominationComment.Size = new Size(1247, 225);
            dgvNominationComment.TabIndex = 56;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.ForestGreen;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(94, 644);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(262, 49);
            btnCancel.TabIndex = 60;
            btnCancel.Tag = "";
            btnCancel.Text = "Cancelar nominación";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmCheckNominationStatus
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 1131);
            Controls.Add(btnCancel);
            Controls.Add(lblHistory);
            Controls.Add(dgvNominates);
            Controls.Add(lblNominationComment);
            Controls.Add(dgvNominationComment);
            Name = "FrmCheckNominationStatus";
            Text = "FrmCheckNominationStatus";
            FormClosed += FrmCheckNominationStatus_FormClosed;
            Load += FrmCheckNominationStatus_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNominates).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNominationComment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHistory;
        private DataGridView dgvNominates;
        private Label lblNominationComment;
        private DataGridView dgvNominationComment;
        private Button btnCancel;
    }
}