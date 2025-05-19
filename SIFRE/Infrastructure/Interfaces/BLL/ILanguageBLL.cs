using BE.DTO;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.BLL
{
    public interface ILanguageBLL
    {
        void Save(LanguageDTO pLanguage);
        void Delete(int pLanguageId);
        void Modify(Language pLanguage);
        LanguageDTO? GetById(int pLanguageId, bool withTranslation = false);
        List<LanguageDTO> GetAllLanguages(bool withTranslation = false);
        List<TranslationDTO> GetAllTranslations(int pLanguageId);
        List<Label> GetLabels();
        void AddLabel(Label label);
        void DeleteLabel(int labelId);
        bool LabelExists(string labelName);
        void ModifyTranslation(Translation translation, int languageId);
        void DeleteTranslation(int languageId, int labelId);
        void AddTranslation(Translation translation);
        string? GetByLabel(int languageId, string v);
    }
}
