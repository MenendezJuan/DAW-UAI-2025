using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Product { get; set; }
        public long Points { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
