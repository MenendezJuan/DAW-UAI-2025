using BE.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Label
    {
        public Label() { }
        public Label(string name) { 
        Name = name;
        }   
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
