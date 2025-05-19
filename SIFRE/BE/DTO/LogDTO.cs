using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DTO
{
    public class LogDTO
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Message { get; set; }
        public LogType Type { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
