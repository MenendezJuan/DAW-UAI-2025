using Infrastructure.Session;
using Microsoft.Extensions.DependencyInjection;
using UI.Login;
using BE.Enums;
using UI.Language;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Observer;
using UI.Profiles;
using UI.Mantainers;
using UI.Points;
using BE.DTO;
using UI.Backup;
using UI.Logs;
using System.Runtime.InteropServices;
using UI.Recognitions;
using UI.Objectives;

namespace UI
{
    public partial class FrmPrincipal : Form, IObserverForm
    {
        //Puntos
        FrmExchangePoints? frmExchangePoints = null;
        FrmPoints? frmPoints = null;
        FrmTransferPoints? frmTransferPoints = null;


        //Productos
        FrmViewProducts? frmViewProducts = null;

        //Reportes
        FrmEventsLogs? frmEventsLogs = null;
        FrmProductsLogs? frmProductsLogs = null;
        FrmObjectiveLogs? frmObjectiveLogs = null;
        FrmRecognitionLogs? frmRecognitionLogs = null;

        //Admin
        FrmManageProfile? frmManageProfile = null;
        FrmManageLanguage? frmManageLanguage = null;
        FrmAddProducts? frmAddProducts = null;
        FrmBackup? frmBackup = null;
        FrmConfigureRewardPolicies? frmConfigureRewardPolicies = null;
        FrmConfigureRecognitionCategories? frmConfigureRecognitionCategories = null;
        FrmManageNominationRules? frmManageNominationRules = null;

        //Objetivos
        FrmCheckObjectives? frmCheckObjectives = null;
        FrmCreateObjectives? frmCreateObjectives = null;
        FrmEvaluateObjectives? frmEvaluateObjectives = null;

        //Reconocimiento
        FrmCheckNominationStatus? frmCheckNominationStatus = null;
        FrmNominateCollaborator? frmNominateCollaborator = null;
        FrmReviewPendingNominations? frmReviewPendingNominations = null;

        ILanguageBLL languageBLL;
        IUserBLL userBLL;
        private System.Windows.Forms.Timer clickTimer; // Temporizador para diferenciar entre clic simple y doble

        public FrmPrincipal(ILanguageBLL languageBLL, IUserBLL userBLL)
        {
            Logout = delegate { };
            this.languageBLL = languageBLL;
            InitializeComponent();
            this.userBLL = userBLL;
            InitializeHelpProvider();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(F1_KeyDown!);
            this.AutoScaleMode = AutoScaleMode.None;
            // Configurar el temporizador
            clickTimer = new System.Windows.Forms.Timer();
            clickTimer.Interval = 200; // Tiempo para diferenciar entre clic simple y doble (ajustable)
            clickTimer.Tick += ClickTimer_Tick!;
        }

