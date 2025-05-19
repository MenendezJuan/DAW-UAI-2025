using BE.Entities;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public static class RoleHelper
    {
        public static bool RoleExists(RoleComponent roleSelected, PermissionsType id)
        {
            bool exists = false;

            if (roleSelected.Permission.Equals(id))
            {
                exists = true;
            }
            else
            {
                foreach (var item in roleSelected.Children)
                {
                    exists = RoleExists(item, id);
                    if (exists) return true;

                }
            }

            return exists;
        }

        public static bool RoleExists(RoleComponent roleSelected, int id)
        {
            bool exists = false;

            if (roleSelected.Id.Equals(id))
            {
                exists = true;
            }
            else
            {
                foreach (var item in roleSelected.Children)
                {
                    exists = RoleExists(item, id);
                    if (exists) return true;

                }
            }

            return exists;
        }

    }
}
