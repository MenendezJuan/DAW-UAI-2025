namespace UI
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            statusStrip1 = new StatusStrip();
            userToolStrip = new ToolStripStatusLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            helpProvider = new HelpProvider();
            panel1 = new Panel();
            pnlObjectives = new Panel();
            btnEvaluateObjectives = new Button();
            btnViewAssignedObjectives = new Button();
            btnCreateObjectives = new Button();
            btnObjectives = new Button();
            pnlRecognition = new Panel();
            btnCheckNominationStatus = new Button();
            btnReviewPendingNominations = new Button();
            btnNominateCollaborator = new Button();
            btnRecognition = new Button();
            pnlAdmin = new Panel();
            btnConfigureRewardPolicies = new Button();
            btnConfigureRecognitionCategories = new Button();
            btnCustomizeNominationRules = new Button();
            btnManageBackup = new Button();
            btnManageProducts = new Button();
            btnManageLang = new Button();
            btnManageRoles = new Button();
            btnAdmin = new Button();
            pnlReports = new Panel();
            btnObjectivesReport = new Button();
            btnGenerateRecognitionReport = new Button();
            btnReportProducts = new Button();
            btnReportEvents = new Button();
            btnReport = new Button();
            btnHelp = new Button();
            pnlProducts = new Panel();
            btnViewProducts = new Button();
            btnProducts = new Button();
            pnlPoints = new Panel();
            btnTransferPoints = new Button();
            btnExchangePoints = new Button();
            btnCheckPoints = new Button();
            btnPoints = new Button();
            btnLogout = new Button();
            panel3 = new Panel();
            panel2 = new Panel();
            lblTitle = new Label();
            buttonsPnl = new Panel();
            btnMinimize = new Button();
            btnMaximizeRestore = new Button();
            btnClose = new Button();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            pnlObjectives.SuspendLayout();
            pnlRecognition.SuspendLayout();
            pnlAdmin.SuspendLayout();
            pnlReports.SuspendLayout();
            pnlProducts.SuspendLayout();
            pnlPoints.SuspendLayout();
            panel2.SuspendLayout();
            buttonsPnl.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { userToolStrip, toolStripDropDownButton1 });
            statusStrip1.Location = new Point(0, 911);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1181, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // userToolStrip
            // 
            userToolStrip.Name = "userToolStrip";
            userToolStrip.Size = new Size(199, 25);
            userToolStrip.Text = "Usuario (No conectado)";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(42, 29);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            toolStripDropDownButton1.Click += toolStripDropDownButton1_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(51, 51, 77);
            panel1.Controls.Add(pnlObjectives);
            panel1.Controls.Add(btnObjectives);
            panel1.Controls.Add(pnlRecognition);
            panel1.Controls.Add(btnRecognition);
            panel1.Controls.Add(pnlAdmin);
            panel1.Controls.Add(btnAdmin);
            panel1.Controls.Add(pnlReports);
            panel1.Controls.Add(btnReport);
            panel1.Controls.Add(btnHelp);
            panel1.Controls.Add(pnlProducts);
            panel1.Controls.Add(btnProducts);
            panel1.Controls.Add(pnlPoints);
            panel1.Controls.Add(btnPoints);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 911);
            panel1.TabIndex = 3;
            // 
            // pnlObjectives
            // 
            pnlObjectives.AutoSize = true;
            pnlObjectives.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlObjectives.BackColor = Color.FromArgb(34, 34, 52);
            pnlObjectives.Controls.Add(btnEvaluateObjectives);
            pnlObjectives.Controls.Add(btnViewAssignedObjectives);
            pnlObjectives.Controls.Add(btnCreateObjectives);
            pnlObjectives.Dock = DockStyle.Top;
            pnlObjectives.Location = new Point(0, 1518);
            pnlObjectives.Name = "pnlObjectives";
            pnlObjectives.Size = new Size(357, 171);
            pnlObjectives.TabIndex = 17;
            // 
            // btnEvaluateObjectives
            // 
            btnEvaluateObjectives.BackColor = Color.FromArgb(34, 34, 52);
            btnEvaluateObjectives.Dock = DockStyle.Top;
            btnEvaluateObjectives.FlatAppearance.BorderSize = 0;
            btnEvaluateObjectives.FlatStyle = FlatStyle.Flat;
            btnEvaluateObjectives.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEvaluateObjectives.ForeColor = SystemColors.Control;
            btnEvaluateObjectives.Location = new Point(0, 114);
            btnEvaluateObjectives.Name = "btnEvaluateObjectives";
            btnEvaluateObjectives.Size = new Size(357, 57);
            btnEvaluateObjectives.TabIndex = 8;
            btnEvaluateObjectives.Tag = "MENU_NAME_EVALUATE_OBJECTIVES";
            btnEvaluateObjectives.Text = "Evaluar cumplimiento";
            btnEvaluateObjectives.UseVisualStyleBackColor = false;
            btnEvaluateObjectives.Click += btnEvaluateObjectives_Click;
            // 
            // btnViewAssignedObjectives
            // 
            btnViewAssignedObjectives.BackColor = Color.FromArgb(34, 34, 52);
            btnViewAssignedObjectives.Dock = DockStyle.Top;
            btnViewAssignedObjectives.FlatAppearance.BorderSize = 0;
            btnViewAssignedObjectives.FlatStyle = FlatStyle.Flat;
            btnViewAssignedObjectives.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewAssignedObjectives.ForeColor = SystemColors.Control;
            btnViewAssignedObjectives.Location = new Point(0, 57);
            btnViewAssignedObjectives.Name = "btnViewAssignedObjectives";
            btnViewAssignedObjectives.Size = new Size(357, 57);
            btnViewAssignedObjectives.TabIndex = 7;
            btnViewAssignedObjectives.Tag = "MENU_NAME_VIEW_ASSIGNED_OBJECTIVES";
            btnViewAssignedObjectives.Text = "Consultar objetivos asignados";
            btnViewAssignedObjectives.UseVisualStyleBackColor = false;
            btnViewAssignedObjectives.Click += btnViewAssignedObjectives_Click;
            // 
            // btnCreateObjectives
            // 
            btnCreateObjectives.BackColor = Color.FromArgb(34, 34, 52);
            btnCreateObjectives.Dock = DockStyle.Top;
            btnCreateObjectives.FlatAppearance.BorderSize = 0;
            btnCreateObjectives.FlatStyle = FlatStyle.Flat;
            btnCreateObjectives.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateObjectives.ForeColor = SystemColors.Control;
            btnCreateObjectives.Location = new Point(0, 0);
            btnCreateObjectives.Name = "btnCreateObjectives";
            btnCreateObjectives.Size = new Size(357, 57);
            btnCreateObjectives.TabIndex = 6;
            btnCreateObjectives.Tag = "MENU_NAME_CREATE_OBJECTIVES";
            btnCreateObjectives.Text = "Crear objetivos";
            btnCreateObjectives.UseVisualStyleBackColor = false;
            btnCreateObjectives.Click += btnCreateObjectives_Click;
            // 
            // btnObjectives
            // 
            btnObjectives.Dock = DockStyle.Top;
            btnObjectives.FlatAppearance.BorderSize = 0;
            btnObjectives.FlatStyle = FlatStyle.Flat;
            btnObjectives.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnObjectives.ForeColor = SystemColors.Control;
            btnObjectives.Location = new Point(0, 1461);
            btnObjectives.Name = "btnObjectives";
            btnObjectives.Size = new Size(357, 57);
            btnObjectives.TabIndex = 16;
            btnObjectives.Tag = "MENU_OBJECTIVES";
            btnObjectives.Text = "Objetivos";
            btnObjectives.UseVisualStyleBackColor = true;
            btnObjectives.Click += btnObjectives_Click;
            // 
            // pnlRecognition
            // 
            pnlRecognition.AutoSize = true;
            pnlRecognition.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlRecognition.BackColor = Color.FromArgb(34, 34, 52);
            pnlRecognition.Controls.Add(btnCheckNominationStatus);
            pnlRecognition.Controls.Add(btnReviewPendingNominations);
            pnlRecognition.Controls.Add(btnNominateCollaborator);
            pnlRecognition.Dock = DockStyle.Top;
            pnlRecognition.Location = new Point(0, 1290);
            pnlRecognition.Name = "pnlRecognition";
            pnlRecognition.Size = new Size(357, 171);
            pnlRecognition.TabIndex = 15;
            // 
            // btnCheckNominationStatus
            // 
            btnCheckNominationStatus.BackColor = Color.FromArgb(34, 34, 52);
            btnCheckNominationStatus.Dock = DockStyle.Top;
            btnCheckNominationStatus.FlatAppearance.BorderSize = 0;
            btnCheckNominationStatus.FlatStyle = FlatStyle.Flat;
            btnCheckNominationStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckNominationStatus.ForeColor = SystemColors.Control;
            btnCheckNominationStatus.Location = new Point(0, 114);
            btnCheckNominationStatus.Name = "btnCheckNominationStatus";
            btnCheckNominationStatus.Size = new Size(357, 57);
            btnCheckNominationStatus.TabIndex = 8;
            btnCheckNominationStatus.Tag = "MENU_NAME_CHECK_NOMINATION_STATUS";
            btnCheckNominationStatus.Text = "Consultar estado de nominaciones";
            btnCheckNominationStatus.UseVisualStyleBackColor = false;
            btnCheckNominationStatus.Click += btnCheckNominationStatus_Click;
            // 
            // btnReviewPendingNominations
            // 
            btnReviewPendingNominations.BackColor = Color.FromArgb(34, 34, 52);
            btnReviewPendingNominations.Dock = DockStyle.Top;
            btnReviewPendingNominations.FlatAppearance.BorderSize = 0;
            btnReviewPendingNominations.FlatStyle = FlatStyle.Flat;
            btnReviewPendingNominations.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReviewPendingNominations.ForeColor = SystemColors.Control;
            btnReviewPendingNominations.Location = new Point(0, 57);
            btnReviewPendingNominations.Name = "btnReviewPendingNominations";
            btnReviewPendingNominations.Size = new Size(357, 57);
            btnReviewPendingNominations.TabIndex = 7;
            btnReviewPendingNominations.Tag = "MENU_NAME_REVIEW_PENDING_NOMINATIONS";
            btnReviewPendingNominations.Text = "Revisar nominaciones pendientes";
            btnReviewPendingNominations.UseVisualStyleBackColor = false;
            btnReviewPendingNominations.Click += btnReviewPendingNominations_Click;
            // 
            // btnNominateCollaborator
            // 
            btnNominateCollaborator.BackColor = Color.FromArgb(34, 34, 52);
            btnNominateCollaborator.Dock = DockStyle.Top;
            btnNominateCollaborator.FlatAppearance.BorderSize = 0;
            btnNominateCollaborator.FlatStyle = FlatStyle.Flat;
            btnNominateCollaborator.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNominateCollaborator.ForeColor = SystemColors.Control;
            btnNominateCollaborator.Location = new Point(0, 0);
            btnNominateCollaborator.Name = "btnNominateCollaborator";
            btnNominateCollaborator.Size = new Size(357, 57);
            btnNominateCollaborator.TabIndex = 6;
            btnNominateCollaborator.Tag = "MENU_NAME_NOMINATE_COLLABORATOR";
            btnNominateCollaborator.Text = "Nominar a un colaborador";
            btnNominateCollaborator.UseVisualStyleBackColor = false;
            btnNominateCollaborator.Click += btnNominateCollaborator_Click;
            // 
            // btnRecognition
            // 
            btnRecognition.Dock = DockStyle.Top;
            btnRecognition.FlatAppearance.BorderSize = 0;
            btnRecognition.FlatStyle = FlatStyle.Flat;
            btnRecognition.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecognition.ForeColor = SystemColors.Control;
            btnRecognition.Location = new Point(0, 1233);
            btnRecognition.Name = "btnRecognition";
            btnRecognition.Size = new Size(357, 57);
            btnRecognition.TabIndex = 14;
            btnRecognition.Tag = "MENU_RECOGNITION";
            btnRecognition.Text = "Reconocimientos";
            btnRecognition.UseVisualStyleBackColor = true;
            btnRecognition.Click += btnRecognition_Click;
            // 
            // pnlAdmin
            // 
            pnlAdmin.AutoSize = true;
            pnlAdmin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlAdmin.BackColor = Color.FromArgb(34, 34, 52);
            pnlAdmin.Controls.Add(btnConfigureRewardPolicies);
            pnlAdmin.Controls.Add(btnConfigureRecognitionCategories);
            pnlAdmin.Controls.Add(btnCustomizeNominationRules);
            pnlAdmin.Controls.Add(btnManageBackup);
            pnlAdmin.Controls.Add(btnManageProducts);
            pnlAdmin.Controls.Add(btnManageLang);
            pnlAdmin.Controls.Add(btnManageRoles);
            pnlAdmin.Dock = DockStyle.Top;
            pnlAdmin.Location = new Point(0, 834);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(357, 399);
            pnlAdmin.TabIndex = 13;
            // 
            // btnConfigureRewardPolicies
            // 
            btnConfigureRewardPolicies.BackColor = Color.FromArgb(34, 34, 52);
            btnConfigureRewardPolicies.Dock = DockStyle.Top;
            btnConfigureRewardPolicies.FlatAppearance.BorderSize = 0;
            btnConfigureRewardPolicies.FlatStyle = FlatStyle.Flat;
            btnConfigureRewardPolicies.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfigureRewardPolicies.ForeColor = SystemColors.Control;
            btnConfigureRewardPolicies.Location = new Point(0, 342);
            btnConfigureRewardPolicies.Name = "btnConfigureRewardPolicies";
            btnConfigureRewardPolicies.Size = new Size(357, 57);
            btnConfigureRewardPolicies.TabIndex = 12;
            btnConfigureRewardPolicies.Tag = "MENU_NAME_CONFIGURE_REWARD_POLICIES";
            btnConfigureRewardPolicies.Text = "Políticas de recompensa";
            btnConfigureRewardPolicies.UseVisualStyleBackColor = false;
            btnConfigureRewardPolicies.Click += btnConfigureRewardPolicies_Click;
            // 
            // btnConfigureRecognitionCategories
            // 
            btnConfigureRecognitionCategories.BackColor = Color.FromArgb(34, 34, 52);
            btnConfigureRecognitionCategories.Dock = DockStyle.Top;
            btnConfigureRecognitionCategories.FlatAppearance.BorderSize = 0;
            btnConfigureRecognitionCategories.FlatStyle = FlatStyle.Flat;
            btnConfigureRecognitionCategories.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfigureRecognitionCategories.ForeColor = SystemColors.Control;
            btnConfigureRecognitionCategories.Location = new Point(0, 285);
            btnConfigureRecognitionCategories.Name = "btnConfigureRecognitionCategories";
            btnConfigureRecognitionCategories.Size = new Size(357, 57);
            btnConfigureRecognitionCategories.TabIndex = 11;
            btnConfigureRecognitionCategories.Tag = "MENU_NAME_CONFIGURE_RECOGNITION_CATEGORIES";
            btnConfigureRecognitionCategories.Text = "Categorias reconocimiento";
            btnConfigureRecognitionCategories.UseVisualStyleBackColor = false;
            btnConfigureRecognitionCategories.Click += btnConfigureRecognitionCategories_Click;
            // 
            // btnCustomizeNominationRules
            // 
            btnCustomizeNominationRules.BackColor = Color.FromArgb(34, 34, 52);
            btnCustomizeNominationRules.Dock = DockStyle.Top;
            btnCustomizeNominationRules.FlatAppearance.BorderSize = 0;
            btnCustomizeNominationRules.FlatStyle = FlatStyle.Flat;
            btnCustomizeNominationRules.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCustomizeNominationRules.ForeColor = SystemColors.Control;
            btnCustomizeNominationRules.Location = new Point(0, 228);
            btnCustomizeNominationRules.Name = "btnCustomizeNominationRules";
            btnCustomizeNominationRules.Size = new Size(357, 57);
            btnCustomizeNominationRules.TabIndex = 10;
            btnCustomizeNominationRules.Tag = "MENU_NAME_CUSTOMIZE_NOMINATION_RULES";
            btnCustomizeNominationRules.Text = "Personalizar reglas de nominación";
            btnCustomizeNominationRules.UseVisualStyleBackColor = false;
            btnCustomizeNominationRules.Click += btnCustomizeNominationRules_Click;
            // 
            // btnManageBackup
            // 
            btnManageBackup.BackColor = Color.FromArgb(34, 34, 52);
            btnManageBackup.Dock = DockStyle.Top;
            btnManageBackup.FlatAppearance.BorderSize = 0;
            btnManageBackup.FlatStyle = FlatStyle.Flat;
            btnManageBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageBackup.ForeColor = SystemColors.Control;
            btnManageBackup.Location = new Point(0, 171);
            btnManageBackup.Name = "btnManageBackup";
            btnManageBackup.Size = new Size(357, 57);
            btnManageBackup.TabIndex = 9;
            btnManageBackup.Tag = "MANAGE_BACKUP";
            btnManageBackup.Text = "Gestionar Backup";
            btnManageBackup.UseVisualStyleBackColor = false;
            btnManageBackup.Click += btnManageBackup_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.FromArgb(34, 34, 52);
            btnManageProducts.Dock = DockStyle.Top;
            btnManageProducts.FlatAppearance.BorderSize = 0;
            btnManageProducts.FlatStyle = FlatStyle.Flat;
            btnManageProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageProducts.ForeColor = SystemColors.Control;
            btnManageProducts.Location = new Point(0, 114);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(357, 57);
            btnManageProducts.TabIndex = 8;
            btnManageProducts.Tag = "MANAGE_PRODUCTS";
            btnManageProducts.Text = "Gestionar productos";
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += btnManageProducts_Click;
            // 
            // btnManageLang
            // 
            btnManageLang.BackColor = Color.FromArgb(34, 34, 52);
            btnManageLang.Dock = DockStyle.Top;
            btnManageLang.FlatAppearance.BorderSize = 0;
            btnManageLang.FlatStyle = FlatStyle.Flat;
            btnManageLang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageLang.ForeColor = SystemColors.Control;
            btnManageLang.Location = new Point(0, 57);
            btnManageLang.Name = "btnManageLang";
            btnManageLang.Size = new Size(357, 57);
            btnManageLang.TabIndex = 7;
            btnManageLang.Tag = "MANAGE_LANGUAGE";
            btnManageLang.Text = "Gestionar idioma";
            btnManageLang.UseVisualStyleBackColor = false;
            btnManageLang.Click += btnManageLang_Click;
            // 
            // btnManageRoles
            // 
            btnManageRoles.BackColor = Color.FromArgb(34, 34, 52);
            btnManageRoles.Dock = DockStyle.Top;
            btnManageRoles.FlatAppearance.BorderSize = 0;
            btnManageRoles.FlatStyle = FlatStyle.Flat;
            btnManageRoles.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageRoles.ForeColor = SystemColors.Control;
            btnManageRoles.Location = new Point(0, 0);
            btnManageRoles.Name = "btnManageRoles";
            btnManageRoles.Size = new Size(357, 57);
            btnManageRoles.TabIndex = 6;
            btnManageRoles.Tag = "MANAGE_ROLES";
            btnManageRoles.Text = "Gestionar perfiles";
            btnManageRoles.UseVisualStyleBackColor = false;
            btnManageRoles.Click += btnManageRoles_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Dock = DockStyle.Top;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdmin.ForeColor = SystemColors.Control;
            btnAdmin.Location = new Point(0, 777);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(357, 57);
            btnAdmin.TabIndex = 12;
            btnAdmin.Tag = "MENU_ADMIN";
            btnAdmin.Text = "Configuración";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // pnlReports
            // 
            pnlReports.AutoSize = true;
            pnlReports.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlReports.BackColor = Color.FromArgb(34, 34, 52);
            pnlReports.Controls.Add(btnObjectivesReport);
            pnlReports.Controls.Add(btnGenerateRecognitionReport);
            pnlReports.Controls.Add(btnReportProducts);
            pnlReports.Controls.Add(btnReportEvents);
            pnlReports.Dock = DockStyle.Top;
            pnlReports.Location = new Point(0, 549);
            pnlReports.Name = "pnlReports";
            pnlReports.Size = new Size(357, 228);
            pnlReports.TabIndex = 11;
            // 
            // btnObjectivesReport
            // 
            btnObjectivesReport.BackColor = Color.FromArgb(34, 34, 52);
            btnObjectivesReport.Dock = DockStyle.Top;
            btnObjectivesReport.FlatAppearance.BorderSize = 0;
            btnObjectivesReport.FlatStyle = FlatStyle.Flat;
            btnObjectivesReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnObjectivesReport.ForeColor = SystemColors.Control;
            btnObjectivesReport.Location = new Point(0, 171);
            btnObjectivesReport.Name = "btnObjectivesReport";
            btnObjectivesReport.Size = new Size(357, 57);
            btnObjectivesReport.TabIndex = 9;
            btnObjectivesReport.Tag = "MENU_REPORT_OBJECTIVES";
            btnObjectivesReport.Text = "Bitácora de objetivos";
            btnObjectivesReport.UseVisualStyleBackColor = false;
            btnObjectivesReport.Click += btnObjectivesReport_Click;
            // 
            // btnGenerateRecognitionReport
            // 
            btnGenerateRecognitionReport.BackColor = Color.FromArgb(34, 34, 52);
            btnGenerateRecognitionReport.Dock = DockStyle.Top;
            btnGenerateRecognitionReport.FlatAppearance.BorderSize = 0;
            btnGenerateRecognitionReport.FlatStyle = FlatStyle.Flat;
            btnGenerateRecognitionReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateRecognitionReport.ForeColor = SystemColors.Control;
            btnGenerateRecognitionReport.Location = new Point(0, 114);
            btnGenerateRecognitionReport.Name = "btnGenerateRecognitionReport";
            btnGenerateRecognitionReport.Size = new Size(357, 57);
            btnGenerateRecognitionReport.TabIndex = 8;
            btnGenerateRecognitionReport.Tag = "MENU_NAME_GENERATE_RECOGNITION_REPORT";
            btnGenerateRecognitionReport.Text = "Bitácora de reconocimientos";
            btnGenerateRecognitionReport.UseVisualStyleBackColor = false;
            btnGenerateRecognitionReport.Click += btnGenerateRecognitionReport_Click;
            // 
            // btnReportProducts
            // 
            btnReportProducts.BackColor = Color.FromArgb(34, 34, 52);
            btnReportProducts.Dock = DockStyle.Top;
            btnReportProducts.FlatAppearance.BorderSize = 0;
            btnReportProducts.FlatStyle = FlatStyle.Flat;
            btnReportProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportProducts.ForeColor = SystemColors.Control;
            btnReportProducts.Location = new Point(0, 57);
            btnReportProducts.Name = "btnReportProducts";
            btnReportProducts.Size = new Size(357, 57);
            btnReportProducts.TabIndex = 7;
            btnReportProducts.Tag = "";
            btnReportProducts.Text = "Bitácora productos";
            btnReportProducts.UseVisualStyleBackColor = false;
            btnReportProducts.Click += btnReportProducts_Click;
            // 
            // btnReportEvents
            // 
            btnReportEvents.BackColor = Color.FromArgb(34, 34, 52);
            btnReportEvents.Dock = DockStyle.Top;
            btnReportEvents.FlatAppearance.BorderSize = 0;
            btnReportEvents.FlatStyle = FlatStyle.Flat;
            btnReportEvents.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportEvents.ForeColor = SystemColors.Control;
            btnReportEvents.Location = new Point(0, 0);
            btnReportEvents.Name = "btnReportEvents";
            btnReportEvents.Size = new Size(357, 57);
            btnReportEvents.TabIndex = 6;
            btnReportEvents.Tag = "";
            btnReportEvents.Text = "Bitácora eventos";
            btnReportEvents.UseVisualStyleBackColor = false;
            btnReportEvents.Click += btnReportEvents_Click;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReport.ForeColor = SystemColors.Control;
            btnReport.Location = new Point(0, 492);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(357, 57);
            btnReport.TabIndex = 10;
            btnReport.Tag = "MENU_REPORTS";
            btnReport.Text = "Reportería";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnHelp
            // 
            btnHelp.Dock = DockStyle.Bottom;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHelp.ForeColor = SystemColors.Control;
            btnHelp.Location = new Point(0, 1689);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(357, 57);
            btnHelp.TabIndex = 9;
            btnHelp.Tag = "MENU_HELP";
            btnHelp.Text = "Ayuda";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // pnlProducts
            // 
            pnlProducts.AutoSize = true;
            pnlProducts.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlProducts.BackColor = Color.FromArgb(34, 34, 52);
            pnlProducts.Controls.Add(btnViewProducts);
            pnlProducts.Dock = DockStyle.Top;
            pnlProducts.Location = new Point(0, 435);
            pnlProducts.Name = "pnlProducts";
            pnlProducts.Size = new Size(357, 57);
            pnlProducts.TabIndex = 8;
            // 
            // btnViewProducts
            // 
            btnViewProducts.BackColor = Color.FromArgb(34, 34, 52);
            btnViewProducts.Dock = DockStyle.Top;
            btnViewProducts.FlatAppearance.BorderSize = 0;
            btnViewProducts.FlatStyle = FlatStyle.Flat;
            btnViewProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewProducts.ForeColor = SystemColors.Control;
            btnViewProducts.Location = new Point(0, 0);
            btnViewProducts.Name = "btnViewProducts";
            btnViewProducts.Size = new Size(357, 57);
            btnViewProducts.TabIndex = 6;
            btnViewProducts.Tag = "MENU_VIEW_PRODUCTS";
            btnViewProducts.Text = "Ver productos";
            btnViewProducts.UseVisualStyleBackColor = false;
            btnViewProducts.Click += btnViewProducts_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackgroundImageLayout = ImageLayout.Zoom;
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = SystemColors.Control;
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(0, 378);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(357, 57);
            btnProducts.TabIndex = 7;
            btnProducts.Tag = "MENU_PRODUCTS";
            btnProducts.Text = "Catalogo";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // pnlPoints
            // 
            pnlPoints.AutoSize = true;
            pnlPoints.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlPoints.BackColor = Color.FromArgb(34, 34, 52);
            pnlPoints.Controls.Add(btnTransferPoints);
            pnlPoints.Controls.Add(btnExchangePoints);
            pnlPoints.Controls.Add(btnCheckPoints);
            pnlPoints.Dock = DockStyle.Top;
            pnlPoints.Location = new Point(0, 207);
            pnlPoints.Name = "pnlPoints";
            pnlPoints.Size = new Size(357, 171);
            pnlPoints.TabIndex = 6;
            // 
            // btnTransferPoints
            // 
            btnTransferPoints.BackColor = Color.FromArgb(34, 34, 52);
            btnTransferPoints.Dock = DockStyle.Top;
            btnTransferPoints.FlatAppearance.BorderSize = 0;
            btnTransferPoints.FlatStyle = FlatStyle.Flat;
            btnTransferPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransferPoints.ForeColor = SystemColors.Control;
            btnTransferPoints.Location = new Point(0, 114);
            btnTransferPoints.Name = "btnTransferPoints";
            btnTransferPoints.Size = new Size(357, 57);
            btnTransferPoints.TabIndex = 8;
            btnTransferPoints.Tag = "MENU_TRANSFER_POINTS";
            btnTransferPoints.Text = "Transferir puntos";
            btnTransferPoints.UseVisualStyleBackColor = false;
            btnTransferPoints.Click += btnTransferPoints_Click;
            // 
            // btnExchangePoints
            // 
            btnExchangePoints.BackColor = Color.FromArgb(34, 34, 52);
            btnExchangePoints.Dock = DockStyle.Top;
            btnExchangePoints.FlatAppearance.BorderSize = 0;
            btnExchangePoints.FlatStyle = FlatStyle.Flat;
            btnExchangePoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExchangePoints.ForeColor = SystemColors.Control;
            btnExchangePoints.Location = new Point(0, 57);
            btnExchangePoints.Name = "btnExchangePoints";
            btnExchangePoints.Size = new Size(357, 57);
            btnExchangePoints.TabIndex = 7;
            btnExchangePoints.Tag = "MENU_EXCHANGE_POINTS";
            btnExchangePoints.Text = "Canjear puntos";
            btnExchangePoints.UseVisualStyleBackColor = false;
            btnExchangePoints.Click += btnExchangePoints_Click;
            // 
            // btnCheckPoints
            // 
            btnCheckPoints.BackColor = Color.FromArgb(34, 34, 52);
            btnCheckPoints.Dock = DockStyle.Top;
            btnCheckPoints.FlatAppearance.BorderSize = 0;
            btnCheckPoints.FlatStyle = FlatStyle.Flat;
            btnCheckPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckPoints.ForeColor = SystemColors.Control;
            btnCheckPoints.Location = new Point(0, 0);
            btnCheckPoints.Name = "btnCheckPoints";
            btnCheckPoints.Size = new Size(357, 57);
            btnCheckPoints.TabIndex = 6;
            btnCheckPoints.Tag = "MENU_CHECK_POINTS";
            btnCheckPoints.Text = "Consultar puntos";
            btnCheckPoints.UseVisualStyleBackColor = false;
            btnCheckPoints.Click += btnCheckPoints_Click;
            // 
            // btnPoints
            // 
            btnPoints.Dock = DockStyle.Top;
            btnPoints.FlatAppearance.BorderSize = 0;
            btnPoints.FlatStyle = FlatStyle.Flat;
            btnPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPoints.ForeColor = SystemColors.Control;
            btnPoints.Location = new Point(0, 150);
            btnPoints.Name = "btnPoints";
            btnPoints.Size = new Size(357, 57);
            btnPoints.TabIndex = 5;
            btnPoints.Tag = "MENU_POINTS";
            btnPoints.Text = "Puntos";
            btnPoints.UseVisualStyleBackColor = true;
            btnPoints.Click += btnPoints_Click;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.Control;
            btnLogout.Location = new Point(0, 1746);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(357, 57);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Cerrar sesión";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(38, 39, 59);
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(357, 150);
            panel3.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AllowDrop = true;
            panel2.BackColor = Color.FromArgb(15, 66, 11);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(buttonsPnl);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(383, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(798, 153);
            panel2.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.Control;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 45);
            lblTitle.TabIndex = 1;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonsPnl
            // 
            buttonsPnl.Controls.Add(btnMinimize);
            buttonsPnl.Controls.Add(btnMaximizeRestore);
            buttonsPnl.Controls.Add(btnClose);
            buttonsPnl.Dock = DockStyle.Right;
            buttonsPnl.Location = new Point(624, 0);
            buttonsPnl.Name = "buttonsPnl";
            buttonsPnl.Size = new Size(174, 153);
            buttonsPnl.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = SystemColors.ButtonFace;
            btnMinimize.Location = new Point(78, 12);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(39, 34);
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "__";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnMaximizeRestore
            // 
            btnMaximizeRestore.FlatAppearance.BorderSize = 0;
            btnMaximizeRestore.FlatStyle = FlatStyle.Flat;
            btnMaximizeRestore.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMaximizeRestore.ForeColor = SystemColors.ButtonFace;
            btnMaximizeRestore.Location = new Point(123, 52);
            btnMaximizeRestore.Name = "btnMaximizeRestore";
            btnMaximizeRestore.Size = new Size(39, 34);
            btnMaximizeRestore.TabIndex = 1;
            btnMaximizeRestore.Text = "🗗";
            btnMaximizeRestore.UseVisualStyleBackColor = false;
            btnMaximizeRestore.Visible = false;
            btnMaximizeRestore.Click += btnMaximizeRestore_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ButtonFace;
            btnClose.Location = new Point(123, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(39, 34);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1181, 943);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIFRE";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrincipal_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlObjectives.ResumeLayout(false);
            pnlRecognition.ResumeLayout(false);
            pnlAdmin.ResumeLayout(false);
            pnlReports.ResumeLayout(false);
            pnlProducts.ResumeLayout(false);
            pnlPoints.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            buttonsPnl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel userToolStrip;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem bitacoraEventosToolStripMenuItem1;
        private HelpProvider helpProvider;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel buttonsPnl;
        private Button btnClose;
        private Button btnMinimize;
        private Button btnMaximizeRestore;
        private Button btnLogout;
        private Button btnProducts;
        private Panel pnlPoints;
        private Button btnExchangePoints;
        private Button btnCheckPoints;
        private Button btnPoints;
        private Button btnHelp;
        private Panel pnlProducts;
        private Button btnViewProducts;
        private Button btnReport;
        private Panel pnlReports;
        private Button btnReportProducts;
        private Button btnReportEvents;
        private Button btnTransferPoints;
        private Button btnAdmin;
        private Panel pnlAdmin;
        private Button btnManageLang;
        private Button btnManageRoles;
        private Button btnManageBackup;
        private Button btnManageProducts;
        private Label lblTitle;
        private Button btnRecognition;
        private Panel pnlObjectives;
        private Button btnViewAssignedObjectives;
        private Button btnCreateObjectives;
        private Button btnObjectives;
        private Panel pnlRecognition;
        private Button btnReviewPendingNominations;
        private Button btnNominateCollaborator;
        private Button btnCustomizeNominationRules;
        private Button btnCheckNominationStatus;
        private Button btnConfigureRecognitionCategories;
        private Button btnGenerateRecognitionReport;
        private Button btnObjectivesReport;
        private Button btnEvaluateObjectives;
        private Button btnConfigureRewardPolicies;
    }
}