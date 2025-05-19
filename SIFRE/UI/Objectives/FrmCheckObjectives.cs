using Infrastructure.Observer;
using Infrastructure.Session;
using BE.DTO;
using Infrastructure.Interfaces.BLL;

namespace UI.Objectives
{
    public partial class FrmCheckObjectives : Form, IObserverForm
    {
        private readonly IObjectiveBLL _objectiveBLL;
        public FrmCheckObjectives(IObjectiveBLL objectiveBLL)
        {
            _objectiveBLL = objectiveBLL;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {

            // Configure DataGridView for nominations
            dgvObjectives.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvObjectives.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObjectives.MultiSelect = false;
            dgvObjectives.AutoGenerateColumns = false;
            dgvObjectives.ReadOnly = true;
            dgvObjectives.AllowUserToAddRows = false;
            dgvObjectives.AllowUserToDeleteRows = false;
            dgvObjectiveComment.AllowUserToAddRows = false;
            dgvObjectiveComment.AllowUserToDeleteRows = false;
            dgvObjectiveComment.ReadOnly = true;
            dgvObjectiveComment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvObjectiveComment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObjectiveComment.MultiSelect = false;
            dgvObjectiveComment.AutoGenerateColumns = false;

            // Add columns to DataGridView

            // Enable horizontal scrolling
            dgvObjectives.ScrollBars = ScrollBars.Both;
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "ObjectiveId", HeaderText = "ID del Objetivo" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Descripción" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "StartDate", HeaderText = "Fecha de Inicio" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "EndDate", HeaderText = "Fecha de Fin" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Estado" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "EndDate", HeaderText = "End Date" });
            dgvObjectives.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status" });
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

            // Add columns to DataGridView for comments
            dgvObjectiveComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "CommentId", HeaderText = "ID del Comentario" });
            dgvObjectiveComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "Comment", HeaderText = "Comentario" });
            dgvObjectiveComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedByName", HeaderText = "Creado Por" });
            dgvObjectiveComment.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedAt", HeaderText = "Fecha de Creación" });


        }

        private void PopulateComments(int objectiveId)
        {
            var comments = _objectiveBLL.GetObjectiveComments(objectiveId);
            dgvObjectiveComment.Rows.Clear();
            foreach (var comment in comments)
            {
                dgvObjectiveComment.Rows.Add(comment.Id, comment.Comment, comment.CreatedByName, comment.CreatedAt);
            }
        }

        private void PopulateObjectives()
        {
            var objectives = _objectiveBLL.GetObjectives().Where(x => x.AssignedUserId == SingletonSession.Instancia.User.Id).ToList();
            dgvObjectives.Rows.Clear();
            foreach (var objective in objectives)
            {
                dgvObjectives.Rows.Add(
                    objective.Id,
                    objective.Description,
                    objective.StartDate,
                    objective.EndDate,
                    objective.StatusName,
                    objective.ResponsibleUserName,
                    objective.PriorityName,
                    objective.CategoryName,
                    objective.Progress,
                    objective.ReviewDate,
                    objective.PointsAssigned,
                    objective.RewardPolicyName,
                    objective.CreatedByName,
                    objective.CreatedAt,
                    objective.UpdatedByName,
                    objective.UpdatedAt
                );
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

        private void FrmCheckObjectives_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;

        }

        private void FrmCheckObjectives_FormClosed(object sender, FormClosedEventArgs e)
        {

            SingletonSession.Instancia.RemoveObserver(this);
        }

        private void dgvObjectives_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvObjectives.SelectedRows.Count > 0)
            {
                var objectiveId = (int)dgvObjectives.SelectedRows[0].Cells["ObjectiveId"].Value;
                PopulateComments(objectiveId);
            }
        }
    }
}
