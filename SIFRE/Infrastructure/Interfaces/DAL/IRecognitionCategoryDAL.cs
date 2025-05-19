using System.Collections.Generic;
using BE.DTO;
using BE.Entities;

namespace Infrastructure.Interfaces.DAL
{
    public interface IRecognitionCategoryDAL
    {
        void AddRecognitionCategory(RecognitionCategory category);
        void UpdateRecognitionCategory(RecognitionCategory category);
        void DeleteRecognitionCategory(int categoryId);
        List<RecognitionCategoryDTO> GetRecognitionCategories();
    }
}