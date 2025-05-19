namespace UI.Points
{
    partial class FrmExchangePoints
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
            CmbCategories = new ComboBox();
            label5 = new Label();
            LblPoints = new Label();
            label2 = new Label();
            DgvProducts = new DataGridView();
            BtnAddProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(71, 66);
            label1.Name = "label1";
            label1.Size = new Size(197, 32);
            label1.TabIndex = 24;
            label1.Tag = "POINTS_EXCHANGE";
            label1.Text = "Canjear puntos:";
            // 
            // CmbCategories
            // 
            CmbCategories.DisplayMember = "Description";
            CmbCategories.FormattingEnabled = true;
            CmbCategories.Location = new Point(71, 149);
            CmbCategories.Name = "CmbCategories";
            CmbCategories.Size = new Size(1569, 33);
            CmbCategories.TabIndex = 45;
            CmbCategories.ValueMember = "Id";
            CmbCategories.SelectedValueChanged += CmbCategories_SelectedValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label5.ForeColor = Color.ForestGreen;
            label5.Location = new Point(71, 118);
            label5.Name = "label5";
            label5.Size = new Size(113, 28);
            label5.TabIndex = 44;
            label5.Tag = "CATEGORY";
            label5.Text = "Categoria:";
            // 
            // LblPoints
            // 
            LblPoints.AutoSize = true;
            LblPoints.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            LblPoints.ForeColor = Color.ForestGreen;
            LblPoints.Location = new Point(1570, 66);
            LblPoints.Name = "LblPoints";
            LblPoints.Size = new Size(28, 32);
            LblPoints.TabIndex = 47;
            LblPoints.Tag = "VIEW_PRODUCTS";
            LblPoints.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(1403, 66);
            label2.Name = "label2";
            label2.Size = new Size(105, 32);
            label2.TabIndex = 46;
            label2.Tag = "POINTS";
            label2.Text = "Puntos:";
            // 
            // DgvProducts
            // 
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProducts.Location = new Point(71, 201);
            DgvProducts.Name = "DgvProducts";
            DgvProducts.RowHeadersWidth = 62;
            DgvProducts.Size = new Size(1569, 586);
            DgvProducts.TabIndex = 48;
            // 
            // BtnAddProduct
            // 
            BtnAddProduct.BackColor = Color.ForestGreen;
            BtnAddProduct.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddProduct.ForeColor = SystemColors.ButtonHighlight;
            BtnAddProduct.Location = new Point(71, 795);
            BtnAddProduct.Margin = new Padding(4, 5, 4, 5);
            BtnAddProduct.Name = "BtnAddProduct";
            BtnAddProduct.Size = new Size(209, 49);
            BtnAddProduct.TabIndex = 49;
            BtnAddProduct.Tag = "EXCHANGE";
            BtnAddProduct.Text = "Canjear";
            BtnAddProduct.UseVisualStyleBackColor = false;
            BtnAddProduct.Click += BtnAddProduct_Click;
            // 
            // FrmExchangePoints
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1703, 891);
            Controls.Add(BtnAddProduct);
            Controls.Add(DgvProducts);
            Controls.Add(LblPoints);
            Controls.Add(label2);
            Controls.Add(CmbCategories);
            Controls.Add(label5);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmExchangePoints";
            Text = "FrmExchangePoints";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmExchangePoints_FormClosed;
            Load += FrmExchangePoints_Load;
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox CmbCategories;
        private Label label5;
        private Label LblPoints;
        private Label label2;
        private DataGridView DgvProducts;
        private Button BtnAddProduct;
    }
}