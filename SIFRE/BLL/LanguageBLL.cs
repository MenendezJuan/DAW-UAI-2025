using BE.DTO;
using BE.Entities;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LanguageBLL : ILanguageBLL
    {
        ILanguageDAL _languageDAL;
        public LanguageBLL(ILanguageDAL languageDAL)
        {
            _languageDAL = languageDAL;
        }

        public void AddLabel(BE.Entities.Label label)
        {
            _languageDAL.AddLabel(label);
        }

        public void AddTranslation(Translation translation)
        {
            _languageDAL.AddTranslation(translation);
        }

        public void Delete(int pLanguageId)
        {
            _languageDAL.Delete(pLanguageId);
        }

        public void DeleteLabel(int labelId)
        {
            _languageDAL.DeleteLabel(labelId);
        }

        public void DeleteTranslation(int languageId, int labelId)
        {
            _languageDAL.DeleteTranslation(languageId, labelId);
        }

        public LanguageDTO? GetById(int pLanguageId, bool withTranslation = false)
        {
            return _languageDAL.GetById(pLanguageId, withTranslation);
        }

        public List<LanguageDTO> GetAllLanguages(bool withTranslation = false)
        {
            return _languageDAL.ListLanguages(withTranslation);
        }

        public List<TranslationDTO> GetAllTranslations(int pLanguageId)
        {
            return _languageDAL.ListTranslations(pLanguageId);
        }

        public List<BE.Entities.Label> GetLabels()
        {
            return _languageDAL.GetLabels();
        }

        public bool LabelExists(string labelName)
        {
            return _languageDAL.LabelExists(labelName);
        }

        public void Modify(Language pLanguage)
        {
            _languageDAL.Modify(pLanguage);
        }

        public void ModifyTranslation(Translation translation, int languageId)
        {
            _languageDAL.ModifyTranslation(translation, languageId);
        }

        public void Save(LanguageDTO pLanguage)
        {
            _languageDAL.Save(pLanguage);
        }

        public string? GetByLabel(int languageId, string v)
        {
            return _languageDAL.GetByLabel(languageId, v);
        }
    }
}
