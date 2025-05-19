namespace UI.Security
{
    partial class FrmInconsistencyManagement
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
            BtnRestore = new Button();
            BtnRecalculate = new Button();
            label1 = new Label();
            lblErrorDetailTableName = new Label();
            lblErrorDetailTableRow = new Label();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // BtnRestore
            // 
            BtnRestore.BackColor = Color.ForestGreen;
            BtnRestore.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnRestore.ForeColor = SystemColors.ButtonHighlight;
            BtnRestore.Location = new Point(343, 215);
            BtnRestore.Margin = new Padding(4, 5, 4, 5);
            BtnRestore.Name = "BtnRestore";
            BtnRestore.Size = new Size(309, 49);
            BtnRestore.TabIndex = 27;
            BtnRestore.Tag = "RESTORE_BACKUP";
            BtnRestore.Text = "Restaurar";
            BtnRestore.UseVisualStyleBackColor = false;
            BtnRestore.Click += BtnRestore_Click;
            // 
            // BtnRecalculate
            // 
            BtnRecalculate.BackColor = Color.ForestGreen;
            BtnRecalculate.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnRecalculate.ForeColor = SystemColors.ButtonHighlight;
            BtnRecalculate.Location = new Point(12, 215);
            BtnRecalculate.Margin = new Padding(4, 5, 4, 5);
            BtnRecalculate.Name = "BtnRecalculate";
            BtnRecalculate.Size = new Size(309, 49);
            BtnRecalculate.TabIndex = 26;
            BtnRecalculate.Tag = "RECALCULATE";
            BtnRecalculate.Text = "Recalcular";
            BtnRecalculate.UseVisualStyleBackColor = false;
            BtnRecalculate.Click += BtnRecalculate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(402, 32);
            label1.TabIndex = 25;
            label1.Tag = "MANAGE_INCONSISTENCY";
            label1.Text = "Inconsistencias de base de datos:";
            // 
            // lblErrorDetailTableName
            // 
            lblErrorDetailTableName.AutoSize = true;
            lblErrorDetailTableName.Font = new Font("Segoe UI", 13F);
            lblErrorDetailTableName.ForeColor = Color.ForestGreen;
            lblErrorDetailTableName.Location = new Point(12, 93);
            lblErrorDetailTableName.Name = "lblErrorDetailTableName";
            lblErrorDetailTableName.Size = new Size(459, 36);
            lblErrorDetailTableName.TabIndex = 28;
            lblErrorDetailTableName.Tag = "ERROR_DETAIL_TABLE";
            lblErrorDetailTableName.Text = "[Tabla: <TableName> RegistroId: <Id>]";
            // 
            // lblErrorDetailTableRow
            // 
            lblErrorDetailTableRow.AutoSize = true;
            lblErrorDetailTableRow.Font = new Font("Segoe UI", 13F);
            lblErrorDetailTableRow.ForeColor = Color.ForestGreen;
            lblErrorDetailTableRow.Location = new Point(12, 144);
            lblErrorDetailTableRow.Name = "lblErrorDetailTableRow";
            lblErrorDetailTableRow.Size = new Size(459, 36);
            lblErrorDetailTableRow.TabIndex = 29;
            lblErrorDetailTableRow.Tag = "ERROR_DETAIL_TABLE_ROW";
            lblErrorDetailTableRow.Text = "[Tabla: <TableName> RegistroId: <Id>]";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmInconsistencyManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(768, 288);
            Controls.Add(lblErrorDetailTableRow);
            Controls.Add(lblErrorDetailTableName);
            Controls.Add(BtnRestore);
            Controls.Add(BtnRecalculate);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInconsistencyManagement";
            Text = "Manejo de inconsistencias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnRestore;
        private Button BtnRecalculate;
        private Label label1;
        private Label lblErrorDetailTableName;
        private Label lblErrorDetailTableRow;
        private OpenFileDialog openFileDialog1;
    }
}