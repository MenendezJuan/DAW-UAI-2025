using BE.DTO;
using BE.Entities;
using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using Infrastructure.Session;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PointDAL : IPointDAL
    {
        private readonly DatabaseHelper dbHelper;
        private ICheckDigitDAL checkDigitDAL;

        public PointDAL(ICheckDigitDAL checkDigitDAL)
        {
            dbHelper = new DatabaseHelper();
            this.checkDigitDAL = checkDigitDAL;
        }

        public long ExchangePoints(int productId, long userPoints)
        {
            string query = @"INSERT INTO Transactions (UserId, Points, ProductId, TransactionDate) 
                            VALUES (@UserId, (  SELECT Points FROM Products WHERE Id = @ProductId), @ProductId, @TransactionDate);
                              Update Users SET Points = Points - (SELECT Points FROM Products WHERE Id = @ProductId) WHERE Id = @UserId;
                            SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters =
            [
                new SqlParameter("@UserId", SingletonSession.Instancia.User.Id),
                new SqlParameter("@ProductId", productId),
                new SqlParameter("@TransactionDate", DateTime.Now)
            ];
            object result = dbHelper.ExecuteScalar(query, CommandType.Text, parameters);

            checkDigitDAL.AddCheckDigit("Transactions", "Id", result.ToString());

            query = @"SELECT Points FROM Users Where Id = @UserId";
            parameters =
            [
                new SqlParameter("@UserId", SingletonSession.Instancia.User.Id)
            ];

            return dbHelper.ExecuteScalar(query, CommandType.Text, parameters);            
        }

        public long GetPointsByUserId(Guid id)
        {
            string query = "SELECT Points FROM Users where Id = @UserId";
            SqlParameter[] parameters = [
                    new SqlParameter("@UserId", id)
                    ];
            return dbHelper.ExecuteScalar(query, CommandType.Text, parameters);
        }

        public IList<TransactionDTO> GetTransactions(bool getAll = false)
        {
            try
            {
                List<TransactionDTO> list = new List<TransactionDTO>();
                string query = $@"SELECT t.Id, u.Username, p.ProductName, t.Points, t.TransactionDate FROM Transactions t
                                    LEFT JOIN Users u ON u.Id = t.UserId
                                    LEFT JOIN Products p ON p.Id = t.ProductId" + (getAll ? string.Empty : " WHERE t.UserId = @UserId");
                SqlParameter[] parameters = getAll ? [] : [
                    new SqlParameter("@UserId", SingletonSession.Instancia.User.Id)
                    ];
                DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TransactionDTO transaction = new TransactionDTO
                        {
                            Id = int.Parse(dr["Id"].ToString()!),
                            User = dr["Username"].ToString()!,
                            Product = dr["ProductName"].ToString()!,
                            Points = long.Parse(dr["Points"].ToString()!),
                            TransactionDate = DateTime.Parse(dr["TransactionDate"].ToString()!)
                        };
                        list.Add(transaction);
                    }
                    return list.OrderBy(f => f.Id).ToList();
                }
                else
                {
                    return new List<TransactionDTO>();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<PointTransferDTO> GetPointTransfers()
        {
            List<PointTransferDTO> list = new List<PointTransferDTO>();
            string query = @"SELECT pt.Id, u.Username as Sender, u2.Username as Receiver, pt.PointsTransferred, pt.TransferDate FROM PointTransfers pt
                            LEFT JOIN Users u ON u.Id = pt.SenderUserId
                            LEFT JOIN Users u2 ON u2.Id = pt.ReceiverUserId
                            WHERE pt.SenderUserId = @UserId OR pt.ReceiverUserId = @UserId";
            SqlParameter[] parameters = [
                new SqlParameter("@UserId", SingletonSession.Instancia.User.Id)
            ];
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PointTransferDTO pointTransfer = new PointTransferDTO
                    {
                        Id = int.Parse(dr["Id"].ToString()!),
                        Sender = dr["Sender"].ToString()!,
                        Receiver = dr["Receiver"].ToString()!,
                        Points = int.Parse(dr["PointsTransferred"].ToString()!),
                        TransferDate = DateTime.Parse(dr["TransferDate"].ToString()!)
                    };
                    list.Add(pointTransfer);
                }
                return list.OrderBy(f => f.Id).ToList();
            }
            else
            {
                return new List<PointTransferDTO>();
            }
        }
        public void TransferPointsToUser(decimal value, Guid id)
        {
            string query = @"INSERT INTO PointTransfers (SenderUserId, ReceiverUserId, PointsTransferred, TransferDate) 
                            VALUES (@SenderUserId, @ReceiverUserId, @PointsTransferred, @TransferDate);
                            SELECT SCOPE_IDENTITY();
                            UPDATE Users SET Points = Points - @PointsTransferred WHERE Id = @SenderUserId;
                            UPDATE Users SET Points = Points + @PointsTransferred WHERE Id = @ReceiverUserId;";
            SqlParameter[] parameters = [
                new SqlParameter("@SenderUserId", SingletonSession.Instancia.User.Id),
                new SqlParameter("@ReceiverUserId", id),
                new SqlParameter("@PointsTransferred", value),
                new SqlParameter("@TransferDate", DateTime.Now)
            ];
            object result = dbHelper.ExecuteScalar(query, CommandType.Text, parameters);
            checkDigitDAL.AddCheckDigit("PointTransfers", "Id", result.ToString());
        }
    }
}
