namespace UI.Objectives
{
    partial class FrmCheckObjectives
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
            dgvObjectives = new DataGridView();
            lblComment = new Label();
            dgvObjectiveComment = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvObjectives).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvObjectiveComment).BeginInit();
            SuspendLayout();
            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;
            lblHistory.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblHistory.ForeColor = Color.ForestGreen;
            lblHistory.Location = new Point(77, 81);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(250, 32);
            lblHistory.TabIndex = 63;
            lblHistory.Tag = "";
            lblHistory.Text = "Estado de objetivos:";
            // 
            // dgvObjectives
            // 
            dgvObjectives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvObjectives.Location = new Point(77, 128);
            dgvObjectives.Name = "dgvObjectives";
            dgvObjectives.RowHeadersWidth = 62;
            dgvObjectives.Size = new Size(1247, 225);
            dgvObjectives.TabIndex = 62;
            dgvObjectives.SelectionChanged += dgvObjectives_SelectionChanged;
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblComment.ForeColor = Color.ForestGreen;
            lblComment.Location = new Point(77, 356);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(170, 32);
            lblComment.TabIndex = 61;
            lblComment.Tag = "";
            lblComment.Text = "Comentarios:";
            // 
            // dgvObjectiveComment
            // 
            dgvObjectiveComment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvObjectiveComment.Location = new Point(77, 403);
            dgvObjectiveComment.Name = "dgvObjectiveComment";
            dgvObjectiveComment.RowHeadersWidth = 62;
            dgvObjectiveComment.Size = new Size(1247, 225);
            dgvObjectiveComment.TabIndex = 60;
            // 
            // FrmCheckObjectives
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 843);
            Controls.Add(lblHistory);
            Controls.Add(dgvObjectives);
            Controls.Add(lblComment);
            Controls.Add(dgvObjectiveComment);
            Name = "FrmCheckObjectives";
            Text = "FrmCheckObjectives";
            FormClosed += FrmCheckObjectives_FormClosed;
            Load += FrmCheckObjectives_Load;
            ((System.ComponentModel.ISupportInitialize)dgvObjectives).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvObjectiveComment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHistory;
        private DataGridView dgvObjectives;
        private Label lblComment;
        private DataGridView dgvObjectiveComment;
    }
}