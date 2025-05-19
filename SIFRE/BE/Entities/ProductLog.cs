using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    [Serializable]
    public class ProductLog
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long Points { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsBlocked { get; set; }

    }
}
