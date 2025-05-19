using BE.Base;
using BE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Language : BaseEntity
    {
        public Language() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TranslationDTO> Translations { get; set; } = new List<TranslationDTO>();
    }
}
