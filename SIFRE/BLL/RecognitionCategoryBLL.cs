using System;
using System.Collections.Generic;
using Infrastructure.Interfaces.DAL;
using Infrastructure.Interfaces.BLL;
using BE.Entities;
using BE.DTO;

namespace BLL
{
    public class RecognitionCategoryBLL : IRecognitionCategoryBLL
    {
        private readonly IRecognitionCategoryDAL _recognitionCategoryDAL;

        public RecognitionCategoryBLL(IRecognitionCategoryDAL recognitionCategoryDAL)
        {
            _recognitionCategoryDAL = recognitionCategoryDAL;
        }

        public void AddRecognitionCategory(RecognitionCategory category)
        {
            category.CreatedAt = DateTime.Now;
            _recognitionCategoryDAL.AddRecognitionCategory(category);
        }

        public void UpdateRecognitionCategory(RecognitionCategory category)
        {
            category.UpdatedAt = DateTime.Now;
            _recognitionCategoryDAL.UpdateRecognitionCategory(category);
        }

        public void DeleteRecognitionCategory(int categoryId)
        {
            _recognitionCategoryDAL.DeleteRecognitionCategory(categoryId);
        }

        public List<RecognitionCategoryDTO> GetRecognitionCategories()
        {
            return _recognitionCategoryDAL.GetRecognitionCategories();
        }
    }
}