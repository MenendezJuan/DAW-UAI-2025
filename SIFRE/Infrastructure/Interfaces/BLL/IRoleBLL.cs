using BE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.BLL
{
    public interface IRoleBLL
    {
        void SaveComponent(RoleComponent component, bool isRole);
        IList<Permission> GetPermissions();
        IList<Role> GetRoles();
        void FillRoleComponent(Role role);
        IList<RoleComponent> GetAll(string roleComponentId);
        void SaveComponent(RoleComponent roleSelected);
        void DeleteRole(RoleComponent role);
        bool IsAssigned(Role auxRole);
    }
}
