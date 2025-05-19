using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BE.DTO;
using BE.Entities;
using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using BE.Enums;

namespace DAL
{
    public class NominationDAL : INominationDAL
    {
        private readonly DatabaseHelper dbHelper;

        public NominationDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        public void AddNomination(Nomination nomination)
        {
            string query = @"
                INSERT INTO Nominations (NominatorUserId, NomineeUserId, CategoryId, StatusId, Comments, CreatedBy, CreatedAt) 
                OUTPUT INSERTED.Id 
                VALUES (@NominatorUserId, @NomineeUserId, @CategoryId, @StatusId, @Comments, @CreatedBy, @CreatedAt)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NominatorUserId", nomination.NominatorUserId),
                new SqlParameter("@NomineeUserId", nomination.NomineeUserId),
                new SqlParameter("@CategoryId", nomination.CategoryId),
                new SqlParameter("@StatusId", nomination.StatusId),
                new SqlParameter("@Comments", nomination.Comments),
                new SqlParameter("@CreatedBy", nomination.CreatedBy.Id),
                new SqlParameter("@CreatedAt", nomination.CreatedAt)
            };

            int nominationId = (int)dbHelper.ExecuteScalar(query, CommandType.Text, parameters);

            // Insert comment
            string commentQuery = "INSERT INTO NominationComments (NominationId, Comment, CreatedBy, CreatedAt) VALUES (@NominationId, @Comment, @CreatedBy, @CreatedAt)";
            SqlParameter[] commentParameters = new SqlParameter[]
            {
                new SqlParameter("@NominationId", nominationId),
                new SqlParameter("@Comment", nomination.Comments),
                new SqlParameter("@CreatedBy", nomination.CreatedBy.Id),
                new SqlParameter("@CreatedAt", nomination.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(commentQuery, CommandType.Text, commentParameters);

            // Insert history
            string historyQuery = "INSERT INTO NominationHistory (NominationId, StatusId, CreatedBy, CreatedAt) VALUES (@NominationId, @StatusId, @CreatedBy, @CreatedAt)";
            SqlParameter[] historyParameters = new SqlParameter[]
            {
                new SqlParameter("@NominationId", nominationId),
                new SqlParameter("@StatusId", nomination.StatusId),
                new SqlParameter("@CreatedBy", nomination.CreatedBy.Id),
                new SqlParameter("@CreatedAt", nomination.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(historyQuery, CommandType.Text, historyParameters);
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT Id, FirstName + ' ' + LastName AS FullName FROM Users";
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                users.Add(new User
                {
                    Id = row.Field<Guid>("Id"),
                    FirstName = row.Field<string>("FullName")!
                });
            }

            return users;
        }

        public int GetUserNominationsCount(Guid userId, DateTime fromDate)
        {
            string query = "SELECT COUNT(*) FROM Nominations WHERE NominatorUserId = @UserId AND CreatedAt >= @FromDate AND CreatedAt < @ToDate";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@FromDate", new DateTime(fromDate.Year, fromDate.Month, 1)),
                new SqlParameter("@ToDate", new DateTime(fromDate.Year, fromDate.Month, 1).AddMonths(1))
            };

            object result = dbHelper.ExecuteScalar(query, CommandType.Text, parameters);
            return Convert.ToInt32(result);
        }

        public List<RecognitionCategory> GetRecognitionCategories()
        {
            List<RecognitionCategory> categories = new List<RecognitionCategory>();
            string query = "SELECT Id, Name FROM RecognitionCategories";
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                categories.Add(new RecognitionCategory
                {
                    Id = row.Field<int>("Id"),
                    Name = row.Field<string>("Name")!
                });
            }

            return categories;
        }

        public List<NominationCommentDTO> GetNominationComments(int nominationId)
        {
            List<NominationCommentDTO> comments = new List<NominationCommentDTO>();
            string query = @"
                SELECT nc.Id, nc.Comment, u.Username AS CreatedByName, nc.CreatedAt
                FROM NominationComments nc
                INNER JOIN Users u ON nc.CreatedBy = u.Id
                WHERE nc.NominationId = @NominationId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NominationId", nominationId)
            };
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                comments.Add(new NominationCommentDTO
                {
                    Id = row.Field<int>("Id"),
                    Comment = row.Field<string>("Comment"),
                    CreatedByName = row.Field<string>("CreatedByName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt")
                });
            }

