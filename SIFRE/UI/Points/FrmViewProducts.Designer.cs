namespace UI.Points
{
    partial class FrmViewProducts
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
            DgvProducts = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            SuspendLayout();
            // 
            // DgvProducts
            // 
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProducts.Location = new Point(56, 132);
            DgvProducts.Name = "DgvProducts";
            DgvProducts.RowHeadersWidth = 62;
            DgvProducts.Size = new Size(1569, 780);
            DgvProducts.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(56, 75);
            label1.Name = "label1";
            label1.Size = new Size(282, 32);
            label1.TabIndex = 21;
            label1.Tag = "AVAILABLE_PRODUCTS";
            label1.Text = "Productos disponibles:";
            // 
            // FrmViewProducts
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1701, 947);
            Controls.Add(label1);
            Controls.Add(DgvProducts);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmViewProducts";
            Text = "FrmViewProducts";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmViewProducts_FormClosed;
            Load += FrmViewProducts_Load;
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvProducts;
        private Label label1;
    }
}