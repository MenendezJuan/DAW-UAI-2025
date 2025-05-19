using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DAL
{
    public interface IRoleDAL
    {
        void SaveComponent(RoleComponent component, bool isRole);
        void SaveComponent(RoleComponent component);
        IList<Role> GetRoles();
        IList<Permission> GetPermissions();
        void FillRoleComponent(Role role);
        IList<RoleComponent> GetAll(string roleComponentId);
        void DeleteRole(RoleComponent role);
        bool IsAssigned(Role auxRole);
    }
}
