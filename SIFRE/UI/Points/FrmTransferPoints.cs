using BE.DTO;
using Infrastructure.Interfaces.BLL;
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
using UI.Reports;

namespace UI.Points
{
    public partial class FrmTransferPoints : Form, IObserverForm
    {
        private IPointBLL pointBLL;
        private IUserBLL userBLL;

        public FrmTransferPoints(IPointBLL pointBLL, IUserBLL userBLL)
        {
            InitializeComponent();
            this.pointBLL = pointBLL;
            this.userBLL = userBLL;
            cmbCollaborator.DataSource = userBLL.GetAllUsers();
            cmbCollaborator.DisplayMember = "Username";
            cmbCollaborator.ValueMember = "Id";
            LblPoints.Text = pointBLL.GetPointsByUserId(SingletonSession.Instancia.User.Id).ToString();
            DgvHistory.DataSource = pointBLL.GetPointTransfers();

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

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Por favor elija la cantidad de puntos a transferir.");
                    return;
                }
                if (cmbCollaborator.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un colaborador");
                    return;
                }
                if (numericUpDown1.Value > Convert.ToDecimal(LblPoints.Text))
                {
                    MessageBox.Show("No puede transferir más puntos de los que tiene.");
                    return;
                }
                if (numericUpDown1.Text != "" && cmbCollaborator.SelectedItem != null)
                {
                    pointBLL.TransferPointsToUser(numericUpDown1.Value, ((UserDTO)cmbCollaborator.SelectedItem).Id);
                    MessageBox.Show("Puntos transferidos con éxito");
                    DgvHistory.DataSource = pointBLL.GetPointTransfers();
                    LblPoints.Text = pointBLL.GetPointsByUserId(SingletonSession.Instancia.User.Id).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            PdfExporter.ExportDataGridViewToPdf(DgvHistory, "Reporte de historial de transferencias", "Registro detallado de cambio de puntos entre usuarios");

        }

        private void FrmTransferPoints_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);
        }

        private void FrmTransferPoints_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
        }
    }
}
