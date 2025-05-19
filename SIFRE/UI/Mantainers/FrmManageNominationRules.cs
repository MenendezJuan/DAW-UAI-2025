using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE.DTO;
using BE.Entities;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Mappers;
using Infrastructure.Observer;
using Infrastructure.Session;

namespace UI.Mantainers
{
    public partial class FrmManageNominationRules : Form, IObserverForm
    {
        private readonly INominationRuleBLL _nominationRuleBLL;

        public FrmManageNominationRules(INominationRuleBLL nominationRuleBLL)
        {
            _nominationRuleBLL = nominationRuleBLL;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Configure DataGridView
            dgvRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRules.ReadOnly = false;

            // Add columns to DataGridView
            dgvRules.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", ReadOnly = true, Visible = false });
            dgvRules.Columns.Add(new DataGridViewTextBoxColumn { Name = "RuleName", HeaderText = "Nombre de la Regla", ReadOnly = true });
            dgvRules.Columns.Add(new DataGridViewTextBoxColumn { Name = "RuleValue", HeaderText = "Valor de la Regla" });
            dgvRules.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Descripción", ReadOnly = true });
            dgvRules.Columns.Add(new DataGridViewCheckBoxColumn { Name = "IsActive", HeaderText = "Activa"});
            var btnEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };
            dgvRules.Columns.Add(btnEdit);

            dgvRules.CellClick += DgvRules_CellClick;

            // Populate DataGridView with nomination rules
            PopulateNominationRules();
        }

        private void PopulateNominationRules()
        {
            var rules = _nominationRuleBLL.GetNominationRules();
            dgvRules.Rows.Clear();
            foreach (var rule in rules)
            {
                dgvRules.Rows.Add(rule.Id, rule.RuleName, rule.RuleValue, rule.Description, rule.IsActive);
            }
            AdjustDataGridViewHeight(dgvRules, rules.Count);
        }

        private void DgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (e.ColumnIndex == -1)
                return;

            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var ruleId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;

                if (dgv.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditRule(dgv, e.RowIndex);
                }
            }
        }

        private void AdjustDataGridViewHeight(DataGridView dgv, int numberOfRows)
        {
            if (dgv.Rows.Count > 0)
            {
                // Altura total calculada
                int rowHeight = dgv.Rows[0].Height; // Altura de una fila
                int headerHeight = dgv.ColumnHeadersHeight; // Altura de la cabecera

                // Altura del DataGridView para las filas visibles
                dgv.Height = (rowHeight * numberOfRows) + headerHeight + dgv.Margin.Vertical;
            }
            else
            {
                // Si no hay filas, ajusta solo para la cabecera
                dgv.Height = dgv.ColumnHeadersHeight + dgv.Margin.Vertical;
            }
        }

        private void EditRule(DataGridView dgv, int rowIndex)
        {
            var ruleId = (int)dgv.Rows[rowIndex].Cells["Id"].Value;
            var ruleValue = dgv.Rows[rowIndex].Cells["RuleValue"].Value.ToString();

            if (string.IsNullOrWhiteSpace(ruleValue))
            {
                MessageBox.Show("El valor de la regla no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rule = new NominationRule
            {
                Id = ruleId,
                RuleValue = ruleValue,
                UpdatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                UpdatedAt = DateTime.Now
            };

            try
            {
                _nominationRuleBLL.UpdateNominationRule(rule);
                MessageBox.Show("Regla actualizada con éxito.");
                PopulateNominationRules();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la regla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FrmManageNominationRules_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
        }

        private void FrmManageNominationRules_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);

        }
    }
}
