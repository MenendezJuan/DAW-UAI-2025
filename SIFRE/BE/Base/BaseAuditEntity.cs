using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Entities;

namespace BE.Base
{
    public abstract class BaseAuditEntity
    {
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public User UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