            return comments;
        }

        public List<NominationDTO> GetNominationsByUser(Guid userId)
        {
            List<NominationDTO> nominations = new List<NominationDTO>();
            string query = @"
                SELECT n.Id as NominationId, n.NominatorUserId, u1.Username AS Nominator, n.NomineeUserId, u2.Username AS Nominee, rc.Name AS Category, rc.Points, s.Name AS StatusName, n.CreatedAt
                FROM Nominations n
                INNER JOIN Users u1 ON n.NominatorUserId = u1.Id
                INNER JOIN Users u2 ON n.NomineeUserId = u2.Id
                INNER JOIN RecognitionCategories rc ON n.CategoryId = rc.Id
                INNER JOIN NominationStatuses s ON n.StatusId = s.Id
                WHERE n.NominatorUserId = @UserId OR n.NomineeUserId = @UserId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId)
            };
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                nominations.Add(new NominationDTO
                {
                    NominationId = row.Field<int>("NominationId"),
                    NominatorId = row.Field<Guid>("NominatorUserId"),
                    Nominator = row.Field<string>("Nominator"),
                    NomineeId = row.Field<Guid>("NomineeUserId"),
                    Nominee = row.Field<string>("Nominee"),
                    Category = row.Field<string>("Category"),
                    Points = row.Field<int>("Points"),
                    StatusName = row.Field<string>("StatusName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt")
                });
            }

            return nominations;
        }

        public void AddNominationHistory(NominationHistory nominationHistory)
        {
            string query = "INSERT INTO NominationHistory (NominationId, StatusId, CreatedBy, CreatedAt) VALUES (@NominationId, @StatusId, @CreatedBy, @CreatedAt)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NominationId", nominationHistory.NominationId),
                new SqlParameter("@StatusId", nominationHistory.StatusId),
                new SqlParameter("@CreatedBy", nominationHistory.CreatedBy),
                new SqlParameter("@CreatedAt", nominationHistory.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void AddNominationComment(NominationComment nominationComment)
        {
            string query = "INSERT INTO NominationComments (NominationId, Comment, CreatedBy, CreatedAt) VALUES (@NominationId, @Comment, @CreatedBy, @CreatedAt)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NominationId", nominationComment.NominationId),
                new SqlParameter("@Comment", nominationComment.Comment),
                new SqlParameter("@CreatedBy", nominationComment.CreatedBy),
                new SqlParameter("@CreatedAt", nominationComment.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void UpdateNomination(int nominationId, NominationStatuses status)
        {
            string query = "UPDATE Nominations SET StatusId = @StatusId WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StatusId", (int)status),
                new SqlParameter("@Id", nominationId)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public List<NominationHistoryDTO> GetNominationHistory(DateTime dateFrom, DateTime dateTo, Guid? collaboratorId, int? recognitionTypeId)
        {
            List<NominationHistoryDTO> history = new List<NominationHistoryDTO>();
            string query = @"
                SELECT nh.Id, nh.NominationId, n.NominatorUserId, u1.Username AS Nominator, n.NomineeUserId, u2.Username AS Nominee, rc.Name AS Category, s.Name AS StatusName, nh.CreatedAt
                FROM NominationHistory nh
                INNER JOIN Nominations n ON nh.NominationId = n.Id
                INNER JOIN Users u1 ON n.NominatorUserId = u1.Id
                INNER JOIN Users u2 ON n.NomineeUserId = u2.Id
                INNER JOIN RecognitionCategories rc ON n.CategoryId = rc.Id
                INNER JOIN NominationStatuses s ON nh.StatusId = s.Id
                WHERE nh.CreatedAt >= @DateFrom AND nh.CreatedAt < @DateTo";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@DateFrom", dateFrom),
                new SqlParameter("@DateTo", dateTo)
            };

            if (collaboratorId != null)
            {
                query += " AND (n.NominatorUserId = @CollaboratorId OR n.NomineeUserId = @CollaboratorId)";
                parameters.Add(new SqlParameter("@CollaboratorId", collaboratorId));
            }

            if (recognitionTypeId != null)
            {
                query += " AND n.CategoryId = @RecognitionTypeId";
                parameters.Add(new SqlParameter("@RecognitionTypeId", recognitionTypeId));
            }

            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters.ToArray());

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                history.Add(new NominationHistoryDTO
                {
                    Id = row.Field<int>("Id"),
                    NominationId = row.Field<int>("NominationId"),
                    NominatorId = row.Field<Guid>("NominatorUserId"),
                    Nominator = row.Field<string>("Nominator"),
                    NomineeId = row.Field<Guid>("NomineeUserId"),
                    Nominee = row.Field<string>("Nominee"),
                    Category = row.Field<string>("Category"),
                    StatusName = row.Field<string>("StatusName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt")
                });
            }

            return history;
        }
    }
}