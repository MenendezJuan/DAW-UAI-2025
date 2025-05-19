using BE.Entities;
using BE.Enums;
using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleDAL : IRoleDAL
    {
        private readonly DatabaseHelper dbHelper;

        public RoleDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        public IList<Role> GetRoles()
        {
            try
            {
                List<Role> list = new List<Role>();
                string query = "SELECT * FROM Permissions WHERE Type is null";
                SqlParameter[] parameters = [];
                DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Role role = new Role
                        {
                            Id = int.Parse(dr["Id"].ToString()!),
                            Name = dr["Name"].ToString()!,
                            Permission = null
                        };
                        list.Add(role);
                    }
                    return list;
                }
                else
                {
                    return new List<Role>();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IList<Permission> GetPermissions()
        {
            try
            {
                List<Permission> list = new List<Permission>();
                string query = "SELECT * FROM Permissions WHERE Type is not null";
                SqlParameter[] parameters = [];
                DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Permission permission = new Permission
                        {
                            Id = int.Parse(dr["Id"].ToString()!),
                            Name = dr["Name"].ToString()!,
                            Permission = (PermissionsType)Enum.Parse(typeof(PermissionsType), dr["Type"].ToString()!)
                        };
                        list.Add(permission);
                    }
                    return list;
                }
                else
                {
                    return new List<Permission>();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveComponent(RoleComponent component)
        {
            string query = $@"delete from RoleComponent where ParentPermissionId=@Id;";
            SqlParameter[] parameters =
                [
                    new SqlParameter("@Id", component.Id)
                ];
            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
            foreach (var item in component.Children)
            {
                query = $@"INSERT INTO RoleComponent (ParentPermissionId, ChildPermissionId) values (@ParentPermissionId, @ChildPermissionId);";
                parameters =
                    [
                        new SqlParameter("@ParentPermissionId", component.Id),
                        new SqlParameter("@ChildPermissionId", item.Id)
                    ];
                dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);

            }
        }

        public void SaveComponent(RoleComponent component, bool isRole)
        {
            try
            {
                string query = "Insert into Permissions (Name, Type) values(@Name, @Permission);";
                SqlParameter[] parameters =
                [
                    new SqlParameter("@Name", component.Name),
                    new SqlParameter("@Permission", !isRole ? component.Permission.ToString() : DBNull.Value)
                ];

                dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteRole(RoleComponent role)
        {
            string query = "DELETE FROM RoleComponent WHERE ParentPermissionId = @Id OR ChildPermissionId = @Id;";
            SqlParameter[] parameters =
            [
                new SqlParameter("@Id", role.Id)
            ];
            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);

            query = "DELETE FROM Permissions WHERE Id = @Id;";
            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        private RoleComponent GetComponent(int id, IList<RoleComponent> list)
        {
            RoleComponent component = list != null ? list.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && list != null)
            {
                foreach (var c in list)
                {
                    var l = GetComponent(id, c.Children);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Children);
                }
            }
            return component;
        }

        public void FillRoleComponent(Role role)
        {
            role.ClearChild();
            foreach (var item in GetAll($" = {role.Id} "))
            {
                role.AddChild(item);
            }
        }

        public IList<RoleComponent> GetAll(string roleComponentId)
        {
            string where = string.IsNullOrEmpty(roleComponentId) ? " is NULL " : roleComponentId;
            var sql = $@"with recursivo as (
                                    select sp2.ParentPermissionId, sp2.ChildPermissionId  from RoleComponent SP2
                                    where sp2.ParentPermissionId {where} --acá se va variando la familia que busco
                                    UNION ALL 
                                    select sp.ParentPermissionId, sp.ChildPermissionId from RoleComponent sp 
                                    inner join recursivo r on r.ChildPermissionId = sp.ParentPermissionId
                                    )
                                    select r.ParentPermissionId,r.ChildPermissionId,p.id,p.Name, p.Type
                                    from recursivo r 
                                    inner join Permissions p on r.ChildPermissionId = p.Id";
            try
            {
                List<RoleComponent> list = new List<RoleComponent>();
                SqlParameter[] parameters = [];
                DataSet ds = dbHelper.ExecuteDataSet(sql, CommandType.Text, parameters);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        int roleId = 0;
                        if (dr["ParentPermissionId"] != DBNull.Value)
                        {
                            roleId = int.Parse(dr["ParentPermissionId"].ToString()!);
                        }

                        int id = int.Parse(dr["id"].ToString()!);
                        string name = dr["name"].ToString()!;
                        string permission = string.Empty;
                        if (dr["Type"] != DBNull.Value)
                            permission = dr["Type"].ToString()!;

                        RoleComponent roleComponent = string.IsNullOrEmpty(permission) ? new Role() : new Permission();
                        roleComponent.Id = id;
                        roleComponent.Name = name;

                        if(!string.IsNullOrEmpty(permission))
                        {
                            roleComponent.Permission = (PermissionsType)Enum.Parse(typeof(PermissionsType), permission);
                        }

                        RoleComponent parent = GetComponent(roleId, list);

                        if(parent == null)
                        {
                            list.Add(roleComponent);
                        }
                        else
                        {
                            parent.AddChild(roleComponent);
                        }
                    }
                    return list;
                }
                else
                {
                    return new List<RoleComponent>();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool IsAssigned(Role auxRole)
        {
            string query = "SELECT COUNT(*) FROM Users u\r\n  WHERE u.RoleId = @RoleId";
            SqlParameter[] parameters =
                [
                    new SqlParameter("@RoleId", auxRole.Id)
                ];
            var result = int.Parse(dbHelper.ExecuteScalar(query, CommandType.Text, parameters).ToString());
            
            return result > 0;

        }
    }
}
