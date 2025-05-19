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
    public partial class FrmConfigureRewardPolicies : Form, IObserverForm
    {
        private readonly IObjectiveBLL _objectiveBLL;

        public FrmConfigureRewardPolicies(IObjectiveBLL objectiveBLL)
        {
            _objectiveBLL = objectiveBLL;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Configure DataGridView for reward policies
            dgvRewardPolicies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRewardPolicies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRewardPolicies.ReadOnly = false;

            // Add columns to DataGridView for reward policies
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", ReadOnly = true, Visible = false });
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "PolicyName", HeaderText = "Nombre de la Política" });
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Descripción" });
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "ConversionRate", HeaderText = "Tasa de Conversión" });
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "AccumulationLimit", HeaderText = "Límite de Acumulación" });
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "EffectiveFrom", HeaderText = "Fecha de Inicio" });
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "EffectiveTo", HeaderText = "Fecha de Fin" });
            dgvRewardPolicies.Columns.Add(new DataGridViewCheckBoxColumn { Name = "IsActive", HeaderText = "Activa" });
            dgvRewardPolicies.Columns.Add(new DataGridViewTextBoxColumn { Name = "CategoryName", HeaderText = "Categoría", ReadOnly = true });

            var btnEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };
            dgvRewardPolicies.Columns.Add(btnEdit);

            var btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            dgvRewardPolicies.Columns.Add(btnDelete);

            dgvRewardPolicies.CellClick += DgvRewardPolicies_CellClick;
            PopulateRewardPolicies();
            PopulateCategories();
        }

        private void PopulateCategories()
        {
            var categories = _objectiveBLL.GetPolicyCategories();
            CmbCategories.DataSource = categories;
            CmbCategories.DisplayMember = "Name";
            CmbCategories.ValueMember = "Id";
        }

        private void DgvRewardPolicies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var categoryId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;

                if (dgv.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditPolicy(dgv, e.RowIndex);
                }
                else if (dgv.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    DeletePolicy(categoryId);
                }
            }
        }

        private void PopulateRewardPolicies()
        {
            var policies = _objectiveBLL.GetRewardPolicies();
            dgvRewardPolicies.Rows.Clear();
            foreach (var policy in policies)
            {
                dgvRewardPolicies.Rows.Add(policy.Id, policy.PolicyName, policy.Description, policy.ConversionRate, policy.AccumulationLimit, policy.EffectiveFrom, policy.EffectiveTo, policy.IsActive, policy.CategoryName);
            }
            ClearTextBoxes(TxtName, TxtDescription);
            nudConversionRate.Value = 0;
            nudAccumulationLimit.Value = 0;
            dtpEffectiveFrom.Value = DateTime.Now;
            dtpEffectiveTo.Value = DateTime.Now;
            CmbCategories.SelectedIndex = -1;
        }

        
        private void AddPolicy()
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtDescription.Text) )
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudConversionRate.Value <= 0)
            {
                MessageBox.Show("La tasa de conversión debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudAccumulationLimit.Value <= 0)
            {
                MessageBox.Show("El límite de acumulación debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpEffectiveFrom.Value >= dtpEffectiveTo.Value)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CmbCategories.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var policy = new RewardPolicy
            {
                PolicyName = TxtName.Text,
                Description = TxtDescription.Text,
                ConversionRate = nudConversionRate.Value,
                AccumulationLimit = nudAccumulationLimit.Value,
                EffectiveFrom = dtpEffectiveFrom.Value,
                EffectiveTo = dtpEffectiveTo.Value,
                IsActive = true,
                CategoryId = CmbCategories.SelectedValue as int?,
                CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                CreatedAt = DateTime.Now
            };

            _objectiveBLL.AddRewardPolicy(policy);
            PopulateRewardPolicies();
            ClearTextBoxes(TxtName, TxtDescription);
            MessageBox.Show("Política de recompensas agregada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditPolicy(DataGridView dgv, int rowIndex)
        {
            if (string.IsNullOrWhiteSpace(dgv.Rows[rowIndex].Cells["PolicyName"].Value.ToString()) ||
                string.IsNullOrWhiteSpace(dgv.Rows[rowIndex].Cells["Description"].Value.ToString()))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (decimal.Parse(dgv.Rows[rowIndex].Cells["ConversionRate"].Value.ToString()) <= 0)
            {
                MessageBox.Show("La tasa de conversión debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (decimal.Parse(dgv.Rows[rowIndex].Cells["AccumulationLimit"].Value.ToString()) <= 0)
            {
                MessageBox.Show("El límite de acumulación debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var policy = new RewardPolicy
            {
                Id = (int)dgv.Rows[rowIndex].Cells["Id"].Value,
                PolicyName = dgv.Rows[rowIndex].Cells["PolicyName"].Value.ToString(),
                Description = dgv.Rows[rowIndex].Cells["Description"].Value.ToString(),
                ConversionRate = decimal.Parse(dgv.Rows[rowIndex].Cells["ConversionRate"].Value.ToString()),
                AccumulationLimit = decimal.Parse(dgv.Rows[rowIndex].Cells["AccumulationLimit"].Value.ToString()),
                EffectiveFrom = (DateTime)dgv.Rows[rowIndex].Cells["EffectiveFrom"].Value,
                EffectiveTo = dgv.Rows[rowIndex].Cells["EffectiveTo"].Value as DateTime?,
                IsActive = (bool)dgv.Rows[rowIndex].Cells["IsActive"].Value,
                UpdatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                UpdatedAt = DateTime.Now
            };

            _objectiveBLL.UpdateRewardPolicy(policy);
            PopulateRewardPolicies();
            MessageBox.Show("Política de recompensas actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeletePolicy(int policyId)
        {
            if (policyId <= 0)
            {
            MessageBox.Show("ID de política no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            var result = MessageBox.Show("¿Está seguro de que desea eliminar esta política?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            try
            {
                _objectiveBLL.DeleteRewardPolicy(policyId);
                MessageBox.Show("Política de recompensas eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateRewardPolicies();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la política: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        }

        private void ClearTextBoxes(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
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

        private void FrmConfigureRewardPolicies_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);

        }

        private void FrmConfigureRewardPolicies_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddPolicy();
        }
    }
}
