using BE.Entities;
using DAL;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleBLL : IRoleBLL
    {
        internal Role? _role = null;
        internal IRoleDAL _roleDAL;

        public RoleBLL(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public IList<Permission> GetPermissions()
        {
            return _roleDAL.GetPermissions();
        }

        public IList<Role> GetRoles()
        {
            return _roleDAL.GetRoles();
        }

        public void FillRoleComponent(Role role)
        {
            _roleDAL.FillRoleComponent(role);
        }

        public void SaveComponent(RoleComponent component, bool isRole)
        {
            _roleDAL.SaveComponent(component, isRole);
        }

        public IList<RoleComponent> GetAll(string roleComponentId)
        {
            return _roleDAL.GetAll(roleComponentId);
        }

        public void SaveComponent(RoleComponent roleSelected)
        {
            _roleDAL.SaveComponent(roleSelected);
        }

        public void DeleteRole(RoleComponent role)
        {
            _roleDAL.DeleteRole(role);
        }

        public bool IsAssigned(Role auxRole)
        {
            return _roleDAL.IsAssigned(auxRole);
        }
    }
}
