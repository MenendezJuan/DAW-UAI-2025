namespace UI.Points
{
    partial class FrmExchangeBenefits
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
            BtnAddProduct = new Button();
            DgvProducts = new DataGridView();
            LblPoints = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            SuspendLayout();
            // 
            // BtnAddProduct
            // 
            BtnAddProduct.BackColor = Color.ForestGreen;
            BtnAddProduct.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddProduct.ForeColor = SystemColors.ButtonHighlight;
            BtnAddProduct.Location = new Point(33, 764);
            BtnAddProduct.Margin = new Padding(4, 5, 4, 5);
            BtnAddProduct.Name = "BtnAddProduct";
            BtnAddProduct.Size = new Size(209, 49);
            BtnAddProduct.TabIndex = 56;
            BtnAddProduct.Tag = "EXCHANGE";
            BtnAddProduct.Text = "Canjear";
            BtnAddProduct.UseVisualStyleBackColor = false;
            BtnAddProduct.Click += BtnAddProduct_Click;
            // 
            // DgvProducts
            // 
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProducts.Location = new Point(33, 170);
            DgvProducts.Name = "DgvProducts";
            DgvProducts.RowHeadersWidth = 62;
            DgvProducts.Size = new Size(1569, 586);
            DgvProducts.TabIndex = 55;
            // 
            // LblPoints
            // 
            LblPoints.AutoSize = true;
            LblPoints.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            LblPoints.ForeColor = Color.ForestGreen;
            LblPoints.Location = new Point(1532, 35);
            LblPoints.Name = "LblPoints";
            LblPoints.Size = new Size(28, 32);
            LblPoints.TabIndex = 54;
            LblPoints.Tag = "VIEW_PRODUCTS";
            LblPoints.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(1365, 35);
            label2.Name = "label2";
            label2.Size = new Size(105, 32);
            label2.TabIndex = 53;
            label2.Tag = "POINTS";
            label2.Text = "Puntos:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(33, 35);
            label1.Name = "label1";
            label1.Size = new Size(234, 32);
            label1.TabIndex = 50;
            label1.Tag = "BENEFITS_EXCHANGE";
            label1.Text = "Canjear beneficios:";
            // 
            // FrmExchangeBenefits
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1658, 864);
            Controls.Add(BtnAddProduct);
            Controls.Add(DgvProducts);
            Controls.Add(LblPoints);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmExchangeBenefits";
            Text = "FrmExchangeBenefits";
            FormClosed += FrmExchangeBenefits_FormClosed_1;
            Load += FrmExchangeBenefits_Load;
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAddProduct;
        private DataGridView DgvProducts;
        private Label LblPoints;
        private Label label2;
        private Label label1;
    }
}