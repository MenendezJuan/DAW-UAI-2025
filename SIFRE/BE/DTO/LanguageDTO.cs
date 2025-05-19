using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DTO
{
    public class LanguageDTO
    {
        public LanguageDTO() { }
        public LanguageDTO(string language) {
            Name = language;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TranslationDTO> Translations { get; set; } = new List<TranslationDTO>();

    }
}
