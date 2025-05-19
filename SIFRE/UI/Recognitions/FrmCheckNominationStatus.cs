using Infrastructure.Observer;
using Infrastructure.Session;
using BE.DTO;
using Infrastructure.Interfaces.BLL;
using BE.Entities;
using BE.Enums;
using Infrastructure.Mappers;

namespace UI.Recognitions
{
    public partial class FrmCheckNominationStatus : Form, IObserverForm
    {
        private readonly INominationBLL _nominationBLL;
        private readonly ILogBLL _logBLL;

        public FrmCheckNominationStatus(INominationBLL nominationBLL, ILogBLL logBLL)
        {
            _nominationBLL = nominationBLL;
            InitializeComponent();
            InitializeCustomComponents();
            _logBLL = logBLL;
        }

        private void InitializeCustomComponents()
        {
            // Configure DataGridView for nominations
            dgvNominates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNominates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNominates.ReadOnly = true;
            dgvNominates.AllowUserToAddRows = false;
            dgvNominates.AllowUserToDeleteRows = false;
            dgvNominationComment.AllowUserToAddRows = false;
            dgvNominationComment.AllowUserToDeleteRows = false;

            // Add columns to DataGridView for nominations
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "NominationId", HeaderText = "ID de Nominación" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "NominatorId", HeaderText = "ID del Nominador", Visible = false });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nominator", HeaderText = "Nominador" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomineeId", HeaderText = "ID del Nominado", Visible = false });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nominee", HeaderText = "Nominado" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Categoría" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "StatusName", HeaderText = "Estado" });
            dgvNominates.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedAt", HeaderText = "Fecha" });

            // Configure DataGridView for comments
            dgvNominationComment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNominationComment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNominationComment.ReadOnly = true;

            // Add columns to DataGridView for comments
            dgvNominationComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false });
            dgvNominationComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "Comment", HeaderText = "Comentario" });
            dgvNominationComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedByName", HeaderText = "Creado Por" });
            dgvNominationComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedAt", HeaderText = "Fecha de Creación" });

            // Add event handler for selection change in nominations DataGridView
            dgvNominates.SelectionChanged += DgvNominates_SelectionChanged;

            // Populate DataGridView with nominations
            PopulateNominations();
        }

        private void PopulateNominations()
        {
            var nominations = _nominationBLL.GetNominationsByUser(SingletonSession.Instancia.User.Id);
            dgvNominates.Rows.Clear();
            foreach (var nomination in nominations)
            {
                dgvNominates.Rows.Add(nomination.NominationId, nomination.NominatorId, nomination.Nominator, nomination.NomineeId, nomination.Nominee, nomination.Category, nomination.StatusName, nomination.CreatedAt);
            }
            if (dgvNominates.Rows.Count > 0)
            {
                var status = dgvNominates.Rows[0].Cells["StatusName"].Value.ToString();
                btnCancel.Enabled = status != "Cancelada";
            }
        }

        private void DgvNominates_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNominates.SelectedRows.Count > 0)
            {
                var nominationId = (int)dgvNominates.SelectedRows[0].Cells["NominationId"].Value;
                PopulateComments(nominationId);
            }
            if (dgvNominates.SelectedRows.Count > 0)
            {
                var status = dgvNominates.SelectedRows[0].Cells["StatusName"].Value.ToString();
                btnCancel.Enabled = status != "Cancelada";
            }
        }

        private void PopulateComments(int nominationId)
        {
            var comments = _nominationBLL.GetNominationComments(nominationId);
            dgvNominationComment.Rows.Clear();
            foreach (var comment in comments)
            {
                dgvNominationComment.Rows.Add(comment.Id, comment.Comment, comment.CreatedByName, comment.CreatedAt);
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

        private void FrmCheckNominationStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);

        }

        private void FrmCheckNominationStatus_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvNominates.SelectedRows.Count > 0)
            {
                var nominationId = (int)dgvNominates.SelectedRows[0].Cells["NominationId"].Value;
                var status = dgvNominates.SelectedRows[0].Cells["StatusName"].Value.ToString();
                if (status == "Cancelada")
                {
                    MessageBox.Show("La nominación ya está cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                _nominationBLL.UpdateNomination(nominationId, NominationStatuses.CANCELED, "Nominación fue cancelada por el usuario");
                PopulateNominations();
                _logBLL.Save(new Log
                {
                    Module = "FrmCheckNominationStatus",
                    Type = LogType.Info,
                    Message = "Cancelación de nominación",
                    CreatedAt = DateTime.Now,
                    CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                });
                MessageBox.Show("Nominación cancelada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
