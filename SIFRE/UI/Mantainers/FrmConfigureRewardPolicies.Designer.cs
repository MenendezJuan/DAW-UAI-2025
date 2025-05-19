namespace UI.Mantainers
{
    partial class FrmConfigureRewardPolicies
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
            lblConversionRate = new Label();
            label3 = new Label();
            TxtDescription = new TextBox();
            label2 = new Label();
            TxtName = new TextBox();
            BtnAdd = new Button();
            dgvRewardPolicies = new DataGridView();
            CmbCategories = new ComboBox();
            label5 = new Label();
            nudConversionRate = new NumericUpDown();
            nudAccumulationLimit = new NumericUpDown();
            lblAccumulationLimit = new Label();
            dtpEffectiveTo = new DateTimePicker();
            lblDateTo = new Label();
            dtpEffectiveFrom = new DateTimePicker();
            lblDate = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRewardPolicies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudConversionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAccumulationLimit).BeginInit();
            SuspendLayout();
            // 
            // lblConversionRate
            // 
            lblConversionRate.AutoSize = true;
            lblConversionRate.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            lblConversionRate.ForeColor = Color.ForestGreen;
            lblConversionRate.Location = new Point(464, 63);
            lblConversionRate.Name = "lblConversionRate";
            lblConversionRate.Size = new Size(209, 28);
            lblConversionRate.TabIndex = 55;
            lblConversionRate.Tag = "";
            lblConversionRate.Text = "Tasa de conversión:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(261, 63);
            label3.Name = "label3";
            label3.Size = new Size(134, 28);
            label3.TabIndex = 53;
            label3.Tag = "DESCRIPTION";
            label3.Text = "Descripción:";
            // 
            // TxtDescription
            // 
            TxtDescription.Location = new Point(261, 94);
            TxtDescription.MaxLength = 200;
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(191, 31);
            TxtDescription.TabIndex = 52;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(75, 63);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 51;
            label2.Tag = "NAME";
            label2.Text = "Nombre:";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(75, 94);
            TxtName.MaxLength = 100;
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(176, 31);
            TxtName.TabIndex = 50;
            // 
            // BtnAdd
            // 
            BtnAdd.BackColor = Color.ForestGreen;
            BtnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAdd.ForeColor = SystemColors.ButtonHighlight;
            BtnAdd.Location = new Point(75, 837);
            BtnAdd.Margin = new Padding(4, 5, 4, 5);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(209, 49);
            BtnAdd.TabIndex = 49;
            BtnAdd.Tag = "ADD";
            BtnAdd.Text = "Agregar";
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // dgvRewardPolicies
            // 
            dgvRewardPolicies.AllowUserToAddRows = false;
            dgvRewardPolicies.AllowUserToDeleteRows = false;
            dgvRewardPolicies.AllowUserToResizeColumns = false;
            dgvRewardPolicies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRewardPolicies.Location = new Point(75, 203);
            dgvRewardPolicies.Name = "dgvRewardPolicies";
            dgvRewardPolicies.RowHeadersWidth = 62;
            dgvRewardPolicies.Size = new Size(1395, 613);
            dgvRewardPolicies.TabIndex = 48;
            // 
            // CmbCategories
            // 
            CmbCategories.DisplayMember = "Description";
            CmbCategories.FormattingEnabled = true;
            CmbCategories.Location = new Point(913, 93);
            CmbCategories.Name = "CmbCategories";
            CmbCategories.Size = new Size(176, 33);
            CmbCategories.TabIndex = 57;
            CmbCategories.ValueMember = "Id";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label5.ForeColor = Color.ForestGreen;
            label5.Location = new Point(913, 62);
            label5.Name = "label5";
            label5.Size = new Size(113, 28);
            label5.TabIndex = 56;
            label5.Tag = "CATEGORY";
            label5.Text = "Categoria:";
            // 
            // nudConversionRate
            // 
            nudConversionRate.DecimalPlaces = 2;
            nudConversionRate.Location = new Point(464, 95);
            nudConversionRate.Name = "nudConversionRate";
            nudConversionRate.Size = new Size(209, 31);
            nudConversionRate.TabIndex = 58;
            // 
            // nudAccumulationLimit
            // 
            nudAccumulationLimit.DecimalPlaces = 2;
            nudAccumulationLimit.Location = new Point(689, 95);
            nudAccumulationLimit.Name = "nudAccumulationLimit";
            nudAccumulationLimit.Size = new Size(209, 31);
            nudAccumulationLimit.TabIndex = 60;
            // 
            // lblAccumulationLimit
            // 
            lblAccumulationLimit.AutoSize = true;
            lblAccumulationLimit.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            lblAccumulationLimit.ForeColor = Color.ForestGreen;
            lblAccumulationLimit.Location = new Point(689, 63);
            lblAccumulationLimit.Name = "lblAccumulationLimit";
            lblAccumulationLimit.Size = new Size(210, 28);
            lblAccumulationLimit.TabIndex = 59;
            lblAccumulationLimit.Tag = "";
            lblAccumulationLimit.Text = "Limite acumulación:";
            // 
            // dtpEffectiveTo
            // 
            dtpEffectiveTo.Location = new Point(524, 166);
            dtpEffectiveTo.Name = "dtpEffectiveTo";
            dtpEffectiveTo.Size = new Size(392, 31);
            dtpEffectiveTo.TabIndex = 73;
            // 
            // lblDateTo
            // 
            lblDateTo.AutoSize = true;
            lblDateTo.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            lblDateTo.ForeColor = Color.ForestGreen;
            lblDateTo.Location = new Point(524, 135);
            lblDateTo.Name = "lblDateTo";
            lblDateTo.Size = new Size(131, 28);
            lblDateTo.TabIndex = 72;
            lblDateTo.Tag = "DATE_TO";
            lblDateTo.Text = "Fecha hasta:";
            // 
            // dtpEffectiveFrom
            // 
            dtpEffectiveFrom.Location = new Point(75, 166);
            dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            dtpEffectiveFrom.Size = new Size(392, 31);
            dtpEffectiveFrom.TabIndex = 71;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            lblDate.ForeColor = Color.ForestGreen;
            lblDate.Location = new Point(75, 135);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(137, 28);
            lblDate.TabIndex = 70;
            lblDate.Tag = "DATE_FROM";
            lblDate.Text = "Fecha desde:";
            // 
            // FrmConfigureRewardPolicies
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1548, 1208);
            Controls.Add(dtpEffectiveTo);
            Controls.Add(lblDateTo);
            Controls.Add(dtpEffectiveFrom);
            Controls.Add(lblDate);
            Controls.Add(nudAccumulationLimit);
            Controls.Add(lblAccumulationLimit);
            Controls.Add(nudConversionRate);
            Controls.Add(CmbCategories);
            Controls.Add(label5);
            Controls.Add(lblConversionRate);
            Controls.Add(label3);
            Controls.Add(TxtDescription);
            Controls.Add(label2);
            Controls.Add(TxtName);
            Controls.Add(BtnAdd);
            Controls.Add(dgvRewardPolicies);
            Name = "FrmConfigureRewardPolicies";
            Text = "FrmConfigureRewardPolicies";
            FormClosed += FrmConfigureRewardPolicies_FormClosed;
            Load += FrmConfigureRewardPolicies_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRewardPolicies).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudConversionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAccumulationLimit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConversionRate;
        private Label label3;
        private TextBox TxtDescription;
        private Label label2;
        private TextBox TxtName;
        private Button BtnAdd;
        private DataGridView dgvRewardPolicies;
        private ComboBox CmbCategories;
        private Label label5;
        private NumericUpDown nudConversionRate;
        private NumericUpDown nudAccumulationLimit;
        private Label lblAccumulationLimit;
        private DateTimePicker dtpEffectiveTo;
        private Label lblDateTo;
        private DateTimePicker dtpEffectiveFrom;
        private Label lblDate;
    }
}