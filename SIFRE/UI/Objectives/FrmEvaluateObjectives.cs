using Infrastructure.Observer;
using Infrastructure.Session;
using BE.DTO;
using Microsoft.VisualBasic;
using Infrastructure.Interfaces.BLL;

namespace UI.Objectives
{
    public partial class FrmEvaluateObjectives : Form, IObserverForm
    {
        private readonly INominationBLL _nominationBLL;
        private readonly INominationRuleBLL _nominationRuleBLL;
        private readonly IObjectiveBLL _objectiveBLL;
        private readonly IPointBLL _pointBLL;
        private readonly ILogBLL _logBLL;
        public FrmEvaluateObjectives(INominationBLL nominationBLL, INominationRuleBLL nominationRuleBLL, ILogBLL logBLL, IPointBLL pointBLL, IObjectiveBLL objectiveBLL)
        {
            _nominationBLL = nominationBLL;
            _nominationRuleBLL = nominationRuleBLL;
            _logBLL = logBLL;
            _pointBLL = pointBLL;
            _objectiveBLL = objectiveBLL;

            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {

            // Configure DataGridView for nominations
            dgvObjectives.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvObjectives.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObjectives.ReadOnly = true;
            dgvObjectives.AllowUserToAddRows = false;
            dgvObjectives.AllowUserToDeleteRows = false;
            dgvObjectives.AutoGenerateColumns = false;
            dgvObjectives.ScrollBars = ScrollBars.Both;
            dgvObjectives.MultiSelect = false;

            // Add columns to DataGridView for nominations
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "ObjectiveId", HeaderText = "ID de Objetivo" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Descripción" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "StartDate", HeaderText = "Fecha de Inicio" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "EndDate", HeaderText = "Fecha de Fin" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Estado" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "ResponsibleUserName", HeaderText = "Responsable" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "PriorityName", HeaderText = "Prioridad" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "CategoryName", HeaderText = "Categoría" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "Progress", HeaderText = "Progreso" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewDate", HeaderText = "Fecha de Revisión" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "PointsAssigned", HeaderText = "Puntos Asignados" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "RewardPolicyName", HeaderText = "Política de Recompensa" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedByName", HeaderText = "Creado Por" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedAt", HeaderText = "Fecha de Creación" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "UpdatedByName", HeaderText = "Actualizado Por" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "UpdatedAt", HeaderText = "Fecha de Actualización" });
            PopulateObjectives();

        }


        private void PopulateComboBoxWithUsers(ComboBox comboBox)
        {
            var users = _nominationBLL.GetUsers().Where(u => u.Id != SingletonSession.Instancia.User.Id).ToList();
            comboBox.DisplayMember = "FirstName";
            comboBox.ValueMember = "Id";
            comboBox.DataSource = users;
        }

        private void PopulateObjectives()
        {
            if (cmbNominee.SelectedValue == null)
                return;
            var objectives = _objectiveBLL.GetObjectives().Where(n => n.StatusName != "Completado" && n.AssignedUserId == (Guid)cmbNominee.SelectedValue).ToList();
            dgvObjectives.Rows.Clear();
            foreach (var objective in objectives)
            {
                dgvObjectives.Rows.Add(objective.Id, objective.Description, objective.StartDate, objective.EndDate, objective.StatusName, objective.ResponsibleUserName, objective.PriorityName, objective.CategoryName, objective.Progress, objective.ReviewDate, objective.PointsAssigned, objective.RewardPolicyName, objective.CreatedByName, objective.CreatedAt, objective.UpdatedByName, objective.UpdatedAt);
            }
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

        private void FrmEvaluateObjectives_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
            PopulateComboBoxWithUsers(cmbNominee);
        }

        private void FrmEvaluateObjectives_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);

        }

