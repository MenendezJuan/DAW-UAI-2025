using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Permission : RoleComponent
    {
        public override IList<RoleComponent> Children {
            get {  return new List<RoleComponent>(); }
        }

        public override void AddChild(RoleComponent c)
        {
        }

        public override void ClearChild()
        {
        }
    }
}