        private void F1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                string helpFilePath = btnAdmin.Visible && btnAdmin.Enabled ? System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "SIFRE-A.chm") : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "SIFRE.chm");
                helpProvider.HelpNamespace = helpFilePath;
                Help.ShowHelp(this, helpProvider.HelpNamespace);
                e.Handled = true;
            }
        }
        private void InitializeHelpProvider()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnHelp, "Abre el módulo de ayuda para esta aplicación.");
            toolTip.SetToolTip(btnAdmin, "Accede a las opciones de administración.");
            toolTip.SetToolTip(btnPoints, "Accede a las opciones de puntos.");
            toolTip.SetToolTip(btnProducts, "Accede a las opciones de productos.");
            toolTip.SetToolTip(btnReport, "Accede a las opciones de reportes y estadísticas.");
            toolTip.SetToolTip(btnLogout, "Cierra la sesión actual.");
            toolTip.SetToolTip(btnClose, "Cierra la aplicación.");
            toolTip.SetToolTip(btnMaximizeRestore, "Maximiza o restaura la ventana.");
            toolTip.SetToolTip(btnMinimize, "Minimiza la ventana.");
            toolTip.SetToolTip(btnManageRoles, "Gestiona los perfiles de usuario.");
            toolTip.SetToolTip(btnManageLang, "Configura el idioma de la aplicación.");
            toolTip.SetToolTip(btnManageProducts, "Gestiona los productos disponibles.");
            toolTip.SetToolTip(btnManageBackup, "Realiza copias de seguridad de los datos.");
            toolTip.SetToolTip(btnCheckPoints, "Consulta tus puntos acumulados.");
            toolTip.SetToolTip(btnExchangePoints, "Canjea tus puntos por productos o recompensas.");
            toolTip.SetToolTip(btnViewProducts, "Visualiza los productos disponibles.");
            toolTip.SetToolTip(btnReportEvents, "Consulta la bitácora de eventos del sistema.");
            toolTip.SetToolTip(btnReportProducts, "Consulta la bitácora de movimientos de productos.");
            toolTip.SetToolTip(btnTransferPoints, "Transfiere puntos a otro colaborador.");
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        public void Login()
        {
            // Admin
            btnManageLang.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CAMBIAR_IDIOMA);
            btnManageRoles.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.GESTIONAR_PERFIL);
            btnManageProducts.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.GESTIONAR_PRODUCTOS);
            btnManageBackup.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.GESTIONAR_BACKUP);
            btnCustomizeNominationRules.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CUSTOMIZAR_REGLAS_NOMINACION);
            btnConfigureRecognitionCategories.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CONFIGURAR_CATEGORIAS_RECONOCIMIENTO);
            btnConfigureRewardPolicies.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CONFIGURAR_POLITICAS_RECOMPENSA);

            // Puntos
            btnTransferPoints.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CANJEAR_PUNTOS);
            btnExchangePoints.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CANJEAR_PUNTOS);
            btnCheckPoints.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CONSULTAR_PUNTOS);

            // Reporteria
            btnReport.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.VER_REPORTERIA);
            btnReportEvents.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.BITACORA_EVENTOS);
            btnReportProducts.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.BITACORA_PRODUCTOS);
            btnGenerateRecognitionReport.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.GENERAR_REPORTE_RECONOCIMIENTO);

            // Producto
            btnViewProducts.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.VER_PRODUCTOS);

            // Ayuda
            btnHelp.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.VER_AYUDA);

            // Reconocimiento
            btnRecognition.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.VER_RECONOCIMIENTO);
            btnNominateCollaborator.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.NOMINAR_COLABORADOR);
            btnReviewPendingNominations.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.REVISAR_NOMINACIONES_PENDIENTES);
            btnCheckNominationStatus.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CONSULTAR_ESTADO_NOMINACION);

            // Objetivos
            btnObjectives.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.VER_OBJETIVOS);
            btnCreateObjectives.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.CREAR_OBJETIVOS);
            btnViewAssignedObjectives.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.VER_OBJETIVOS_ASIGNADOS);
            btnEvaluateObjectives.Enabled = SingletonSession.Instancia.IsInRole(PermissionsType.EVALUAR_OBJETIVOS);

            btnAdmin.Visible = btnManageLang.Enabled || btnManageRoles.Enabled || btnManageProducts.Enabled || btnManageBackup.Enabled || btnCustomizeNominationRules.Enabled || btnConfigureRecognitionCategories.Enabled || btnConfigureRewardPolicies.Enabled;
            btnPoints.Visible = btnCheckPoints.Enabled || btnExchangePoints.Enabled || btnTransferPoints.Enabled;
            btnProducts.Visible = btnViewProducts.Enabled;
            btnReport.Visible = btnReportEvents.Enabled || btnReportProducts.Enabled || btnGenerateRecognitionReport.Enabled || btnObjectivesReport.Enabled;
            btnRecognition.Visible = btnRecognition.Enabled || btnNominateCollaborator.Enabled || btnReviewPendingNominations.Enabled || btnCheckNominationStatus.Enabled;
            btnObjectives.Visible = btnObjectives.Enabled || btnCreateObjectives.Enabled || btnViewAssignedObjectives.Enabled || btnEvaluateObjectives.Enabled;

            btnLogout.Visible = true;
            userToolStrip.Text = $"Usuario {SingletonSession.Instancia.User.Username} conectado";
            string helpFilePath = btnAdmin.Enabled ? System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "SIFRE-A.chm") : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "SIFRE.chm");
            helpProvider.HelpNamespace = helpFilePath;

            SingletonSession.Instancia.AddObserver(this);
        }
        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmLogin frmLogin = Program.ServiceProvider.GetRequiredService<FrmLogin>())
            {
                DialogResult result = frmLogin.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Login();
                }
            }
        }

        public event EventHandler Logout;

        private void CloseForms()
        {
            //Admin Forms
            if (frmBackup != null)
            {
                frmBackup.Dispose();
                frmBackup.Close();
                frmBackup = null;
            }
            if (frmManageLanguage != null)
            {
                frmManageLanguage.Dispose();
                frmManageLanguage.Close();
                frmManageLanguage = null;
            }
            if (frmManageProfile != null)
            {
                frmManageProfile.Dispose();
                frmManageProfile.Close();
                frmManageProfile = null;
            }
            if (frmAddProducts != null)
            {
                frmAddProducts.Dispose();
                frmAddProducts.Close();
                frmAddProducts = null;
            }
            if (frmConfigureRewardPolicies != null)
            {
                frmConfigureRewardPolicies.Dispose();
                frmConfigureRewardPolicies.Close();
                frmConfigureRewardPolicies = null;
            }
            if (frmConfigureRecognitionCategories != null)
            {
                frmConfigureRecognitionCategories.Dispose();
                frmConfigureRecognitionCategories.Close();
                frmConfigureRecognitionCategories = null;
            }
            if (frmManageNominationRules != null)
            {
                frmManageNominationRules.Dispose();
                frmManageNominationRules.Close();
                frmManageNominationRules = null;
            }

            //Products Forms
            if (frmViewProducts != null)
            {
                frmViewProducts.Dispose();
                frmViewProducts.Close();
                frmViewProducts = null;
            }

            //Reports Forms
            if (frmProductsLogs != null)
            {
                frmProductsLogs.Dispose();
                frmProductsLogs.Close();
                frmProductsLogs = null;
            }
            if (frmEventsLogs != null)
            {
                frmEventsLogs.Dispose();
                frmEventsLogs.Close();
                frmEventsLogs = null;
            }
            if (frmObjectiveLogs != null)
            {
                frmObjectiveLogs.Dispose();
                frmObjectiveLogs.Close();
                frmObjectiveLogs = null;
            }
            if (frmRecognitionLogs != null)
            {
                frmRecognitionLogs.Dispose();
                frmRecognitionLogs.Close();
                frmRecognitionLogs = null;
            }

            //Points Forms
            if (frmExchangePoints != null)
            {
                frmExchangePoints.Dispose();
                frmExchangePoints.Close();
                frmExchangePoints = null;
            }
            if (frmPoints != null)
            {
                frmPoints.Dispose();
                frmPoints.Close();
                frmPoints = null;
            }
            if (frmTransferPoints != null)
            {
                frmTransferPoints.Dispose();
                frmTransferPoints.Close();
                frmTransferPoints = null;
            }

            //Recognition Forms
            if (frmCheckNominationStatus != null)
            {
                frmCheckNominationStatus.Dispose();
                frmCheckNominationStatus.Close();
                frmCheckNominationStatus = null;
            }
            if (frmNominateCollaborator != null)
            {
                frmNominateCollaborator.Dispose();
                frmNominateCollaborator.Close();
                frmNominateCollaborator = null;
            }
            if (frmReviewPendingNominations != null)
            {
                frmReviewPendingNominations.Dispose();
                frmReviewPendingNominations.Close();
                frmReviewPendingNominations = null;
            }

            //Objectives Forms
            if (frmCheckObjectives != null)
            {
                frmCheckObjectives.Dispose();
                frmCheckObjectives.Close();
                frmCheckObjectives = null;
            }
            if (frmCreateObjectives != null)
            {
                frmCreateObjectives.Dispose();
                frmCreateObjectives.Close();
                frmCreateObjectives = null;
            }
            if (frmEvaluateObjectives != null)
            {
                frmEvaluateObjectives.Dispose();
                frmEvaluateObjectives.Close();
                frmEvaluateObjectives = null;
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            toolStripDropDownButton1.DropDownItems.Clear();
            var languages = languageBLL.GetAllLanguages();

            foreach (var language in languages)
            {
                var item = new ToolStripMenuItem(language.Name);
                item.Tag = language.Id;
                item.Click += LanguageItem_Click!;
                toolStripDropDownButton1.DropDownItems.Add(item);
            }
        }

        private void LanguageItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                var languageId = (int)menuItem.Tag!;
                if (SingletonSession.Instancia.User != null)
                {
                    SingletonSession.Instancia.currentLanguage = languageBLL.GetById(languageId, true)!;
                    SingletonSession.Instancia.changeLanguage = true;
                    userBLL.UpdateUserLanguage(SingletonSession.Instancia.User.Id, languageId);
                }
            }
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            clickTimer.Stop();
            btnMaximizeRestore_Click(sender, e);
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            using (FrmLogout frmLogout = new FrmLogout())
            {
                SingletonSession.Instancia.AddObserver(frmLogout);
                DialogResult result = frmLogout.ShowDialog();

                if (result == DialogResult.OK)
                {
                    HideSubMenu();
                    userToolStrip.Text = $"Usuario (No conectado)";
                    this.Close();
                    Logout.Invoke(sender, e);
                    SingletonSession.Instancia.RemoveObserver(frmLogout);

                    SingletonSession.Instancia.RemoveObserver(this);
                    CloseForms();
                }
            }
        }

        private void HideSubMenu()
        {
            pnlPoints.Visible = false;
            pnlProducts.Visible = false;
            pnlReports.Visible = false;
            pnlAdmin.Visible = false;
            pnlObjectives.Visible = false;
            pnlRecognition.Visible = false;
        }

        private void ShowSubMenu(Panel pSubMenu)
        {
            if (pSubMenu.Visible == false)
            {
                HideSubMenu();
                pSubMenu.Visible = true;
            }
            else
            {
                pSubMenu.Visible = false;
            }
        }

        #region "Menu principal click"
        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlProducts);
            btnProducts.Visible = btnViewProducts.Enabled;
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlPoints);
            btnCheckPoints.Visible = btnCheckPoints.Enabled;
            btnExchangePoints.Visible = btnExchangePoints.Enabled;
            btnTransferPoints.Visible = btnTransferPoints.Enabled;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlReports);
            btnReportEvents.Visible = btnReportEvents.Enabled;
            btnReportProducts.Visible = btnReportProducts.Enabled;
            btnGenerateRecognitionReport.Visible = btnGenerateRecognitionReport.Enabled;
            btnObjectivesReport.Visible = btnObjectivesReport.Enabled;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlAdmin);
            btnManageLang.Visible = btnManageLang.Enabled;
            btnManageRoles.Visible = btnManageRoles.Enabled;
            btnManageProducts.Visible = btnManageProducts.Enabled;
            btnManageBackup.Visible = btnManageBackup.Enabled;
            btnCustomizeNominationRules.Visible = btnCustomizeNominationRules.Enabled;
            btnConfigureRecognitionCategories.Visible = btnConfigureRecognitionCategories.Enabled;
            btnConfigureRewardPolicies.Visible = btnConfigureRewardPolicies.Enabled;
        }
        private void btnRecognition_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlRecognition);
            btnGenerateRecognitionReport.Visible = btnGenerateRecognitionReport.Enabled;
            btnCustomizeNominationRules.Visible = btnCustomizeNominationRules.Enabled;
            btnConfigureRecognitionCategories.Visible = btnConfigureRecognitionCategories.Enabled;
            btnConfigureRewardPolicies.Visible = btnConfigureRewardPolicies.Enabled;
            btnNominateCollaborator.Visible = btnNominateCollaborator.Enabled;
            btnReviewPendingNominations.Visible = btnReviewPendingNominations.Enabled;
            btnCheckNominationStatus.Visible = btnCheckNominationStatus.Enabled;
        }

        private void btnObjectives_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlObjectives);
            btnCreateObjectives.Visible = btnCreateObjectives.Enabled;
            btnViewAssignedObjectives.Visible = btnViewAssignedObjectives.Enabled;
            btnEvaluateObjectives.Visible = btnEvaluateObjectives.Enabled;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace);
        }

        #endregion

        #region "Button Clicks"
        private void UpdateTitle(Control button)
        {
            lblTitle.Text = button.Text;
            lblTitle.Tag = button.Tag;
        }

        // Admin
        private void btnManageBackup_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmBackup, sender, e);
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmAddProducts, sender, e);
        }

        private void btnManageLang_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmManageLanguage, sender, e);
        }

        private void btnManageRoles_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmManageProfile, sender, e);
        }

        private void btnCustomizeNominationRules_Click(object sender, EventArgs e)
        {
           OpenForm(ref frmManageNominationRules, sender, e);
        }

        private void btnConfigureRecognitionCategories_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmConfigureRecognitionCategories, sender, e);
        }

        private void btnConfigureRewardPolicies_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmConfigureRewardPolicies, sender, e);
        }

        // Reportes
        private void btnReportProducts_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmProductsLogs, sender, e);
        }

        private void btnReportEvents_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmEventsLogs, sender, e);
        }
        private void btnGenerateRecognitionReport_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmRecognitionLogs, sender, e);
        }

        private void btnObjectivesReport_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmObjectiveLogs, sender, e);
        }

        // Productos
        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmViewProducts, sender, e);
        }

        // Puntos
        private void btnTransferPoints_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmTransferPoints, sender, e);
        }

        private void btnExchangePoints_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmExchangePoints, sender, e);
        }

        private void btnCheckPoints_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmPoints, sender, e);
        }

        // Reconocimiento
        private void btnNominateCollaborator_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmNominateCollaborator, sender, e);
        }
        
        
        private void OpenForm<T>(ref T? formInstance, object sender, EventArgs e) where T : Form, IObserverForm
        {
            CloseForms();
            if (formInstance == null || formInstance.IsDisposed)
            {
            formInstance = Program.ServiceProvider.GetRequiredService<T>();
            SingletonSession.Instancia.AddObserver(formInstance);
            formInstance.FormBorderStyle = FormBorderStyle.None;
            formInstance.Width = this.Width;
            formInstance.Height = this.Height;
            formInstance.Dock = DockStyle.Fill;
            formInstance.MdiParent = this;
            formInstance.Show();
                formInstance.BringToFront();
                formInstance.WindowState = FormWindowState.Minimized;
                formInstance.WindowState = FormWindowState.Maximized;
            }
            else
            {
            formInstance.BringToFront();
            formInstance.WindowState = FormWindowState.Minimized;
            formInstance.WindowState = FormWindowState.Maximized;
            }
            UpdateTitle((Control)sender);
        }

        private void btnReviewPendingNominations_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmReviewPendingNominations, sender, e);
        }

        private void btnCheckNominationStatus_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmCheckNominationStatus, sender, e);
        }

        // Objetivos
        private void btnCreateObjectives_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmCreateObjectives, sender, e);
        }


        private void btnViewAssignedObjectives_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmCheckObjectives, sender, e);
        }

        private void btnEvaluateObjectives_Click(object sender, EventArgs e)
        {
            OpenForm(ref frmEvaluateObjectives, sender, e);
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickTimer.Start();
            }
        }
        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            // Si no ocurre un doble clic, ejecutar el movimiento del formulario
            clickTimer.Stop();
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public void UpdateLanguage(UserSession session)
        {
            UpdateControlTexts(this.Controls, session);
        }
        private void UpdateControlTexts(Control.ControlCollection controls, UserSession session)
        {
            foreach (Control control in controls)
            {
                foreach (TranslationDTO translation in session.currentLanguage.Translations)
                {
                    if (control.Tag != null && control.Tag.ToString() == translation.LabelName)
                    {
                        control.Text = translation.TranslatedText;
                    }
                }

                if (control is MenuStrip menuStrip)
                {
                    UpdateMenuStripItems(menuStrip.Items, session);
                }

                if (control.HasChildren)
                {
                    UpdateControlTexts(control.Controls, session);
                }
            }
        }
        private void UpdateMenuStripItems(ToolStripItemCollection items, UserSession session)
        {
            foreach (ToolStripItem item in items)
            {
                foreach (TranslationDTO translation in session.currentLanguage.Translations)
                {
                    if (item.Tag != null && item.Tag.ToString() == translation.LabelName)
                    {
                        item.Text = translation.TranslatedText;
                    }
                }

                if (item is ToolStripMenuItem toolStripMenuItem)
                {
                    UpdateMenuStripItems(toolStripMenuItem.DropDownItems, session);
                }
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMaximizeRestore_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximizeRestore.Text = "🗗";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximizeRestore.Text = "🗖";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            btnLogout_Click(sender, e);
        }
        #endregion
    }
}
