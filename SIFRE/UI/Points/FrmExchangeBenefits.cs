using BE.DTO;
using BE.Entities;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Mappers;
using Infrastructure.Observer;
using Infrastructure.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Points
{
    public partial class FrmExchangeBenefits : Form, IObserverForm
    {
        private IProductBLL productBLL;
        private IPointBLL pointBLL;
        private ILogBLL logBLL;
        private ILanguageBLL languageBLL;
        private IList<ProductDTO> productDTOs = new List<ProductDTO>();

        public FrmExchangeBenefits(IProductBLL productBLL, IPointBLL pointBLL, ILanguageBLL languageBLL, ILogBLL logBLL)
        {
            InitializeComponent();
            this.productBLL = productBLL;
            this.pointBLL = pointBLL;
            this.languageBLL = languageBLL;
            this.logBLL = logBLL;

        }

        private void FrmExchangeBenefits_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
            FillDataSource();
            DgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productDTOs = productBLL.GetProducts(true, false);
            UpdateProductsDGV();
        }

        private void FillDataSource()
        {
            LblPoints.Text = pointBLL.GetPointsByUserId(SingletonSession.Instancia.User.Id).ToString();
        }
        private void UpdateProductsDGV()
        {
            DgvProducts.DataSource = productDTOs.ToList();
        }

        public void UpdateLanguage(UserSession session)
        {
            foreach (Control control in this.Controls)
            {
                foreach (TranslationDTO translation in session.currentLanguage.Translations)
                {
                    control.Text = control.Tag != null && control.Tag.ToString() == translation.LabelName ? translation.TranslatedText : control.Text;
                }
            }
        }

        private void FrmExchangeBenefits_FormClosed_1(object sender, FormClosedEventArgs e)
        {

            SingletonSession.Instancia.RemoveObserver(this);
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (DgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show(languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "NO_ROWS") ?? "No hay registros seleccionados");
                return;
            }
            DialogResult dialogResult = MessageBox.Show(languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "CONTINUE") ?? "¿Desea continuar?", "SIFRE", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var product = DgvProducts.SelectedRows[0];
                var productId = int.Parse(product.Cells["Id"].Value.ToString()!);
                var points = long.Parse(product.Cells["Points"].Value.ToString()!);
                long userPoints = long.Parse(LblPoints.Text);
                if (points > userPoints)
                {
                    MessageBox.Show(languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "NO_POINTS_AVAILABLE") ?? "No posee la suficiente cantidad de puntos");
                    return;
                }
                SingletonSession.Instancia.User.Points = pointBLL.ExchangePoints(productId, userPoints);
                LblPoints.Text = SingletonSession.Instancia.User.Points.ToString();
                MessageBox.Show((languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "POINTS_EXCHANGE_SUCCESS") ?? $"Canje exitoso, puntos restantes:") + SingletonSession.Instancia.User.Points);

                logBLL.Save(new BE.Entities.Log
                {
                    Message = $"Se canjearon puntos para el beneficio, saldo: {userPoints}",
                    CreatedAt = DateTime.Now,
                    CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                    Type = BE.Entities.LogType.Info,
                    Module = this.Name
                });
            }
        }
    }
}
