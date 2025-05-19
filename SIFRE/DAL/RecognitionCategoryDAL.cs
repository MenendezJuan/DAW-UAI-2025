using Microsoft.Data.SqlClient;
using BE.Entities;
using BE.DTO;
using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using System.Data;

namespace DAL
{
    public class RecognitionCategoryDAL : IRecognitionCategoryDAL
    {
        private readonly DatabaseHelper dbHelper;

        public RecognitionCategoryDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        public void AddRecognitionCategory(RecognitionCategory category)
        {
            string query = "INSERT INTO RecognitionCategories (Name, Description, Points, CreatedBy, CreatedAt) VALUES (@Name, @Description, @Points, @CreatedBy, @CreatedAt)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@Description", category.Description),
                new SqlParameter("@Points", category.Points),
                new SqlParameter("@CreatedBy", category.CreatedBy.Id),
                new SqlParameter("@CreatedAt", category.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void UpdateRecognitionCategory(RecognitionCategory category)
        {
            string query = "UPDATE RecognitionCategories SET Name = @Name, Description = @Description, Points = @Points, UpdatedBy = @UpdatedBy, UpdatedAt = @UpdatedAt WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@Description", category.Description),
                new SqlParameter("@Points", category.Points),
                new SqlParameter("@UpdatedBy", category.UpdatedBy.Id),
                new SqlParameter("@UpdatedAt", category.UpdatedAt),
                new SqlParameter("@Id", category.Id)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void DeleteRecognitionCategory(int categoryId)
        {
            string query = "DELETE FROM RecognitionCategories WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", categoryId)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public List<RecognitionCategoryDTO> GetRecognitionCategories()
        {
            List<RecognitionCategoryDTO> categories = new List<RecognitionCategoryDTO>();
            string query = "SELECT rc.Id, rc.Name, rc.Description, rc.Points, u1.Username AS CreatedBy, rc.CreatedAt, u2.Username AS UpdatedBy, rc.UpdatedAt " +
                           "FROM RecognitionCategories rc " +
                           "LEFT JOIN Users u1 ON rc.CreatedBy = u1.Id " +
                           "LEFT JOIN Users u2 ON rc.UpdatedBy = u2.Id";
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                categories.Add(new RecognitionCategoryDTO
                {
                    Id = row.Field<int>("Id"),
                    Name = row.Field<string>("Name")!,
                    Description = row.Field<string>("Description")!,
                    Points = row.Field<int>("Points")!,
                    CreatedBy = row.Field<string>("CreatedBy")!,
                    CreatedAt = row.Field<DateTime>("CreatedAt")!,
                    UpdatedBy = row.Field<string>("UpdatedBy")!,
                    UpdatedAt = row.Field<DateTime?>("UpdatedAt")
                });
            }

            return categories;
        }
    }
}