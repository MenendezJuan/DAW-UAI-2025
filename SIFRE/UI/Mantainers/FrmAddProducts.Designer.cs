namespace UI.Mantainers
{
    partial class FrmAddProducts
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
            label2 = new Label();
            TxtName = new TextBox();
            label3 = new Label();
            TxtDescription = new TextBox();
            label4 = new Label();
            TxtPoints = new TextBox();
            BtnDeleteProduct = new Button();
            BtnAddProduct = new Button();
            CmbCategories = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            SuspendLayout();
            // 
            // DgvProducts
            // 
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProducts.Location = new Point(53, 293);
            DgvProducts.Name = "DgvProducts";
            DgvProducts.RowHeadersWidth = 62;
            DgvProducts.Size = new Size(1569, 586);
            DgvProducts.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(53, 91);
            label1.Name = "label1";
            label1.Size = new Size(232, 28);
            label1.TabIndex = 20;
            label1.Tag = "MANAGE_PRODUCT_TITLE";
            label1.Text = "Gestión de productos:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(53, 156);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 35;
            label2.Tag = "NAME";
            label2.Text = "Nombre:";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(53, 187);
            TxtName.MaxLength = 100;
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(176, 31);
            TxtName.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(239, 156);
            label3.Name = "label3";
            label3.Size = new Size(134, 28);
            label3.TabIndex = 37;
            label3.Tag = "DESCRIPTION";
            label3.Text = "Descripción:";
            // 
            // TxtDescription
            // 
            TxtDescription.Location = new Point(239, 187);
            TxtDescription.MaxLength = 200;
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(191, 31);
            TxtDescription.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label4.ForeColor = Color.ForestGreen;
            label4.Location = new Point(442, 156);
            label4.Name = "label4";
            label4.Size = new Size(88, 28);
            label4.TabIndex = 39;
            label4.Tag = "POINTS";
            label4.Text = "Puntos:";
            // 
            // TxtPoints
            // 
            TxtPoints.Location = new Point(442, 187);
            TxtPoints.MaxLength = 10;
            TxtPoints.Name = "TxtPoints";
            TxtPoints.Size = new Size(191, 31);
            TxtPoints.TabIndex = 38;
            TxtPoints.KeyPress += TxtPoints_KeyPress;
            // 
            // BtnDeleteProduct
            // 
            BtnDeleteProduct.BackColor = Color.ForestGreen;
            BtnDeleteProduct.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDeleteProduct.ForeColor = SystemColors.ButtonHighlight;
            BtnDeleteProduct.Location = new Point(271, 236);
            BtnDeleteProduct.Margin = new Padding(4, 5, 4, 5);
            BtnDeleteProduct.Name = "BtnDeleteProduct";
            BtnDeleteProduct.Size = new Size(209, 49);
            BtnDeleteProduct.TabIndex = 41;
            BtnDeleteProduct.Tag = "DISABLE";
            BtnDeleteProduct.Text = "Deshabilitar";
            BtnDeleteProduct.UseVisualStyleBackColor = false;
            BtnDeleteProduct.Click += BtnDeleteProduct_Click;
            // 
            // BtnAddProduct
            // 
            BtnAddProduct.BackColor = Color.ForestGreen;
            BtnAddProduct.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddProduct.ForeColor = SystemColors.ButtonHighlight;
            BtnAddProduct.Location = new Point(54, 236);
            BtnAddProduct.Margin = new Padding(4, 5, 4, 5);
            BtnAddProduct.Name = "BtnAddProduct";
            BtnAddProduct.Size = new Size(209, 49);
            BtnAddProduct.TabIndex = 40;
            BtnAddProduct.Tag = "ADD";
            BtnAddProduct.Text = "Agregar";
            BtnAddProduct.UseVisualStyleBackColor = false;
            BtnAddProduct.Click += BtnAddProduct_Click;
            // 
            // CmbCategories
            // 
            CmbCategories.DisplayMember = "Description";
            CmbCategories.FormattingEnabled = true;
            CmbCategories.Location = new Point(645, 187);
            CmbCategories.Name = "CmbCategories";
            CmbCategories.Size = new Size(338, 33);
            CmbCategories.TabIndex = 43;
            CmbCategories.ValueMember = "Id";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label5.ForeColor = Color.ForestGreen;
            label5.Location = new Point(645, 156);
            label5.Name = "label5";
            label5.Size = new Size(113, 28);
            label5.TabIndex = 42;
            label5.Tag = "CATEGORY";
            label5.Text = "Categoria:";
            // 
            // FrmAddProducts
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1729, 923);
            Controls.Add(CmbCategories);
            Controls.Add(label5);
            Controls.Add(BtnDeleteProduct);
            Controls.Add(BtnAddProduct);
            Controls.Add(label4);
            Controls.Add(TxtPoints);
            Controls.Add(label3);
            Controls.Add(TxtDescription);
            Controls.Add(label2);
            Controls.Add(TxtName);
            Controls.Add(label1);
            Controls.Add(DgvProducts);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAddProducts";
            Text = "FrmAddProducts";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmAddProducts_FormClosed;
            Load += FrmAddProducts_Load;
            Shown += FrmAddProducts_Shown;
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvProducts;
        private Label label1;
        private Label label2;
        private TextBox TxtName;
        private Label label3;
        private TextBox TxtDescription;
        private Label label4;
        private TextBox TxtPoints;
        private Button BtnDeleteProduct;
        private Button BtnAddProduct;
        private ComboBox CmbCategories;
        private Label label5;
    }
}