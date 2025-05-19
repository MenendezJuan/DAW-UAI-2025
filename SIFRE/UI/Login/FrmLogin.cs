using BLL;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Helpers;
using BE.Entities;
using BE.DTO;
using Microsoft.Data.SqlClient;
using Infrastructure.Session;
using UI.Language;
using UI.Security;
using Microsoft.Extensions.DependencyInjection;
using UI.Profiles;
using DAL;
using Infrastructure.Mappers;

namespace UI
{
    public partial class FrmLogin : Form
    {
        private int attempts = 0;
        private string currentUser = String.Empty;
        IUserBLL _userBLL;
        ILogBLL _logBLL;
        ILanguageBLL _languageBLL;
        ICheckDigitBLL _checkDigitBLL;
        FrmInconsistencyManagement frmInconsistencyManagement = null;
        private List<string> tables = new List<string>();

        public FrmLogin(IUserBLL userBLL, ILanguageBLL languageBLL, ICheckDigitBLL checkDigitBLL, ILogBLL logBLL)
        {
            InitializeComponent();
            _userBLL = userBLL;
            _languageBLL = languageBLL;
            _checkDigitBLL = checkDigitBLL;
            _logBLL = logBLL;
            tables.Add("Products");
            tables.Add("Transactions");
            tables.Add("PointTransfers");
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string password = EncryptionHelper.Encrypt(TxtPassword.Text);
            string messageError = string.Empty;

            LblError.Visible = false;
            if (currentUser != TxtUsername.Text)
            {
                attempts = 0;
                currentUser = TxtUsername.Text;
            }

            UserDTO? user = _userBLL.GetByUsernameAndPassword(currentUser, password);

            if (user != null)
            {
                // Usuario autenticado correctamente
                SingletonSession.Instancia.Login(user);
                SingletonSession.Instancia.currentLanguage = _languageBLL.GetById(user.LanguageId, true)!;
                foreach (var table in tables)
                {
                    string response = _checkDigitBLL.VerifyTable(table);
                    if(response != string.Empty)
                    {
                        messageError = response;
                        break;
                    }

                }

                if(messageError != string.Empty)
                {
                    if(SingletonSession.Instancia.User.UserRole.Name == "Administrador")
                    {
                        frmInconsistencyManagement = Program.ServiceProvider.GetRequiredService<FrmInconsistencyManagement>();
                        frmInconsistencyManagement.Load(messageError);
                        frmInconsistencyManagement.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error de inconsistencia de informacion, por favor comunicate con un administrador");
                    }


                    _logBLL.Save(new BE.Entities.Log
                    {
                        Message = messageError,
                        CreatedAt = DateTime.Now,
                        CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                        Type = BE.Entities.LogType.Critical,
                        Module = this.Name
                    });
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    FrmPrincipal frmPrincipal = Program.ServiceProvider.GetRequiredService<FrmPrincipal>();
                    frmPrincipal.Logout += (s, args) => { this.Show(); TxtPassword.Text = String.Empty; TxtUsername.Text = String.Empty; };
                    frmPrincipal.Show();
                    frmPrincipal.Login();
                    this.Hide();
                }
            }
            else
            {
                // Usuario o contraseña incorrecta
                attempts++;
                LblError.Text = "Usuario y/o contraseña incorrectos.";
                LblError.Visible = true;

                if (attempts >= 3)
                {
                    // Bloquear al usuario
                    bool isBlocked = _userBLL.Block(currentUser);

                    if(isBlocked)
                        LblError.Text = "Usuario bloqueado.";
                    else
                        LblError.Text = "Usuario y/o contraseña incorrectos.";
                    LblError.Visible = true;
                }
            }
        }
    }
}
