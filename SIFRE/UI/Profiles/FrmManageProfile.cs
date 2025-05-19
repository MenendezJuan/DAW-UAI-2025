using BE.DTO;
using BE.Entities;
using BE.Enums;
using BLL;
using DAL;
using Infrastructure.Helpers;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Observer;
using Infrastructure.Session;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Profiles
{
    public partial class FrmManageProfile : Form, IObserverForm
    {
        Role roleSelected;
        IRoleBLL roleBLL;
        ILogBLL logBLL;
        IUserBLL userBLL;
        ILanguageBLL languageBLL;
        public FrmManageProfile(IRoleBLL roleBLL, ILogBLL logBLL, IUserBLL userBLL, ILanguageBLL languageBLL)
        {
            InitializeComponent();
            this.roleBLL = roleBLL;
            this.logBLL = logBLL;
            this.userBLL = userBLL;
            this.languageBLL = languageBLL;
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

        private void FrmManageProfile_Load(object sender, EventArgs e)
        {
            CmbPermissionType.DataSource = Enum.GetValues(typeof(PermissionsType));
            CmbUsers.DataSource = userBLL.GetAllUsers();
            FillCombos();
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
        }

        private void BtnSavePermission_Click(object sender, EventArgs e)
        {
            Permission permission = new Permission()
            {
                Name = this.TxtPermission.Text,
                Permission = (PermissionsType)this.CmbPermissionType.SelectedItem!
            };

            roleBLL.SaveComponent(permission, false);
            FillCombos();
            TxtPermission.Text = string.Empty;
        }

        private void BtnSaveRole_Click(object sender, EventArgs e)
        {
            Role role = new Role()
            {
                Name = this.TxtRole.Text
            };
            roleBLL.SaveComponent(role, true);
            FillCombos();
            TxtRole.Text = string.Empty;

        }

        private void FillCombos()
        {
            CmbPermissions.DataSource = roleBLL.GetPermissions();
            CmbRoles.DataSource = roleBLL.GetRoles();


        }

        private void BtnAddPermission_Click(object sender, EventArgs e)
        {
            if (roleSelected != null)
            {
                var permission = (Permission)CmbPermissions.SelectedItem!;
                if (permission != null)
                {
                    var exists = RoleHelper.RoleExists(roleSelected, permission.Id);
                    if (exists)
                    {
                        MessageBox.Show(languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "ROLE_ALREADY_EXISTS") ?? "Ya existe el permiso");
                    }
                    else
                    {
                        roleSelected.Children.Add(permission);
                        ShowRole(false);
                    }

                }
            }
        }

        private void BtnDeletePermission_Click(object sender, EventArgs e)
        {
            var permission = (Permission)this.CmbPermissions.SelectedItem!;
            roleBLL.DeleteRole(permission);
            FillCombos();
            ShowRole(true);
        }

        void ShowRole(bool init)
        {
            if (roleSelected == null) return;
            IList<RoleComponent> roleComponentList = new List<RoleComponent>();

            if (init)
            {
                roleComponentList = roleBLL.GetAll($" = {roleSelected.Id} ");

                foreach (var item in roleComponentList)
                {
                    roleSelected.AddChild(item);
                }
            }
            else
            {
                roleComponentList = roleSelected.Children;
            }

            treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(roleSelected.Name);
            root.Tag = roleSelected;
            this.treeView1.Nodes.Add(root);

            foreach (var item in roleComponentList)
            {
                ShowTreeView(root, item);
            }

            treeView1.ExpandAll();

        }
        void ShowTreeView(TreeNode tn, RoleComponent c)
        {
            TreeNode n = new TreeNode($"[{c.Id}] {c.Name}");
            tn.Tag = c;
            tn.Nodes.Add(n);
            if (c.Children != null)
                foreach (var item in c.Children)
                {
                    ShowTreeView(n, item);
                }

        }
        private void BtnConfig_Click(object sender, EventArgs e)
        {
            roleSelected = (Role)this.CmbRoles.SelectedItem!;
            ShowRole(true);
        }

        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            if (roleSelected != null)
            {
                var role = (Role)this.CmbRoles.SelectedItem!;
                if (role != null)
                {
                    var roleExists = RoleHelper.RoleExists(roleSelected, role.Id);
                    if (roleExists)
                    {
                        MessageBox.Show(languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "ROLE_ALREADY_EXISTS") ?? "Ya existe el rol");
                    }
                    else
                    {
                        roleBLL.FillRoleComponent(role);
                        roleSelected.Children.Add(role);
                        roleExists = RoleHelper.RoleExists(role, roleSelected.Id);
                        if (roleExists)
                            MessageBox.Show(languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "ROLE_ALREADY_EXISTS") ?? "Ya existe el rol");
                        else
                            ShowRole(false);
                    }
                }
            }
        }

        private void BtnSaveRoleComponent_Click(object sender, EventArgs e)
        {
            try
            {
                roleBLL.SaveComponent(roleSelected);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnDeleteRole_Click(object sender, EventArgs e)
        {
            var auxRole = (Role)this.CmbRoles.SelectedItem!;
            bool isAssigned = roleBLL.IsAssigned(auxRole);

            if (isAssigned)
            {
                Interaction.MsgBox(languageBLL.GetByLabel(SingletonSession.Instancia.User.LanguageId, "DELETE_ROLE_ERROR") ?? "No se puede eliminar un perfil si tiene usuarios asignados");
            }
            roleBLL.DeleteRole(auxRole);
            FillCombos();
            ShowRole(true);
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            var user = (UserDTO)this.CmbUsers.SelectedItem!;
            var role = (Role)this.CmbRoles.SelectedItem!;
            userBLL.AssignRole(role, user);
        }

        private void FrmManageProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);
        }
    }
}
