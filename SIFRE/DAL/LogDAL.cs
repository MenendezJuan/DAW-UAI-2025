using BE.DTO;
using BE.Entities;
using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LogDAL : ILogDAL
    {
        private readonly DatabaseHelper dbHelper;
        private ICheckDigitDAL checkDigitDAL;
        public LogDAL(ICheckDigitDAL checkDigitDAL)
        {
            dbHelper = new DatabaseHelper();
            this.checkDigitDAL = checkDigitDAL;
        }

        public List<LogDTO> GetLogs(LogType? type, string module, DateTime? dateFrom, DateTime? dateTo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string query = @" SELECT 
                    Logs.Id,
                    Logs.Message,
                    Logs.Type,
                    Logs.Module,
                    Logs.CreatedAt,
                    Users.Username AS CreatedBy
                FROM 
                    Logs
                INNER JOIN 
                    Users ON Logs.CreatedBy = Users.Id
                WHERE 1=1";

            if (type.HasValue)
            {
                query += " AND Type = @Type";
                parameters.Add(new SqlParameter("@Type", type));
            }

            if (!string.IsNullOrEmpty(module))
            {
                query += " AND Module = @Module";
                parameters.Add(new SqlParameter("@Module", module));
            }

            if (dateFrom.HasValue)
            {
                query += " AND CreatedAt >= @DateFrom";
                parameters.Add(new SqlParameter("@DateFrom", dateFrom.Value));
            }

            if (dateTo.HasValue)
            {
                query += " AND CreatedAt <= @DateTo";
                parameters.Add(new SqlParameter("@DateTo", dateTo.Value));
            }

            DataSet dataSet = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters.ToArray());

            List<LogDTO> logs = new List<LogDTO>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                logs.Add(new LogDTO
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Module = row["Module"].ToString(),
                    Message = row["Message"].ToString(),
                    Type = (LogType)Enum.Parse(typeof(LogType), row["Type"].ToString()),
                    CreatedAt = DateTime.Parse(row["CreatedAt"].ToString()),
                    CreatedBy = row["CreatedBy"].ToString()
                });
            }

            return logs;
        }

        public List<ProductLog> GetLogs(string? productId, DateTime? dateFrom, DateTime? dateTo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            StringBuilder query = new StringBuilder("SELECT * FROM ProductLogs WHERE 1=1");

            if (!string.IsNullOrEmpty(productId))
            {
                query.Append(" AND ProductId = @ProductId");
                parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = int.Parse(productId) });
            }

            if (dateFrom.HasValue)
            {
                query.Append(" AND StartDate >= @DateFrom");
                parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime) { Value = dateFrom.Value });
            }

            if (dateTo.HasValue)
            {
                query.Append(" AND StartDate <= @DateTo");
                parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime) { Value = dateTo.Value });
            }

            DataSet ds = dbHelper.ExecuteDataSet(query.ToString(), CommandType.Text, parameters.ToArray());

            List<ProductLog> logs = new List<ProductLog>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    logs.Add(new ProductLog
                    {
                        Id = int.Parse(row["Id"].ToString()!),
                        ProductId = int.Parse(row["ProductId"].ToString()!),
                        ProductName = row["ProductName"].ToString()!,
                        Description = row["Description"].ToString()!,
                        Points = long.Parse(row["Points"].ToString()!),
                        Category = row["Category"].ToString()!,
                        StartDate = DateTime.Parse(row["StartDate"].ToString()!),
                        IsBlocked = bool.Parse(row["IsBlocked"].ToString()!)
                    });
                }
            }

            return logs;
        }

        public void Save(Log log)
        {
            string query = "INSERT INTO Logs (Message, Type, Module, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt) VALUES (@Message, @Type, @Module, @CreatedBy, @CreatedAt, @UpdatedBy, @UpdatedAt);";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Message", log.Message),
                new SqlParameter("@Type", log.Type),
                new SqlParameter("@Module", log.Module),
                new SqlParameter("@CreatedBy", log.CreatedBy != null ? log.CreatedBy.Id : (object)DBNull.Value),
                new SqlParameter("@CreatedAt", log.CreatedAt),
                new SqlParameter("@UpdatedBy", log.UpdatedBy != null ? log.UpdatedBy.Id : (object)DBNull.Value),
                new SqlParameter("@UpdatedAt", log.UpdatedAt != DateTime.MinValue ? log.UpdatedAt : (object)DBNull.Value)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Save(ProductLog productLog)
        {
            string query = @"INSERT INTO ProductLogs (ProductName, ProductId, Description, Points, Category, StartDate, IsBlocked) 
                     VALUES (@ProductName, @ProductId, @Description, @Points, @Category, @StartDate, @IsBlocked)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = productLog.ProductName },
                new SqlParameter("@ProductId", SqlDbType.Int) { Value = productLog.ProductId },
                new SqlParameter("@Description", SqlDbType.VarChar) { Value = productLog.Description },
                new SqlParameter("@Points", SqlDbType.BigInt) { Value = productLog.Points },
                new SqlParameter("@Category", SqlDbType.VarChar) { Value = productLog.Category },
                new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = productLog.StartDate },
                new SqlParameter("@IsBlocked", SqlDbType.Bit) { Value = productLog.IsBlocked }
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void SetProduct(int selectedProductId)
        {
            string query = $"UPDATE Products SET EndDate = NULL WHERE Id = {selectedProductId};";
            dbHelper.ExecuteNonQuery(query, CommandType.Text);
            checkDigitDAL.AddCheckDigit("Products", "Id", selectedProductId.ToString());
        }
    }
}
