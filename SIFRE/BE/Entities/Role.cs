using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Role : RoleComponent
    {
        private IList<RoleComponent> _components;
        public override IList<RoleComponent> Children {
            get
            {
                return _components;
            }
        }

        public Role()
        {
            _components = new List<RoleComponent>();
        }

        public override void AddChild(RoleComponent c)
        {
            _components.Add(c);
        }

        public override void ClearChild()
        {
            _components = new List<RoleComponent>();
        }
    }
}
