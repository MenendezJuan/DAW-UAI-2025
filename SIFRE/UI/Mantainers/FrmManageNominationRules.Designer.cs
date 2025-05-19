namespace UI.Mantainers
{
    partial class FrmManageNominationRules
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
            dgvRules = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRules).BeginInit();
            SuspendLayout();
            // 
            // dgvRules
            // 
            dgvRules.AllowUserToAddRows = false;
            dgvRules.AllowUserToDeleteRows = false;
            dgvRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRules.Location = new Point(73, 126);
            dgvRules.MultiSelect = false;
            dgvRules.Name = "dgvRules";
            dgvRules.RowHeadersWidth = 62;
            dgvRules.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvRules.Size = new Size(1395, 267);
            dgvRules.TabIndex = 1;
            // 
            // FrmManageNominationRules
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1539, 875);
            Controls.Add(dgvRules);
            Name = "FrmManageNominationRules";
            Text = "FrmManageNominationRules";
            FormClosed += FrmManageNominationRules_FormClosed;
            Load += FrmManageNominationRules_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRules).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRules;
    }
}