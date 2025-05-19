namespace UI.Language
{
    partial class FrmManageLanguage
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
            TxtLanguage = new TextBox();
            BtnAdd = new Button();
            BtnDelete = new Button();
            DgvLanguages = new DataGridView();
            LblError = new Label();
            DgvTranslations = new DataGridView();
            label2 = new Label();
            BtnAddLabel = new Button();
            BtnRemoveLabel = new Button();
            label3 = new Label();
            DgvLabels = new DataGridView();
            BtnAddTranslation = new Button();
            BtnRemoveTranslation = new Button();
            TxtTranslation = new TextBox();
            TxtLabel = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DgvLanguages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvTranslations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvLabels).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(23, 63);
            label1.Name = "label1";
            label1.Size = new Size(209, 36);
            label1.TabIndex = 4;
            label1.Tag = "MANAGE_LANG";
            label1.Text = "Gestionar idioma";
            label1.Click += label1_Click;
            // 
            // TxtLanguage
            // 
            TxtLanguage.Location = new Point(23, 122);
            TxtLanguage.Name = "TxtLanguage";
            TxtLanguage.Size = new Size(270, 31);
            TxtLanguage.TabIndex = 22;
            // 
            // BtnAdd
            // 
            BtnAdd.BackColor = Color.ForestGreen;
            BtnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAdd.ForeColor = SystemColors.ButtonHighlight;
            BtnAdd.Location = new Point(300, 111);
            BtnAdd.Margin = new Padding(4, 5, 4, 5);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(154, 49);
            BtnAdd.TabIndex = 6;
            BtnAdd.Text = "Agregar";
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.ForestGreen;
            BtnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDelete.ForeColor = SystemColors.ButtonHighlight;
            BtnDelete.Location = new Point(462, 111);
            BtnDelete.Margin = new Padding(4, 5, 4, 5);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(154, 49);
            BtnDelete.TabIndex = 7;
            BtnDelete.Text = "Borrar";
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // DgvLanguages
            // 
            DgvLanguages.AllowUserToAddRows = false;
            DgvLanguages.AllowUserToDeleteRows = false;
            DgvLanguages.AllowUserToResizeColumns = false;
            DgvLanguages.AllowUserToResizeRows = false;
            DgvLanguages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvLanguages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvLanguages.Location = new Point(23, 168);
            DgvLanguages.Name = "DgvLanguages";
            DgvLanguages.ReadOnly = true;
            DgvLanguages.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            DgvLanguages.Size = new Size(755, 300);
            DgvLanguages.TabIndex = 8;
            DgvLanguages.CellClick += DgvLanguages_CellClick;
            // 
            // LblError
            // 
            LblError.AutoSize = true;
            LblError.BackColor = Color.Transparent;
            LblError.ForeColor = Color.Firebrick;
            LblError.Location = new Point(23, 910);
            LblError.Name = "LblError";
            LblError.Size = new Size(0, 25);
            LblError.TabIndex = 10;
            LblError.TextAlign = ContentAlignment.MiddleLeft;
            LblError.Visible = false;
            // 
            // DgvTranslations
            // 
            DgvTranslations.AllowUserToResizeColumns = false;
            DgvTranslations.AllowUserToResizeRows = false;
            DgvTranslations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvTranslations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvTranslations.Location = new Point(23, 536);
            DgvTranslations.Name = "DgvTranslations";
            DgvTranslations.RowHeadersWidth = 62;
            DgvTranslations.Size = new Size(755, 300);
            DgvTranslations.TabIndex = 11;
            DgvTranslations.CellClick += DgvTranslations_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(23, 484);
            label2.Name = "label2";
            label2.Size = new Size(128, 28);
            label2.TabIndex = 12;
            label2.Text = "Traducciones:";
            // 
            // BtnAddLabel
            // 
            BtnAddLabel.BackColor = Color.ForestGreen;
            BtnAddLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddLabel.ForeColor = SystemColors.ButtonHighlight;
            BtnAddLabel.Location = new Point(1476, 168);
            BtnAddLabel.Margin = new Padding(4, 5, 4, 5);
            BtnAddLabel.Name = "BtnAddLabel";
            BtnAddLabel.Size = new Size(209, 49);
            BtnAddLabel.TabIndex = 13;
            BtnAddLabel.Text = "Agregar etiqueta";
            BtnAddLabel.UseVisualStyleBackColor = false;
            BtnAddLabel.Click += BtnAddLabel_Click;
            // 
            // BtnRemoveLabel
            // 
            BtnRemoveLabel.BackColor = Color.ForestGreen;
            BtnRemoveLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnRemoveLabel.ForeColor = SystemColors.ButtonHighlight;
            BtnRemoveLabel.Location = new Point(1476, 227);
            BtnRemoveLabel.Margin = new Padding(4, 5, 4, 5);
            BtnRemoveLabel.Name = "BtnRemoveLabel";
            BtnRemoveLabel.Size = new Size(209, 49);
            BtnRemoveLabel.TabIndex = 14;
            BtnRemoveLabel.Text = "Borrar etiqueta";
            BtnRemoveLabel.UseVisualStyleBackColor = false;
            BtnRemoveLabel.Click += BtnRemoveLabel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(859, 125);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 16;
            label3.Text = "Etiquetas:";
            // 
            // DgvLabels
            // 
            DgvLabels.AllowUserToResizeColumns = false;
            DgvLabels.AllowUserToResizeRows = false;
            DgvLabels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvLabels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvLabels.Location = new Point(859, 168);
            DgvLabels.Name = "DgvLabels";
            DgvLabels.RowHeadersWidth = 62;
            DgvLabels.Size = new Size(610, 300);
            DgvLabels.TabIndex = 17;
            DgvLabels.CellClick += DgvLabels_CellClick;
            // 
            // BtnAddTranslation
            // 
            BtnAddTranslation.BackColor = Color.ForestGreen;
            BtnAddTranslation.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddTranslation.ForeColor = SystemColors.ButtonHighlight;
            BtnAddTranslation.Location = new Point(859, 536);
            BtnAddTranslation.Margin = new Padding(4, 5, 4, 5);
            BtnAddTranslation.Name = "BtnAddTranslation";
            BtnAddTranslation.Size = new Size(280, 49);
            BtnAddTranslation.TabIndex = 18;
            BtnAddTranslation.Text = "Agregar traducción";
            BtnAddTranslation.UseVisualStyleBackColor = false;
            BtnAddTranslation.Click += BtnAddTranslation_Click;
            // 
            // BtnRemoveTranslation
            // 
            BtnRemoveTranslation.BackColor = Color.ForestGreen;
            BtnRemoveTranslation.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnRemoveTranslation.ForeColor = SystemColors.ButtonHighlight;
            BtnRemoveTranslation.Location = new Point(859, 595);
            BtnRemoveTranslation.Margin = new Padding(4, 5, 4, 5);
            BtnRemoveTranslation.Name = "BtnRemoveTranslation";
            BtnRemoveTranslation.Size = new Size(280, 49);
            BtnRemoveTranslation.TabIndex = 19;
            BtnRemoveTranslation.Text = "Borrar traducción";
            BtnRemoveTranslation.UseVisualStyleBackColor = false;
            BtnRemoveTranslation.Click += BtnRemoveTranslation_Click;
            // 
            // TxtTranslation
            // 
            TxtTranslation.Location = new Point(859, 665);
            TxtTranslation.Name = "TxtTranslation";
            TxtTranslation.Size = new Size(270, 31);
            TxtTranslation.TabIndex = 20;
            TxtTranslation.TextChanged += TxtTranslation_TextChanged;
            // 
            // TxtLabel
            // 
            TxtLabel.Location = new Point(1476, 284);
            TxtLabel.Name = "TxtLabel";
            TxtLabel.Size = new Size(209, 31);
            TxtLabel.TabIndex = 21;
            // 
            // FrmManageLanguage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1787, 939);
            Controls.Add(TxtLabel);
            Controls.Add(TxtTranslation);
            Controls.Add(BtnRemoveTranslation);
            Controls.Add(BtnAddTranslation);
            Controls.Add(DgvLabels);
            Controls.Add(label3);
            Controls.Add(BtnRemoveLabel);
            Controls.Add(BtnAddLabel);
            Controls.Add(label2);
            Controls.Add(DgvTranslations);
            Controls.Add(LblError);
            Controls.Add(DgvLanguages);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAdd);
            Controls.Add(TxtLanguage);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmManageLanguage";
            Text = "Gestionar idioma";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmManageLanguage_FormClosed;
            Load += FrmAddLanguage_Load;
            ((System.ComponentModel.ISupportInitialize)DgvLanguages).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvTranslations).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvLabels).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtLanguage;
        private Button BtnAdd;
        private Button BtnDelete;
        private DataGridView DgvLanguages;
        private Label LblError;
        private DataGridView DgvTranslations;
        private Label label2;
        private Button BtnAddLabel;
        private Button BtnRemoveLabel;
        private Label label3;
        private DataGridView DgvLabels;
        private Button BtnAddTranslation;
        private Button BtnRemoveTranslation;
        private TextBox TxtTranslation;
        private TextBox TxtLabel;
    }
}