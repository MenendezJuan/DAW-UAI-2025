namespace UI.Profiles
{
    partial class FrmManageProfile
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
            GPPermission = new GroupBox();
            BtnDeletePermission = new Button();
            CmbPermissions = new ComboBox();
            BtnAddPermission = new Button();
            groupBox2 = new GroupBox();
            label2 = new Label();
            TxtPermission = new TextBox();
            CmbPermissionType = new ComboBox();
            label1 = new Label();
            BtnSavePermission = new Button();
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            CmbUsers = new ComboBox();
            label5 = new Label();
            BtnAssign = new Button();
            BtnDeleteRole = new Button();
            CmbRoles = new ComboBox();
            BtnConfig = new Button();
            BtnAddRole = new Button();
            groupBox3 = new GroupBox();
            label4 = new Label();
            TxtRole = new TextBox();
            BtnSaveRole = new Button();
            treeView1 = new TreeView();
            label3 = new Label();
            BtnSaveRoleComponent = new Button();
            GPPermission.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // GPPermission
            // 
            GPPermission.Controls.Add(BtnDeletePermission);
            GPPermission.Controls.Add(CmbPermissions);
            GPPermission.Controls.Add(BtnAddPermission);
            GPPermission.Controls.Add(groupBox2);
            GPPermission.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GPPermission.ForeColor = Color.ForestGreen;
            GPPermission.Location = new Point(45, 59);
            GPPermission.Name = "GPPermission";
            GPPermission.Size = new Size(715, 470);
            GPPermission.TabIndex = 0;
            GPPermission.TabStop = false;
            GPPermission.Text = "Permisos";
            // 
            // BtnDeletePermission
            // 
            BtnDeletePermission.BackColor = Color.ForestGreen;
            BtnDeletePermission.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDeletePermission.ForeColor = SystemColors.ButtonHighlight;
            BtnDeletePermission.Location = new Point(7, 146);
            BtnDeletePermission.Margin = new Padding(4, 5, 4, 5);
            BtnDeletePermission.Name = "BtnDeletePermission";
            BtnDeletePermission.Size = new Size(209, 49);
            BtnDeletePermission.TabIndex = 30;
            BtnDeletePermission.Text = "Borrar";
            BtnDeletePermission.UseVisualStyleBackColor = false;
            BtnDeletePermission.Click += BtnDeletePermission_Click;
            // 
            // CmbPermissions
            // 
            CmbPermissions.DisplayMember = "Name";
            CmbPermissions.FormattingEnabled = true;
            CmbPermissions.Location = new Point(6, 39);
            CmbPermissions.Name = "CmbPermissions";
            CmbPermissions.Size = new Size(338, 40);
            CmbPermissions.TabIndex = 28;
            CmbPermissions.ValueMember = "Id";
            // 
            // BtnAddPermission
            // 
            BtnAddPermission.BackColor = Color.ForestGreen;
            BtnAddPermission.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddPermission.ForeColor = SystemColors.ButtonHighlight;
            BtnAddPermission.Location = new Point(7, 87);
            BtnAddPermission.Margin = new Padding(4, 5, 4, 5);
            BtnAddPermission.Name = "BtnAddPermission";
            BtnAddPermission.Size = new Size(209, 49);
            BtnAddPermission.TabIndex = 29;
            BtnAddPermission.Text = "Agregar";
            BtnAddPermission.UseVisualStyleBackColor = false;
            BtnAddPermission.Click += BtnAddPermission_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(TxtPermission);
            groupBox2.Controls.Add(CmbPermissionType);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(BtnSavePermission);
            groupBox2.ForeColor = Color.ForestGreen;
            groupBox2.Location = new Point(350, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(359, 442);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nuevo permiso";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(7, 135);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 33;
            label2.Text = "Nombre:";
            // 
            // TxtPermission
            // 
            TxtPermission.Location = new Point(7, 166);
            TxtPermission.Name = "TxtPermission";
            TxtPermission.Size = new Size(338, 40);
            TxtPermission.TabIndex = 32;
            // 
            // CmbPermissionType
            // 
            CmbPermissionType.FormattingEnabled = true;
            CmbPermissionType.Location = new Point(7, 70);
            CmbPermissionType.Name = "CmbPermissionType";
            CmbPermissionType.Size = new Size(338, 40);
            CmbPermissionType.TabIndex = 31;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(7, 36);
            label1.Name = "label1";
            label1.Size = new Size(180, 28);
            label1.TabIndex = 19;
            label1.Text = "Tipo de permiso:";
            // 
            // BtnSavePermission
            // 
            BtnSavePermission.BackColor = Color.ForestGreen;
            BtnSavePermission.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSavePermission.ForeColor = SystemColors.ButtonHighlight;
            BtnSavePermission.Location = new Point(7, 223);
            BtnSavePermission.Margin = new Padding(4, 5, 4, 5);
            BtnSavePermission.Name = "BtnSavePermission";
            BtnSavePermission.Size = new Size(209, 49);
            BtnSavePermission.TabIndex = 22;
            BtnSavePermission.Text = "Guardar";
            BtnSavePermission.UseVisualStyleBackColor = false;
            BtnSavePermission.Click += BtnSavePermission_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(BtnDeleteRole);
            groupBox1.Controls.Add(CmbRoles);
            groupBox1.Controls.Add(BtnConfig);
            groupBox1.Controls.Add(BtnAddRole);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.ForestGreen;
            groupBox1.Location = new Point(783, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 470);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Perfiles";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(CmbUsers);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(BtnAssign);
            groupBox4.ForeColor = Color.ForestGreen;
            groupBox4.Location = new Point(395, 211);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(359, 197);
            groupBox4.TabIndex = 36;
            groupBox4.TabStop = false;
            groupBox4.Text = "Asignar perfil";
            // 
            // CmbUsers
            // 
            CmbUsers.DisplayMember = "Username";
            CmbUsers.FormattingEnabled = true;
            CmbUsers.Location = new Point(7, 76);
            CmbUsers.Name = "CmbUsers";
            CmbUsers.Size = new Size(338, 40);
            CmbUsers.TabIndex = 37;
            CmbUsers.ValueMember = "Id";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label5.ForeColor = Color.ForestGreen;
            label5.Location = new Point(7, 43);
            label5.Name = "label5";
            label5.Size = new Size(95, 28);
            label5.TabIndex = 35;
            label5.Text = "Usuario:";
            // 
            // BtnAssign
            // 
            BtnAssign.BackColor = Color.ForestGreen;
            BtnAssign.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAssign.ForeColor = SystemColors.ButtonHighlight;
            BtnAssign.Location = new Point(7, 124);
            BtnAssign.Margin = new Padding(4, 5, 4, 5);
            BtnAssign.Name = "BtnAssign";
            BtnAssign.Size = new Size(209, 49);
            BtnAssign.TabIndex = 23;
            BtnAssign.Text = "Asignar";
            BtnAssign.UseVisualStyleBackColor = false;
            BtnAssign.Click += BtnAssign_Click;
            // 
            // BtnDeleteRole
            // 
            BtnDeleteRole.BackColor = Color.ForestGreen;
            BtnDeleteRole.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDeleteRole.ForeColor = SystemColors.ButtonHighlight;
            BtnDeleteRole.Location = new Point(7, 205);
            BtnDeleteRole.Margin = new Padding(4, 5, 4, 5);
            BtnDeleteRole.Name = "BtnDeleteRole";
            BtnDeleteRole.Size = new Size(209, 49);
            BtnDeleteRole.TabIndex = 28;
            BtnDeleteRole.Text = "Borrar";
            BtnDeleteRole.UseVisualStyleBackColor = false;
            BtnDeleteRole.Click += BtnDeleteRole_Click;
            // 
            // CmbRoles
            // 
            CmbRoles.DisplayMember = "Name";
            CmbRoles.FormattingEnabled = true;
            CmbRoles.Location = new Point(7, 39);
            CmbRoles.Name = "CmbRoles";
            CmbRoles.Size = new Size(382, 40);
            CmbRoles.TabIndex = 27;
            CmbRoles.ValueMember = "Id";
            // 
            // BtnConfig
            // 
            BtnConfig.BackColor = Color.ForestGreen;
            BtnConfig.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnConfig.ForeColor = SystemColors.ButtonHighlight;
            BtnConfig.Location = new Point(7, 87);
            BtnConfig.Margin = new Padding(4, 5, 4, 5);
            BtnConfig.Name = "BtnConfig";
            BtnConfig.Size = new Size(209, 49);
            BtnConfig.TabIndex = 26;
            BtnConfig.Text = "Configurar";
            BtnConfig.UseVisualStyleBackColor = false;
            BtnConfig.Click += BtnConfig_Click;
            // 
            // BtnAddRole
            // 
            BtnAddRole.BackColor = Color.ForestGreen;
            BtnAddRole.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnAddRole.ForeColor = SystemColors.ButtonHighlight;
            BtnAddRole.Location = new Point(7, 146);
            BtnAddRole.Margin = new Padding(4, 5, 4, 5);
            BtnAddRole.Name = "BtnAddRole";
            BtnAddRole.Size = new Size(209, 49);
            BtnAddRole.TabIndex = 25;
            BtnAddRole.Text = "Agregar";
            BtnAddRole.UseVisualStyleBackColor = false;
            BtnAddRole.Click += BtnAddRole_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(TxtRole);
            groupBox3.Controls.Add(BtnSaveRole);
            groupBox3.ForeColor = Color.ForestGreen;
            groupBox3.Location = new Point(395, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(359, 183);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nuevo perfil";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label4.ForeColor = Color.ForestGreen;
            label4.Location = new Point(7, 43);
            label4.Name = "label4";
            label4.Size = new Size(99, 28);
            label4.TabIndex = 35;
            label4.Text = "Nombre:";
            // 
            // TxtRole
            // 
            TxtRole.Location = new Point(7, 74);
            TxtRole.Name = "TxtRole";
            TxtRole.Size = new Size(338, 40);
            TxtRole.TabIndex = 34;
            // 
            // BtnSaveRole
            // 
            BtnSaveRole.BackColor = Color.ForestGreen;
            BtnSaveRole.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSaveRole.ForeColor = SystemColors.ButtonHighlight;
            BtnSaveRole.Location = new Point(7, 124);
            BtnSaveRole.Margin = new Padding(4, 5, 4, 5);
            BtnSaveRole.Name = "BtnSaveRole";
            BtnSaveRole.Size = new Size(209, 49);
            BtnSaveRole.TabIndex = 23;
            BtnSaveRole.Text = "Guardar";
            BtnSaveRole.UseVisualStyleBackColor = false;
            BtnSaveRole.Click += BtnSaveRole_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(44, 567);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(1498, 373);
            treeView1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(44, 532);
            label3.Name = "label3";
            label3.Size = new Size(85, 32);
            label3.TabIndex = 17;
            label3.Text = "Perfil:";
            // 
            // BtnSaveRoleComponent
            // 
            BtnSaveRoleComponent.BackColor = Color.ForestGreen;
            BtnSaveRoleComponent.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSaveRoleComponent.ForeColor = SystemColors.ButtonHighlight;
            BtnSaveRoleComponent.Location = new Point(45, 948);
            BtnSaveRoleComponent.Margin = new Padding(4, 5, 4, 5);
            BtnSaveRoleComponent.Name = "BtnSaveRoleComponent";
            BtnSaveRoleComponent.Size = new Size(209, 49);
            BtnSaveRoleComponent.TabIndex = 18;
            BtnSaveRoleComponent.Text = "Guardar perfil";
            BtnSaveRoleComponent.UseVisualStyleBackColor = false;
            BtnSaveRoleComponent.Click += BtnSaveRoleComponent_Click;
            // 
            // FrmManageProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1796, 1060);
            Controls.Add(BtnSaveRoleComponent);
            Controls.Add(label3);
            Controls.Add(treeView1);
            Controls.Add(groupBox1);
            Controls.Add(GPPermission);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmManageProfile";
            Text = "FrmManageProfile";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmManageProfile_FormClosed;
            Load += FrmManageProfile_Load;
            GPPermission.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GPPermission;
        private GroupBox groupBox1;
        private TreeView treeView1;
        private Label label3;
        private GroupBox groupBox2;
        private Button BtnSaveRoleComponent;
        private Button BtnSavePermission;
        private Button BtnConfig;
        private Button BtnAddRole;
        private GroupBox groupBox3;
        private Button BtnSaveRole;
        private Button button2;
        private ComboBox CmbPermissions;
        private Button button7;
        private TextBox TxtPermission;
        private ComboBox CmbPermissionType;
        private Label label1;
        private Button BtnDeleteRole;
        private Label label2;
        private Label label4;
        private TextBox TxtRole;
        private Button BtnAddPermission;
        private Button BtnDeletePermission;
        private ComboBox CmbRoles;
        private GroupBox groupBox4;
        private ComboBox CmbUsers;
        private Label label5;
        private Button BtnAssign;
    }
}