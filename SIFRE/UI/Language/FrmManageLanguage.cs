using BE.DTO;
using BE.Entities;
using BLL;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Mappers;
using Infrastructure.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Observer;

namespace UI.Language
{
    public partial class FrmManageLanguage : Form, IObserverForm
    {
        ILanguageBLL languageBLL;
        ILogBLL logBLL;
        List<TranslationDTO> translations = new List<TranslationDTO>();
        List<LanguageDTO> languages = new List<LanguageDTO>();
        List<BE.Entities.Label> labels = new List<BE.Entities.Label>();
        int? languageId;
        int? labelId;
        public FrmManageLanguage(ILanguageBLL languageBLL, ILogBLL logBLL)
        {
            InitializeComponent();
            this.languageBLL = languageBLL;
            this.logBLL = logBLL;
        }

        private void FrmAddLanguage_Load(object sender, EventArgs e)
        {
            DgvLabels.SelectionMode =
            DgvTranslations.SelectionMode =
            DgvLanguages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FillDataSource();
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
        }

        private void FillDataSource()
        {
            languages = languageBLL.GetAllLanguages();
            DgvLanguages.DataSource = languages;
            labels = languageBLL.GetLabels();
            DgvLabels.DataSource = labels;
            DataGridViewRow? selectedRow = null;
            if (languageId.HasValue)
            {
                var rowIndex = languages.FindIndex(lang => lang.Id == languageId.Value);
                if (rowIndex >= 0)
                {
                    DgvLanguages.Rows[rowIndex].Selected = true;
                    DgvLanguages.CurrentCell = DgvLanguages.Rows[rowIndex].Cells[0];

                    selectedRow = DgvLanguages.Rows[rowIndex];
                }
            }
            else if (DgvLanguages.Rows.Count > 0)
            {
                DgvLanguages.Rows[0].Selected = true;
                selectedRow = DgvLanguages.SelectedRows[0];
            }
            languageId = int.Parse(selectedRow!.Cells["Id"].Value.ToString()!);
            translations = languageBLL.GetAllTranslations(languageId.Value);
            DgvTranslations.DataSource = translations;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLanguage.Text))
            {
                LblError.Visible = true;
                LblError.Text = "El idioma no puede estar en blanco";
            }
            else
            {
                LblError.Visible = false;
                var langAux = languages.FirstOrDefault(f => f.Name == TxtLanguage.Text);
                if (langAux != null)
                {
                    languageBLL.Delete(langAux.Id);
                    languageId = langAux.Id == languageId ? null : languageId;
                    LblError.Visible = false;
                    logBLL.Save(new BE.Entities.Log
                    {
                        Message = $"Se borró el idioma {TxtLanguage.Text}",
                        CreatedAt = DateTime.Now,
                        CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                        Type = BE.Entities.LogType.Info,
                        Module = this.Name
                    });
                    FillDataSource();
                }
                else
                {
                    LblError.Visible = true;
                    LblError.Text = "El idioma no fue encontrado";

                }

            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLanguage.Text))
            {
                LblError.Visible = true;
                LblError.Text = "El idioma no puede estar en blanco";
            }
            else
            {
                LblError.Visible = false;
                var langAux = languages.FirstOrDefault(f => f.Name == TxtLanguage.Text);
                if (langAux != null)
                {
                    LblError.Visible = true;
                    LblError.Text = "El idioma ya existe";
                }
                else
                {
                    LblError.Visible = false;
                    languageBLL.Save(new LanguageDTO(TxtLanguage.Text));
                    logBLL.Save(new BE.Entities.Log
                    {
                        Message = $"Se creó el idioma {TxtLanguage.Text}",
                        CreatedAt = DateTime.Now,
                        CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                        Type = BE.Entities.LogType.Info,
                        Module = this.Name
                    });
                    FillDataSource();
                }

            }

        }

        private void DgvLanguages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvLanguages.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvLanguages.SelectedRows[0];

                TxtLanguage.Text = selectedRow.Cells["Name"].Value.ToString();
                languageId = int.Parse(selectedRow.Cells["Id"].Value.ToString()!);
                translations = languageBLL.GetAllTranslations(languageId.Value);
                DgvTranslations.DataSource = translations;
            }
        }

        private void DgvLabels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvLabels.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvLabels.SelectedRows[0];
                labelId = int.Parse(selectedRow.Cells["Id"].Value.ToString()!);
                TxtLabel.Text = selectedRow.Cells["Name"].Value.ToString();
            }
        }

        private void BtnAddLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLabel.Text))
            {
                LblError.Visible = true;
                LblError.Text = "La etiqueta no puede estar en blanco";
            }
            else
            {
                LblError.Visible = false;
                var labelAux = labels.FirstOrDefault(f => f.Name == TxtLabel.Text);
                if (labelAux != null)
                {
                    LblError.Visible = true;
                    LblError.Text = "La etiqueta ya existe";
                }
                else
                {
                    LblError.Visible = false;
                    languageBLL.AddLabel(new BE.Entities.Label(TxtLabel.Text));
                    logBLL.Save(new BE.Entities.Log
                    {
                        Message = $"Se creó la etiqueta {TxtLabel.Text}",
                        CreatedAt = DateTime.Now,
                        CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                        Type = BE.Entities.LogType.Info,
                        Module = this.Name
                    });
                    FillDataSource();
                }

            }
        }

        private void BtnRemoveLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLabel.Text))
            {
                LblError.Visible = true;
                LblError.Text = "La etiqueta no puede estar en blanco";
            }
            else
            {
                LblError.Visible = false;
                if (languageBLL.LabelExists(TxtLabel.Text))
                {
                    BE.Entities.Label auxLabel = labels.First(label => label.Name == TxtLabel.Text);
                    languageBLL.DeleteLabel(auxLabel.Id);
                    LblError.Visible = false;
                    logBLL.Save(new BE.Entities.Log
                    {
                        Message = $"Se borró la etiqueta {TxtLabel.Text}",
                        CreatedAt = DateTime.Now,
                        CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                        Type = BE.Entities.LogType.Info,
                        Module = this.Name
                    });
                    FillDataSource();
                }
                else
                {
                    LblError.Visible = true;
                    LblError.Text = "La etiqueta no fue encontrada";

                }

            }

        }

        private void DgvTranslations_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DgvTranslations.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvTranslations.SelectedRows[0];

                TxtTranslation.Text = selectedRow.Cells["TranslatedText"].Value.ToString();
            }
        }

        private void BtnAddTranslation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtTranslation.Text))
            {
                LblError.Visible = true;
                LblError.Text = "La etiqueta no puede estar en blanco";
            }
            else
            {
                LblError.Visible = false;
                var translationAux = translations.FirstOrDefault(f => f.LabelName == TxtLabel.Text);
                if (translationAux != null)
                {
                    LblError.Visible = true;
                    LblError.Text = "La traducción ya existe";
                }
                else
                {
                    LblError.Visible = false;
                    languageBLL.AddTranslation(new Translation() { LabelId = labelId.Value, LanguageId = languageId.Value, TranslatedText = TxtTranslation.Text });
                    logBLL.Save(new BE.Entities.Log
                    {
                        Message = $"Se creó la etiqueta {TxtLabel.Text}",
                        CreatedAt = DateTime.Now,
                        CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                        Type = BE.Entities.LogType.Info,
                        Module = this.Name
                    });
                    FillDataSource();
                }


            }
        }

        private void BtnRemoveTranslation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtTranslation.Text))
            {
                LblError.Visible = true;
                LblError.Text = "La etiqueta no puede estar en blanco";
            }
            else
            {
                LblError.Visible = false;
                var translationAux = translations.FirstOrDefault(f => f.TranslatedText == TxtTranslation.Text);
                if (translationAux == null)
                {
                    LblError.Visible = true;
                    LblError.Text = "La traducción no existe";
                }
                else
                {
                    LblError.Visible = false;
                    languageBLL.DeleteTranslation(languageId!.Value, translationAux.LabelId);
                    logBLL.Save(new BE.Entities.Log
                    {
                        Message = $"Se borró la traducción {TxtTranslation.Text}",
                        CreatedAt = DateTime.Now,
                        CreatedBy = UsersMapper.DtoToUser(SingletonSession.Instancia.User),
                        Type = BE.Entities.LogType.Info,
                        Module = this.Name
                    });
                    FillDataSource();
                }


            }

        }

        public void UpdateLanguage(UserSession session)
        {
            foreach (Control control in this.Controls)
            {
                foreach (TranslationDTO translation in session.currentLanguage.Translations)
                {
                    control.Text = control.Tag != null && control.Tag.ToString() == translation.LabelName ? translation.TranslatedText : control.Text;
                }
            }
        }

        private void FrmManageLanguage_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession.Instancia.RemoveObserver(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtTranslation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
