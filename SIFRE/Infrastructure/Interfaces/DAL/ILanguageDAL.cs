using BE.DTO;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DAL
{
    public interface ILanguageDAL
    {
        void Save(LanguageDTO pLanguage);
        int GetLastId();
        void Modify(Language pLanguage);
        void Delete(int pLanguageId);
        List<TranslationDTO> ListTranslations(int pLanguageId);
        List<Label> GetLabels();
        LanguageDTO? GetById(int pLanguageId, bool withTranslation = false);
        List<LanguageDTO> ListLanguages(bool withTranslation = false);
        void AddLabel(Label label);
        void DeleteLabel(int labelId);
        bool LabelExists(string labelName);
        void ModifyTranslation(Translation translation, int languageId);
        void DeleteTranslation(int languageId, int labelId);
        void AddTranslation(Translation translation);
        string? GetByLabel(int languageId, string v);
    }
}
