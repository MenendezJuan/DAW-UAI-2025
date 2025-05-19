namespace UI.Objectives
{
    partial class FrmCreateObjectives
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
            btnClearControls = new Button();
            btnAddObjective = new Button();
            cmbStatus = new ComboBox();
            label1 = new Label();
            cmbNominee = new ComboBox();
            lblNominee = new Label();
            cmbPriority = new ComboBox();
            label2 = new Label();
            cmbCategory = new ComboBox();
            label3 = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtDescription = new TextBox();
            txtTitle = new TextBox();
            label7 = new Label();
            cmbRewardPolicy = new ComboBox();
            label8 = new Label();
            txtPoints = new TextBox();
            lblPoints = new Label();
            SuspendLayout();
            // 
            // btnClearControls
            // 
            btnClearControls.BackColor = Color.ForestGreen;
            btnClearControls.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearControls.ForeColor = SystemColors.ButtonHighlight;
            btnClearControls.Location = new Point(346, 402);
            btnClearControls.Margin = new Padding(4, 5, 4, 5);
            btnClearControls.Name = "btnClearControls";
            btnClearControls.Size = new Size(209, 49);
            btnClearControls.TabIndex = 49;
            btnClearControls.Tag = "";
            btnClearControls.Text = "Limpiar";
            btnClearControls.UseVisualStyleBackColor = false;
            btnClearControls.Click += btnClearControls_Click;
            // 
            // btnAddObjective
            // 
            btnAddObjective.BackColor = Color.ForestGreen;
            btnAddObjective.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddObjective.ForeColor = SystemColors.ButtonHighlight;
            btnAddObjective.Location = new Point(115, 402);
            btnAddObjective.Margin = new Padding(4, 5, 4, 5);
            btnAddObjective.Name = "btnAddObjective";
            btnAddObjective.Size = new Size(223, 49);
            btnAddObjective.TabIndex = 48;
            btnAddObjective.Tag = "";
            btnAddObjective.Text = "Crear objetivo";
            btnAddObjective.UseVisualStyleBackColor = false;
            btnAddObjective.Click += btnAddObjective_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(987, 192);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(246, 33);
            cmbStatus.TabIndex = 47;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(855, 193);
            label1.Name = "label1";
            label1.Size = new Size(100, 32);
            label1.TabIndex = 46;
            label1.Tag = "";
            label1.Text = "Estado:";
            // 
            // cmbNominee
            // 
            cmbNominee.FormattingEnabled = true;
            cmbNominee.Location = new Point(987, 136);
            cmbNominee.Name = "cmbNominee";
            cmbNominee.Size = new Size(246, 33);
            cmbNominee.TabIndex = 45;
            // 
            // lblNominee
            // 
            lblNominee.AutoSize = true;
            lblNominee.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblNominee.ForeColor = Color.ForestGreen;
            lblNominee.Location = new Point(796, 133);
            lblNominee.Name = "lblNominee";
            lblNominee.Size = new Size(165, 32);
            lblNominee.TabIndex = 44;
            lblNominee.Tag = "";
            lblNominee.Text = "Colaborador:";
            // 
            // cmbPriority
            // 
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(987, 80);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(246, 33);
            cmbPriority.TabIndex = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(831, 81);
            label2.Name = "label2";
            label2.Size = new Size(130, 32);
            label2.TabIndex = 50;
            label2.Tag = "";
            label2.Text = "Prioridad:";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(286, 300);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(246, 33);
            cmbCategory.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(127, 301);
            label3.Name = "label3";
            label3.Size = new Size(133, 32);
            label3.TabIndex = 52;
            label3.Tag = "";
            label3.Text = "Categoria:";
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(286, 246);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(392, 31);
            dtpTo.TabIndex = 77;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(286, 190);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(392, 31);
            dtpFrom.TabIndex = 75;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label4.ForeColor = Color.ForestGreen;
            label4.Location = new Point(127, 185);
            label4.Name = "label4";
            label4.Size = new Size(121, 32);
            label4.TabIndex = 78;
            label4.Tag = "";
            label4.Text = "F. Desde:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label5.ForeColor = Color.ForestGreen;
            label5.Location = new Point(127, 245);
            label5.Name = "label5";
            label5.Size = new Size(117, 32);
            label5.TabIndex = 79;
            label5.Tag = "";
            label5.Text = "F. Hasta:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label6.ForeColor = Color.ForestGreen;
            label6.Location = new Point(127, 129);
            label6.Name = "label6";
            label6.Size = new Size(158, 32);
            label6.TabIndex = 80;
            label6.Tag = "";
            label6.Text = "Descripción:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(286, 132);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(392, 31);
            txtDescription.TabIndex = 81;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(286, 84);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(392, 31);
            txtTitle.TabIndex = 83;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label7.ForeColor = Color.ForestGreen;
            label7.Location = new Point(127, 81);
            label7.Name = "label7";
            label7.Size = new Size(91, 32);
            label7.TabIndex = 82;
            label7.Tag = "";
            label7.Text = "Título:";
            // 
            // cmbRewardPolicy
            // 
            cmbRewardPolicy.FormattingEnabled = true;
            cmbRewardPolicy.Location = new Point(987, 248);
            cmbRewardPolicy.Name = "cmbRewardPolicy";
            cmbRewardPolicy.Size = new Size(246, 33);
            cmbRewardPolicy.TabIndex = 85;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label8.ForeColor = Color.ForestGreen;
            label8.Location = new Point(846, 249);
            label8.Name = "label8";
            label8.Size = new Size(109, 32);
            label8.TabIndex = 84;
            label8.Tag = "";
            label8.Text = "Política:";
            // 
            // txtPoints
            // 
            txtPoints.Location = new Point(987, 304);
            txtPoints.Name = "txtPoints";
            txtPoints.Size = new Size(251, 31);
            txtPoints.TabIndex = 86;
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblPoints.ForeColor = Color.ForestGreen;
            lblPoints.Location = new Point(846, 301);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(105, 32);
            lblPoints.TabIndex = 87;
            lblPoints.Tag = "";
            lblPoints.Text = "Puntos:";
            // 
            // FrmCreateObjectives
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 777);
            Controls.Add(lblPoints);
            Controls.Add(txtPoints);
            Controls.Add(cmbRewardPolicy);
            Controls.Add(label8);
            Controls.Add(txtTitle);
            Controls.Add(label7);
            Controls.Add(txtDescription);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(cmbCategory);
            Controls.Add(label3);
            Controls.Add(cmbPriority);
            Controls.Add(label2);
            Controls.Add(btnClearControls);
            Controls.Add(btnAddObjective);
            Controls.Add(cmbStatus);
            Controls.Add(label1);
            Controls.Add(cmbNominee);
            Controls.Add(lblNominee);
            Name = "FrmCreateObjectives";
            Text = "FrmCreateObjectives";
            FormClosed += FrmCreateObjectives_FormClosed;
            Load += FrmCreateObjectives_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClearControls;
        private Button btnAddObjective;
        private ComboBox cmbStatus;
        private Label label1;
        private ComboBox cmbNominee;
        private Label lblNominee;
        private ComboBox cmbPriority;
        private Label label2;
        private ComboBox cmbCategory;
        private Label label3;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtDescription;
        private TextBox txtTitle;
        private Label label7;
        private ComboBox cmbRewardPolicy;
        private Label label8;
        private TextBox txtPoints;
        private Label lblPoints;
    }
}