namespace UI.Mantainers
{
    partial class FrmConfigureRecognitionCategories
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
            dgvCategories = new DataGridView();
            BtnAddProduct = new Button();
            label4 = new Label();
            TxtPoints = new TextBox();
            label3 = new Label();
            TxtDescription = new TextBox();
            label2 = new Label();
            TxtName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AllowUserToResizeColumns = false;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Location = new Point(49, 130);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.RowHeadersWidth = 62;
            dgvCategories.Size = new Size(1395, 613);
            dgvCategories.TabIndex = 0;
            // 
            // BtnAddProduct
            // 
            BtnAddProduct.BackColor = Color.ForestGreen;
            BtnAddProduct.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddProduct.ForeColor = SystemColors.ButtonHighlight;
            BtnAddProduct.Location = new Point(633, 73);
            BtnAddProduct.Margin = new Padding(4, 5, 4, 5);
            BtnAddProduct.Name = "BtnAddProduct";
            BtnAddProduct.Size = new Size(209, 49);
            BtnAddProduct.TabIndex = 41;
            BtnAddProduct.Tag = "ADD";
            BtnAddProduct.Text = "Agregar";
            BtnAddProduct.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label4.ForeColor = Color.ForestGreen;
            label4.Location = new Point(435, 54);
            label4.Name = "label4";
            label4.Size = new Size(88, 28);
            label4.TabIndex = 47;
            label4.Tag = "POINTS";
            label4.Text = "Puntos:";
            // 
            // TxtPoints
            // 
            TxtPoints.Location = new Point(435, 85);
            TxtPoints.MaxLength = 10;
            TxtPoints.Name = "TxtPoints";
            TxtPoints.Size = new Size(191, 31);
            TxtPoints.TabIndex = 46;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(232, 54);
            label3.Name = "label3";
            label3.Size = new Size(134, 28);
            label3.TabIndex = 45;
            label3.Tag = "DESCRIPTION";
            label3.Text = "Descripción:";
            // 
            // TxtDescription
            // 
            TxtDescription.Location = new Point(232, 85);
            TxtDescription.MaxLength = 200;
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(191, 31);
            TxtDescription.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(46, 54);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 43;
            label2.Tag = "NAME";
            label2.Text = "Nombre:";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(46, 85);
            TxtName.MaxLength = 100;
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(176, 31);
            TxtName.TabIndex = 42;
            // 
            // FrmConfigureRecognitionCategories
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1529, 794);
            Controls.Add(label4);
            Controls.Add(TxtPoints);
            Controls.Add(label3);
            Controls.Add(TxtDescription);
            Controls.Add(label2);
            Controls.Add(TxtName);
            Controls.Add(BtnAddProduct);
            Controls.Add(dgvCategories);
            Name = "FrmConfigureRecognitionCategories";
            Text = "FrmConfigureRecognitionCategories";
            FormClosed += FrmConfigureRecognitionCategories_FormClosed;
            Load += FrmConfigureRecognitionCategories_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCategories;
        private Button BtnAddProduct;
        private Label label4;
        private TextBox TxtPoints;
        private Label label3;
        private TextBox TxtDescription;
        private Label label2;
        private TextBox TxtName;
    }
}