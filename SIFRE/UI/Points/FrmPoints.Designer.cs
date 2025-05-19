namespace UI.Points
{
    partial class FrmPoints
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
            DgvHistory = new DataGridView();
            label2 = new Label();
            LblPoints = new Label();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvHistory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(57, 78);
            label1.Name = "label1";
            label1.Size = new Size(246, 32);
            label1.TabIndex = 23;
            label1.Tag = "POINTS_HISTORY";
            label1.Text = "Historial de puntos:";
            // 
            // DgvHistory
            // 
            DgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvHistory.Location = new Point(57, 135);
            DgvHistory.Name = "DgvHistory";
            DgvHistory.RowHeadersWidth = 62;
            DgvHistory.Size = new Size(1569, 780);
            DgvHistory.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(1200, 78);
            label2.Name = "label2";
            label2.Size = new Size(105, 32);
            label2.TabIndex = 24;
            label2.Tag = "POINTS";
            label2.Text = "Puntos:";
            // 
            // LblPoints
            // 
            LblPoints.AutoSize = true;
            LblPoints.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            LblPoints.ForeColor = Color.ForestGreen;
            LblPoints.Location = new Point(1367, 78);
            LblPoints.Name = "LblPoints";
            LblPoints.Size = new Size(28, 32);
            LblPoints.TabIndex = 25;
            LblPoints.Tag = "VIEW_PRODUCTS";
            LblPoints.Text = "0";
            LblPoints.Click += label3_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.ForestGreen;
            btnExport.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = SystemColors.ButtonHighlight;
            btnExport.Location = new Point(57, 938);
            btnExport.Margin = new Padding(4, 5, 4, 5);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(309, 49);
            btnExport.TabIndex = 66;
            btnExport.Tag = "EXPORT";
            btnExport.Text = "Exportar";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // FrmPoints
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1693, 1031);
            Controls.Add(btnExport);
            Controls.Add(LblPoints);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DgvHistory);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPoints";
            Text = "FrmPoints";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmPoints_FormClosed;
            Load += FrmPoints_Load;
            ((System.ComponentModel.ISupportInitialize)DgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView DgvHistory;
        private Label label2;
        private Label LblPoints;
        private Button btnExport;
    }
}