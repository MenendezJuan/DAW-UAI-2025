using BE.DTO;
using BE.Entities;
using BE.Enums;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Mappers;
using Infrastructure.Observer;
using Infrastructure.Session;

namespace UI.Recognitions
{
    public partial class FrmReviewPendingNominations : Form, IObserverForm
    {
        private readonly INominationBLL _nominationBLL;
        private readonly INominationRuleBLL _nominationRuleBLL;
        private readonly IPointBLL _pointBLL;
        private readonly ILogBLL _logBLL;
        public FrmReviewPendingNominations(INominationBLL nominationBLL, INominationRuleBLL nominationRuleBLL, ILogBLL logBLL, IPointBLL pointBLL)
        {
            _nominationBLL = nominationBLL;
            _nominationRuleBLL = nominationRuleBLL;
            _logBLL = logBLL;
            _pointBLL = pointBLL;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Configure DataGridView for nominations
            dgvNominates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNominates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNominates.ReadOnly = true;
            dgvNominates.AllowUserToAddRows = false;
            dgvNominates.AllowUserToDeleteRows = false;

            // Add columns to DataGridView for nominations
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "NominationId", HeaderText = "ID de Nominación" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "NominatorId", HeaderText = "ID del Nominador", Visible = false });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nominator", HeaderText = "Nominador" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomineeId", HeaderText = "ID del Nominado", Visible = false });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nominee", HeaderText = "Nominado" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Categoría" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Points", HeaderText = "Puntos" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "StatusName", HeaderText = "Estado" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedAt", HeaderText = "Fecha" });



        }

        private void PopulateNominations()
        {
            if (cmbNominee.SelectedValue == null)
                return;
            var selectedUserId = (Guid)cmbNominee.SelectedValue;
            var nominations = _nominationBLL.GetNominationsByUser(selectedUserId).Where(n => n.StatusName == "Pendiente").ToList();
            dgvNominates.Rows.Clear();
            foreach (var nomination in nominations)
            {
                dgvNominates.Rows.Add(nomination.NominationId, nomination.NominatorId, nomination.Nominator, nomination.NomineeId, nomination.Nominee, nomination.Category, nomination.Points, nomination.StatusName, nomination.CreatedAt);
            }
        }
        private void PopulateComboBoxWithUsers(ComboBox comboBox)
        {
            var users = _nominationBLL.GetUsers().Where(u => u.Id != SingletonSession.Instancia.User.Id).ToList();
            comboBox.DisplayMember = "FirstName";
            comboBox.ValueMember = "Id";
            comboBox.DataSource = users;
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

        private void FrmReviewPendingNominations_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
            // Populate ComboBoxes with data
            PopulateComboBoxWithUsers(cmbNominee);
            PopulateNominations();
        }

        private void FrmReviewPendingNominations_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);
        }

        private void btnAcceptNomination_Click(object sender, EventArgs e)
        {
            if(rtbComments.Text == "")
            {
                MessageBox.Show("Debe ingresar un comentario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvNominates.SelectedRows.Count > 0)
            {
                var nominationId = (int)dgvNominates.SelectedRows[0].Cells["NominationId"].Value;
                var nominated = (Guid)dgvNominates.SelectedRows[0].Cells["NomineeId"].Value;
                var nominatedName = dgvNominates.SelectedRows[0].Cells["Nominee"].Value;
                
                var points = decimal.Parse(dgvNominates.SelectedRows[0].Cells["Points"].Value.ToString()!);
                var status = dgvNominates.SelectedRows[0].Cells["StatusName"].Value.ToString();
                if (status == "Aprobada")
                {
                    MessageBox.Show("La nominación ya está aceptada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                _nominationBLL.UpdateNomination(nominationId, NominationStatuses.APPROVED, rtbComments.Text);
                PopulateNominations();
                _logBLL.Save(new Log
                {
                    Module = "FrmCheckNominationStatus",
                    Type = LogType.Info,
                    Message = "Nominación aceptada",
                    CreatedAt = DateTime.Now,
                    CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                });

                _pointBLL.TransferPointsToUser(points, nominated);
                MessageBox.Show($"Nominación aprobada correctamente, se agregan {points} puntos a {nominatedName}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnRejectNomination_Click(object sender, EventArgs e)
        {
            if(rtbComments.Text == "")
            {
                MessageBox.Show("Debe ingresar un comentario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvNominates.SelectedRows.Count > 0)
            {
                var nominationId = (int)dgvNominates.SelectedRows[0].Cells["NominationId"].Value;
                var status = dgvNominates.SelectedRows[0].Cells["StatusName"].Value.ToString();
                if (status == "Rechazada")
                {
                    MessageBox.Show("La nominación ya está rechazada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                _nominationBLL.UpdateNomination(nominationId, NominationStatuses.REJECTED, rtbComments.Text);
                PopulateNominations();
                _logBLL.Save(new Log
                {
                    Module = "FrmCheckNominationStatus",
                    Type = LogType.Info,
                    Message = "Nominación rechazada",
                    CreatedAt = DateTime.Now,
                    CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                });
                MessageBox.Show("Nominación rechazada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbNominee_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateNominations();
        }
    }
}
