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
    public partial class FrmConfigureRecognitionCategories : Form, IObserverForm
    {
        public void UpdateLanguage(UserSession session)
        {
            UpdateControlTexts(this.Controls, session);
        }

        private readonly IRecognitionCategoryBLL _recognitionCategoryBLL;

        public FrmConfigureRecognitionCategories(IRecognitionCategoryBLL recognitionCategoryBLL)
        {
            _recognitionCategoryBLL = recognitionCategoryBLL;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Configure DataGridView
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.ReadOnly = false;

            // Add columns to DataGridView
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", ReadOnly = true });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Nombre" });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Descripción" });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Points", HeaderText = "Puntos" });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedBy", HeaderText = "Creado Por", ReadOnly = true });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedAt", HeaderText = "Fecha de Creación", ReadOnly = true });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "UpdatedBy", HeaderText = "Actualizado Por", ReadOnly = true });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "UpdatedAt", HeaderText = "Fecha de Actualización", ReadOnly = true });

            // Add Edit and Delete buttons to DataGridView
            var btnEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };
            dgvCategories.Columns.Add(btnEdit);

            var btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            dgvCategories.Columns.Add(btnDelete);

            dgvCategories.CellClick += DgvCategories_CellClick;

            // Add event handler for Add button
            BtnAddProduct.Click += (sender, e) => AddCategory();

            // Populate DataGridView with recognition categories
            PopulateRecognitionCategories();
        }

        private void PopulateRecognitionCategories()
        {
            var categories = _recognitionCategoryBLL.GetRecognitionCategories();
            dgvCategories.Rows.Clear();
            foreach (var category in categories)
            {
                dgvCategories.Rows.Add(category.Id, category.Name, category.Description, category.Points, category.CreatedBy, category.CreatedAt, category.UpdatedBy, category.UpdatedAt);
            }
        }

        private void DgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var categoryId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;

                if (dgv.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditCategory(dgv, e.RowIndex);
                }
                else if (dgv.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    DeleteCategory(categoryId);
                }
            }
        }

        private void AddCategory()
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtDescription.Text) || string.IsNullOrWhiteSpace(TxtPoints.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(TxtPoints.Text, out int points))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico para los puntos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var category = new RecognitionCategory
            {
                Name = TxtName.Text,
                Description = TxtDescription.Text,
                Points = points,
                CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                CreatedAt = DateTime.Now
            };

            _recognitionCategoryBLL.AddRecognitionCategory(category);
            PopulateRecognitionCategories();
            ClearTextBoxes(TxtName, TxtDescription, TxtPoints);
        }

        private void EditCategory(DataGridView dgv, int rowIndex)
        {
            var categoryId = (int)dgv.Rows[rowIndex].Cells["Id"].Value;
            var name = dgv.Rows[rowIndex].Cells["Name"].Value.ToString();
            var description = dgv.Rows[rowIndex].Cells["Description"].Value.ToString();
            var points = int.Parse(dgv.Rows[rowIndex].Cells["Points"].Value.ToString());

            var category = new RecognitionCategory
            {
                Id = categoryId,
                Name = name,
                Description = description,
                Points = points,
                UpdatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                UpdatedAt = DateTime.Now
            };

            _recognitionCategoryBLL.UpdateRecognitionCategory(category);
            PopulateRecognitionCategories();
        }

        private void DeleteCategory(int categoryId)
        {
            var result = MessageBox.Show("¿Está seguro de que desea eliminar esta categoría?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _recognitionCategoryBLL.DeleteRecognitionCategory(categoryId);
                PopulateRecognitionCategories();
            }
        }

        private void ClearTextBoxes(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }
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

        private void FrmConfigureRecognitionCategories_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;

        }

        private void FrmConfigureRecognitionCategories_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);

        }
    }
}
