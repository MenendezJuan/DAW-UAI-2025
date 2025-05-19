using BE.Base;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public abstract class RoleComponent
    {
        public abstract IList<RoleComponent> Children { get; }
        public abstract void AddChild(RoleComponent c);
        public abstract void ClearChild();
        public int Id { get; set; }
        public string Name { get; set; }
        public PermissionsType? Permission {  get; set; }    
    }
}
