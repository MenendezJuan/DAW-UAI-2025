namespace UI.Points
{
    partial class FrmTransferPoints
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
            label1 = new Label();
            label2 = new Label();
            cmbCollaborator = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            LblPoints = new Label();
            label3 = new Label();
            btnTransfer = new Button();
            btnExport = new Button();
            DgvHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvHistory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 94);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 1;
            label1.Text = "Colaborador:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 94);
            label2.Name = "label2";
            label2.Size = new Size(160, 25);
            label2.TabIndex = 2;
            label2.Text = "Puntos a transferir:";
            // 
            // cmbCollaborator
            // 
            cmbCollaborator.FormattingEnabled = true;
            cmbCollaborator.Items.AddRange(new object[] { "Juan Perez" });
            cmbCollaborator.Location = new Point(175, 94);
            cmbCollaborator.Name = "cmbCollaborator";
            cmbCollaborator.Size = new Size(182, 33);
            cmbCollaborator.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(578, 92);
            numericUpDown1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(180, 31);
            numericUpDown1.TabIndex = 4;
            // 
            // LblPoints
            // 
            LblPoints.AutoSize = true;
            LblPoints.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            LblPoints.ForeColor = Color.ForestGreen;
            LblPoints.Location = new Point(1550, 95);
            LblPoints.Name = "LblPoints";
            LblPoints.Size = new Size(28, 32);
            LblPoints.TabIndex = 27;
            LblPoints.Tag = "VIEW_PRODUCTS";
            LblPoints.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(1383, 95);
            label3.Name = "label3";
            label3.Size = new Size(105, 32);
            label3.TabIndex = 26;
            label3.Tag = "POINTS";
            label3.Text = "Puntos:";
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = Color.ForestGreen;
            btnTransfer.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransfer.ForeColor = SystemColors.ButtonHighlight;
            btnTransfer.Location = new Point(789, 87);
            btnTransfer.Margin = new Padding(4, 5, 4, 5);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(309, 49);
            btnTransfer.TabIndex = 67;
            btnTransfer.Tag = "TRANSFER";
            btnTransfer.Text = "Transferir";
            btnTransfer.UseVisualStyleBackColor = false;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.ForestGreen;
            btnExport.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = SystemColors.ButtonHighlight;
            btnExport.Location = new Point(53, 966);
            btnExport.Margin = new Padding(4, 5, 4, 5);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(309, 49);
            btnExport.TabIndex = 69;
            btnExport.Tag = "EXPORT";
            btnExport.Text = "Exportar";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // DgvHistory
            // 
            DgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvHistory.Location = new Point(53, 163);
            DgvHistory.Name = "DgvHistory";
            DgvHistory.RowHeadersWidth = 62;
            DgvHistory.Size = new Size(1569, 780);
            DgvHistory.TabIndex = 68;
            // 
            // FrmTransferPoints
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1655, 1219);
            Controls.Add(btnExport);
            Controls.Add(DgvHistory);
            Controls.Add(btnTransfer);
            Controls.Add(LblPoints);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(cmbCollaborator);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmTransferPoints";
            Text = "FrmTransferPoints";
            FormClosed += FrmTransferPoints_FormClosed;
            Load += FrmTransferPoints_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private ComboBox cmbCollaborator;
        private NumericUpDown numericUpDown1;
        private Label LblPoints;
        private Label label3;
        private Button btnTransfer;
        private Button btnExport;
        private DataGridView DgvHistory;
    }
}