        private void cmbNominee_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateObjectives();
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbComments.Text))
            {
                MessageBox.Show("El comentario no puede ser vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvObjectives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un objetivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNominee.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedRow = dgvObjectives.SelectedRows[0];
            var selectedObjective = new ObjectiveDTO
            {
                Id = (int)selectedRow.Cells["ObjectiveId"].Value,
                Description = selectedRow.Cells["Description"].Value.ToString(),
                StartDate = (DateTime)selectedRow.Cells["StartDate"].Value,
                EndDate = (DateTime)selectedRow.Cells["EndDate"].Value,
                StatusName = selectedRow.Cells["Status"].Value.ToString(),
                ResponsibleUserName = selectedRow.Cells["ResponsibleUserName"].Value.ToString(),
                PriorityName = selectedRow.Cells["PriorityName"].Value.ToString(),
                CategoryName = selectedRow.Cells["CategoryName"].Value.ToString(),
                Progress = (int)selectedRow.Cells["Progress"].Value,
                ReviewDate = DateTime.Now,
                PointsAssigned = (int)selectedRow.Cells["PointsAssigned"].Value,
                RewardPolicyName = selectedRow.Cells["RewardPolicyName"].Value.ToString(),
                CreatedByName = selectedRow.Cells["CreatedByName"].Value.ToString()
            };

            if (selectedObjective.StatusName != "En Progreso")
            {
            MessageBox.Show("El objetivo seleccionado no está en estado 'En Progreso''.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
            }

            string progress = Interaction.InputBox("Ingrese el nuevo progreso del objetivo", "Ajustar Progreso", selectedObjective.Progress.ToString());

            selectedObjective.Progress = int.Parse(progress);

            if (selectedObjective.Progress == 100)
            {
                _pointBLL.TransferPointsToUser(selectedObjective.PointsAssigned, (Guid)cmbNominee.SelectedValue);
                
                selectedObjective.StatusName = "Completado";
                MessageBox.Show("El objetivo ha sido completado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            else
            {
                MessageBox.Show("El objetivo ha sido ajustado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedObjective.StatusName = "En Progreso";
            }

            _objectiveBLL.UpdateObjective(selectedObjective, rtbComments.Text);
            PopulateObjectives();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbComments.Text))
            {
                MessageBox.Show("El comentario no puede ser vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvObjectives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un objetivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNominee.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedRow = dgvObjectives.SelectedRows[0];
            var selectedObjective = new ObjectiveDTO
            {
                Id = (int)selectedRow.Cells["ObjectiveId"].Value,
                Description = selectedRow.Cells["Description"].Value.ToString(),
                StartDate = (DateTime)selectedRow.Cells["StartDate"].Value,
                EndDate = (DateTime)selectedRow.Cells["EndDate"].Value,
                StatusName = selectedRow.Cells["Status"].Value.ToString(),
                ResponsibleUserName = selectedRow.Cells["ResponsibleUserName"].Value.ToString(),
                PriorityName = selectedRow.Cells["PriorityName"].Value.ToString(),
                CategoryName = selectedRow.Cells["CategoryName"].Value.ToString(),
                Progress = (int)selectedRow.Cells["Progress"].Value,
                ReviewDate = DateTime.Now,
                PointsAssigned = (int)selectedRow.Cells["PointsAssigned"].Value,
                RewardPolicyName = selectedRow.Cells["RewardPolicyName"].Value.ToString(),
                CreatedByName = selectedRow.Cells["CreatedByName"].Value.ToString()
            };

            if (selectedObjective.StatusName != "En Progreso" && selectedObjective.StatusName != "Pendiente")
            {
            MessageBox.Show("El objetivo seleccionado no está en estado 'En Progreso' o 'Pendiente'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
            }

            selectedObjective.StatusName = "En Espera";
            MessageBox.Show("El objetivo ha sido puesto en espera.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _objectiveBLL.UpdateObjective(selectedObjective, rtbComments.Text);
            PopulateObjectives();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbComments.Text))
            {
                MessageBox.Show("El comentario no puede ser vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvObjectives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un objetivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNominee.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedRow = dgvObjectives.SelectedRows[0];
            var selectedObjective = new ObjectiveDTO
            {
                Id = (int)selectedRow.Cells["ObjectiveId"].Value,
                Description = selectedRow.Cells["Description"].Value.ToString(),
                StartDate = (DateTime)selectedRow.Cells["StartDate"].Value,
                EndDate = (DateTime)selectedRow.Cells["EndDate"].Value,
                StatusName = selectedRow.Cells["Status"].Value.ToString(),
                ResponsibleUserName = selectedRow.Cells["ResponsibleUserName"].Value.ToString(),
                PriorityName = selectedRow.Cells["PriorityName"].Value.ToString(),
                CategoryName = selectedRow.Cells["CategoryName"].Value.ToString(),
                Progress = (int)selectedRow.Cells["Progress"].Value,
                ReviewDate = DateTime.Now,
                PointsAssigned = (int)selectedRow.Cells["PointsAssigned"].Value,
                RewardPolicyName = selectedRow.Cells["RewardPolicyName"].Value.ToString(),
                CreatedByName = selectedRow.Cells["CreatedByName"].Value.ToString()
            };
            if (selectedObjective.StatusName != "Pendiente" && selectedObjective.StatusName != "En Espera")
            {
            MessageBox.Show("El objetivo seleccionado no está en estado 'En Espera' ni 'Pendiente'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
            }

            selectedObjective.StatusName = "En Progreso";
            _objectiveBLL.UpdateObjective(selectedObjective, rtbComments.Text);
            MessageBox.Show("El objetivo ha sido asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PopulateObjectives();
        }

    }
}
