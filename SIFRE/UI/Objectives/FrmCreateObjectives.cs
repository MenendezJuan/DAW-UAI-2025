using Infrastructure.Session;
using BE.DTO;
using Infrastructure.Observer;
using Infrastructure.Interfaces.BLL;
using BE.Entities;

namespace UI.Objectives
{
    public partial class FrmCreateObjectives : Form, IObserverForm
    {
        private readonly INominationBLL _nominationBLL;
        private readonly IObjectiveBLL _objectiveBLL;
        public FrmCreateObjectives(INominationBLL nominationBLL, IObjectiveBLL objectiveBLL)
        {
            _nominationBLL = nominationBLL;
            _objectiveBLL = objectiveBLL;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Populate ComboBoxes with data
            PopulateComboBoxWithUsers(cmbNominee);
            PopulateComboBoxWithPriorities(cmbPriority);
            PopulateComboBoxWithStatus(cmbStatus);
            PopulateComboBoxWithCategories(cmbCategory);
            PopulateComboBoxWithRewardTypes(cmbRewardPolicy);
        }

        private void PopulateComboBoxWithRewardTypes(ComboBox comboBox)
        {
            var rewardTypes = _objectiveBLL.GetRewardPolicies();
            comboBox.DataSource = rewardTypes;
            comboBox.DisplayMember = "PolicyName";
            comboBox.ValueMember = "Id";
        }

        private Dictionary<int, string> GetObjectiveCategories()
        {
            return new Dictionary<int, string>
            {
                { 1, "Ventas" },
                { 2, "Desarrollo" },
                { 3, "Soporte" },
                { 4, "Marketing" }
            };
        }

        private void PopulateComboBoxWithCategories(ComboBox comboBox)
        {
            var categories = GetObjectiveCategories();
            comboBox.DataSource = new BindingSource(categories, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }
        private Dictionary<int, string> GetObjectiveStatuses()
        {
            return new Dictionary<int, string>
            {
            { 1, "Pendiente" },
            { 2, "En Progreso" },
            { 3, "Completado" },
            { 4, "En Espera" }
            };
        }

        private void PopulateComboBoxWithStatus(ComboBox comboBox)
        {
            var statuses = GetObjectiveStatuses();
            comboBox.DataSource = new BindingSource(statuses, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }


        private Dictionary<int, string> GetObjectivePriorities()
        {
            return new Dictionary<int, string>
            {
            { 1, "Alto" },
            { 2, "Medio" },
            { 3, "Bajo" }
            };
        }
        private void PopulateComboBoxWithPriorities(ComboBox comboBox)
        {
            var priorities = GetObjectivePriorities();
            comboBox.DataSource = new BindingSource(priorities, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        private void PopulateComboBoxWithUsers(ComboBox comboBox)
        {            
            var users = _nominationBLL.GetUsers().Where(u => u.Id != SingletonSession.Instancia.User.Id).ToList();
            comboBox.DataSource = users;
            comboBox.DisplayMember = "FirstName";
            comboBox.ValueMember = "Id";
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

                if (control.HasChildren)
                {
                    UpdateControlTexts(control.Controls, session);
                }
            }
        }

        private void FrmCreateObjectives_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
        }

        private void FrmCreateObjectives_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);

        }

        private void btnClearControls_Click(object sender, EventArgs e)
        {
            txtTitle.Text = String.Empty;
            txtDescription.Text = String.Empty;
            cmbNominee.SelectedIndex = -1;
            cmbPriority.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbRewardPolicy.SelectedIndex = -1;
        }

        private void btnAddObjective_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
            MessageBox.Show("El título es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
            MessageBox.Show("La descripción es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            if (cmbNominee.SelectedIndex == -1)
            {
            MessageBox.Show("Debe seleccionar un colaborador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            if (cmbPriority.SelectedIndex == -1)
            {
            MessageBox.Show("Debe seleccionar una prioridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
            MessageBox.Show("Debe seleccionar un estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
            MessageBox.Show("Debe seleccionar una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            if (cmbRewardPolicy.SelectedIndex == -1)
            {
            MessageBox.Show("Debe seleccionar una política de recompensa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            if((int)cmbRewardPolicy.SelectedValue != -1)
            {

                var rewardTypes = _objectiveBLL.GetRewardPolicies();
                var selectedRewardPolicy = rewardTypes.Find(r => r.Id == (int)cmbRewardPolicy.SelectedValue);
                if (selectedRewardPolicy.AccumulationLimit < (txtPoints.Text == "" ? 0 : Convert.ToInt32(txtPoints.Text)))
                {
                    MessageBox.Show("Los puntos asignados exceden el límite de acumulación de la política de recompensa seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }


            // If all validations pass, proceed to add the objective
            var newObjective = new Objective
            {
            Title = txtTitle.Text,
            Description = txtDescription.Text,
            ResponsibleUserId = SingletonSession.Instancia.User.Id,
            ReviewDate = null,
            Progress = 0,
            StartDate = dtpFrom.Value,
            EndDate = dtpTo.Value,
            AssignedUserId = (Guid)cmbNominee.SelectedValue,
            PriorityId = (int)cmbPriority.SelectedValue,
            StatusId = (int)cmbStatus.SelectedValue,
            CategoryId = (int)cmbCategory.SelectedValue,
            RewardPolicyId = (int)cmbRewardPolicy.SelectedValue!,
            PointsAssigned = txtPoints.Text == "" ? 0 : Convert.ToInt32(txtPoints.Text)
            };

            _objectiveBLL.AddObjective(newObjective);
            MessageBox.Show("El objetivo ha sido agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
