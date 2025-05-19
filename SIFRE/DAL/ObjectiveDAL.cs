using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BE.DTO;
using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using BE.Entities;
using Infrastructure.Session;

namespace DAL
{
    public class ObjectiveDAL : IObjectiveDAL
    {
        private readonly DatabaseHelper dbHelper;

        public ObjectiveDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        public List<RewardPolicyDTO> GetRewardPolicies()
        {
            List<RewardPolicyDTO> policies = new List<RewardPolicyDTO>();
            string query = @"
                SELECT rp.Id, rp.PolicyName, rp.Description, rp.ConversionRate, rp.AccumulationLimit, rp.EffectiveFrom, rp.EffectiveTo, rp.IsActive, 
                       pc.Name AS CategoryName, u1.Username AS CreatedByName, rp.CreatedAt, u2.Username AS UpdatedByName, rp.UpdatedAt
                FROM RewardPolicies rp
                LEFT JOIN PolicyCategories pc ON rp.CategoryId = pc.Id
                LEFT JOIN Users u1 ON rp.CreatedBy = u1.Id
                LEFT JOIN Users u2 ON rp.UpdatedBy = u2.Id";
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                policies.Add(new RewardPolicyDTO
                {
                    Id = row.Field<int>("Id"),
                    PolicyName = row.Field<string>("PolicyName"),
                    Description = row.Field<string>("Description"),
                    ConversionRate = row.Field<decimal>("ConversionRate"),
                    AccumulationLimit = row.Field<decimal>("AccumulationLimit"),
                    EffectiveFrom = row.Field<DateTime>("EffectiveFrom"),
                    EffectiveTo = row.Field<DateTime?>("EffectiveTo"),
                    IsActive = row.Field<bool>("IsActive"),
                    CategoryName = row.Field<string>("CategoryName"),
                    CreatedByName = row.Field<string>("CreatedByName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt"),
                    UpdatedByName = row.Field<string>("UpdatedByName"),
                    UpdatedAt = row.Field<DateTime?>("UpdatedAt")
                });
            }

            return policies;
        }

        public void AddRewardPolicy(RewardPolicy policy)
        {
            string query = @"
                INSERT INTO RewardPolicies (PolicyName, Description, ConversionRate, AccumulationLimit, EffectiveFrom, EffectiveTo, IsActive, CategoryId, CreatedBy, CreatedAt)
                VALUES (@PolicyName, @Description, @ConversionRate, @AccumulationLimit, @EffectiveFrom, @EffectiveTo, @IsActive, @CategoryId, @CreatedBy, @CreatedAt)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PolicyName", policy.PolicyName),
                new SqlParameter("@Description", policy.Description),
                new SqlParameter("@ConversionRate", policy.ConversionRate),
                new SqlParameter("@AccumulationLimit", policy.AccumulationLimit),
                new SqlParameter("@EffectiveFrom", policy.EffectiveFrom),
                new SqlParameter("@EffectiveTo", policy.EffectiveTo.HasValue ? (object)policy.EffectiveTo.Value : DBNull.Value),
                new SqlParameter("@IsActive", policy.IsActive),
                new SqlParameter("@CategoryId", policy.CategoryId.HasValue ? (object)policy.CategoryId.Value : DBNull.Value),
                new SqlParameter("@CreatedBy", policy.CreatedBy.Id),
                new SqlParameter("@CreatedAt", policy.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
            
        }

        public void UpdateRewardPolicy(RewardPolicy policy)
        {
            string query = @"
                UPDATE RewardPolicies
                SET PolicyName = @PolicyName, Description = @Description, ConversionRate = @ConversionRate, AccumulationLimit = @AccumulationLimit, 
                    EffectiveFrom = @EffectiveFrom, EffectiveTo = @EffectiveTo, IsActive = @IsActive, 
                    UpdatedBy = @UpdatedBy, UpdatedAt = @UpdatedAt
                WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PolicyName", policy.PolicyName),
                new SqlParameter("@Description", policy.Description),
                new SqlParameter("@ConversionRate", policy.ConversionRate),
                new SqlParameter("@AccumulationLimit", policy.AccumulationLimit),
                new SqlParameter("@EffectiveFrom", policy.EffectiveFrom),
                new SqlParameter("@EffectiveTo", policy.EffectiveTo.HasValue ? (object)policy.EffectiveTo.Value : DBNull.Value),
                new SqlParameter("@IsActive", policy.IsActive),
                new SqlParameter("@UpdatedBy", policy.UpdatedBy.Id),
                new SqlParameter("@UpdatedAt", DateTime.Now),
                new SqlParameter("@Id", policy.Id)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void DeleteRewardPolicy(int policyId)
        {
            string query = "DELETE FROM RewardPolicies WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", policyId)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public List<PolicyCategoryDTO> GetPolicyCategories()
        {
            List<PolicyCategoryDTO> categories = new List<PolicyCategoryDTO>();
            string query = @"
                SELECT pc.Id, pc.Name, pc.Description, u1.Username AS CreatedByName, pc.CreatedAt, u2.Username AS UpdatedByName, pc.UpdatedAt
                FROM PolicyCategories pc
                LEFT JOIN Users u1 ON pc.CreatedBy = u1.Id
                LEFT JOIN Users u2 ON pc.UpdatedBy = u2.Id";
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                categories.Add(new PolicyCategoryDTO
                {
                    Id = row.Field<int>("Id"),
                    Name = row.Field<string>("Name"),
                    Description = row.Field<string>("Description"),
                    CreatedByName = row.Field<string>("CreatedByName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt"),
                    UpdatedByName = row.Field<string>("UpdatedByName"),
                    UpdatedAt = row.Field<DateTime?>("UpdatedAt")
                });
            }

            return categories;
        }

        public List<ObjectiveHistoryDTO> GetObjectiveHistory(DateTime dateFrom, DateTime dateTo, Guid? collaboratorId)
        {
            List<ObjectiveHistoryDTO> history = new List<ObjectiveHistoryDTO>();
            string query = @"
        SELECT 
            oh.Id, 
            o.AssignedUserId as CollaboratorId, 
            COALESCE(u.FirstName, '') + ' ' + COALESCE(u.LastName, '') AS Collaborator,
            oh.ObjectiveId, 
            o.Title AS Objective, 
            CAST(oh.Progress AS VARCHAR) AS Progress, 
            oh.CreatedBy, 
            COALESCE(u2.FirstName, '') + ' ' + COALESCE(u2.LastName, '') AS CreatedByName,
            os.Name AS StatusName, 
            oh.CreatedAt
        FROM ObjectiveHistory oh
        INNER JOIN Objectives o ON oh.ObjectiveId = o.Id
        INNER JOIN Users u ON o.AssignedUserId = u.Id
        INNER JOIN Users u2 ON oh.CreatedBy = u2.Id
        INNER JOIN ObjectiveStatuses os ON oh.StatusId = os.Id
        WHERE oh.CreatedAt BETWEEN @DateFrom AND @DateTo";

            if (collaboratorId.HasValue)
            {
                query += " AND o.AssignedUserId = @CollaboratorId";
            }

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@DateFrom", dateFrom),
        new SqlParameter("@DateTo", dateTo),
        collaboratorId.HasValue
            ? new SqlParameter("@CollaboratorId", collaboratorId.Value)
            : new SqlParameter("@CollaboratorId", DBNull.Value)
            };

            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                history.Add(new ObjectiveHistoryDTO
                {
                    Id = row.Field<int>("Id"),
                    CollaboratorId = row.Field<Guid>("CollaboratorId"),
                    Collaborator = row.Field<string>("Collaborator"),
                    ObjectiveId = row.Field<int>("ObjectiveId"),
                    Objective = row.Field<string>("Objective"),
                    Progress = row.Field<string>("Progress"),
                    CreatedBy = row.Field<Guid>("CreatedBy"),
                    CreatedByName = row.Field<string>("CreatedByName"),
                    StatusName = row.Field<string>("StatusName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt")
                });
            }

            return history;
        }

        public List<ObjectiveDTO> GetObjectives()
        {
            List<ObjectiveDTO> objectives = new List<ObjectiveDTO>();
            string query = @"
                SELECT o.Id, o.Title, o.AssignedUserId, o.Description, o.StartDate, o.EndDate, u1.FirstName + ' ' + u1.LastName AS ResponsibleUserName, 
                       u2.FirstName + ' ' + u2.LastName AS AssignedUserName, os.Name AS StatusName, op.Name AS PriorityName, 
                       oc.Name AS CategoryName, o.Progress, o.ReviewDate, o.PointsAssigned, 
                       rp.PolicyName AS RewardPolicyName, u3.Username AS CreatedByName, o.CreatedAt, u4.Username AS UpdatedByName, o.UpdatedAt
                FROM Objectives o
                INNER JOIN Users u1 ON o.ResponsibleUserId = u1.Id
                INNER JOIN Users u2 ON o.AssignedUserId = u2.Id
                INNER JOIN ObjectiveStatuses os ON o.StatusId = os.Id
                INNER JOIN ObjectivePriorities op ON o.PriorityId = op.Id
                INNER JOIN ObjectiveCategories oc ON o.CategoryId = oc.Id
                INNER JOIN RewardPolicies rp ON o.RewardPolicyId = rp.Id
                INNER JOIN Users u3 ON o.CreatedBy = u3.Id
                LEFT JOIN Users u4 ON o.UpdatedBy = u4.Id";
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                objectives.Add(new ObjectiveDTO
                {
                    Id = row.Field<int>("Id"),
                    Title = row.Field<string>("Title"),
                    Description = row.Field<string>("Description"),
                    StartDate = row.Field<DateTime>("StartDate"),
                    EndDate = row.Field<DateTime>("EndDate"),
                    ResponsibleUserName = row.Field<string>("ResponsibleUserName"),
                    AssignedUserId = row.Field<Guid>("AssignedUserId"),
                    AssignedUserName = row.Field<string>("AssignedUserName"),
                    StatusName = row.Field<string>("StatusName"),
                    PriorityName = row.Field<string>("PriorityName"),
                    CategoryName = row.Field<string>("CategoryName"),
                    Progress = row.Field<int>("Progress"),
                    PointsAssigned = row.Field<int>("PointsAssigned"),
                    RewardPolicyName = row.Field<string>("RewardPolicyName"),
                    CreatedByName = row.Field<string>("CreatedByName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt"),
                    UpdatedByName = row.Field<string>("UpdatedByName"),
                    UpdatedAt = row.Field<DateTime?>("UpdatedAt")
                });
            }

            return objectives;
        }

        public void AddObjective(Objective objective)
        {
            string query = @"
                INSERT INTO Objectives (Title, Description, StartDate, EndDate, ResponsibleUserId, AssignedUserId, StatusId, PriorityId, CategoryId, 
                                        Progress, ReviewDate, PointsAssigned, RewardPolicyId, CreatedBy, CreatedAt)
                OUTPUT INSERTED.Id
                VALUES (@Title, @Description, @StartDate, @EndDate, @ResponsibleUserId, @AssignedUserId, @StatusId, @PriorityId, @CategoryId, 
                        @Progress, @ReviewDate, @PointsAssigned, @RewardPolicyId, @CreatedBy, @CreatedAt)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Title", objective.Title),
                new SqlParameter("@Description", objective.Description),
                new SqlParameter("@StartDate", objective.StartDate),
                new SqlParameter("@EndDate", objective.EndDate),
                new SqlParameter("@ResponsibleUserId", objective.ResponsibleUserId),
                new SqlParameter("@AssignedUserId", objective.AssignedUserId),
                new SqlParameter("@StatusId", objective.StatusId),
                new SqlParameter("@PriorityId", objective.PriorityId),
                new SqlParameter("@CategoryId", objective.CategoryId),
                new SqlParameter("@Progress", objective.Progress),
                new SqlParameter("@ReviewDate", objective.ReviewDate.HasValue ? (object)objective.ReviewDate.Value : DBNull.Value),
                new SqlParameter("@PointsAssigned", objective.PointsAssigned),
                new SqlParameter("@RewardPolicyId", objective.RewardPolicyId),
                new SqlParameter("@CreatedBy", objective.ResponsibleUserId),
                new SqlParameter("@CreatedAt", objective.CreatedAt)
            };

            int newId = (int)dbHelper.ExecuteScalar(query, CommandType.Text, parameters);
            objective.Id = newId;

            string historyQuery = @"
                INSERT INTO ObjectiveHistory (ObjectiveId, StatusId, Progress, CreatedBy, CreatedAt)
                VALUES (@ObjectiveId, @StatusId, @Progress, @CreatedBy, @CreatedAt)";
            SqlParameter[] historyParameters = new SqlParameter[]
            {
                new SqlParameter("@ObjectiveId", objective.Id),
                new SqlParameter("@StatusId", objective.StatusId),
                new SqlParameter("@Progress", objective.Progress),
                new SqlParameter("@CreatedBy", objective.ResponsibleUserId),
                new SqlParameter("@CreatedAt", objective.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(historyQuery, CommandType.Text, historyParameters);

            string commentQuery = @"
                INSERT INTO ObjectiveComments (ObjectiveId, Comment, CreatedBy, CreatedAt)
                VALUES (@ObjectiveId, @Comment, @CreatedBy, @CreatedAt)";
            SqlParameter[] commentParameters = new SqlParameter[]
            {
                new SqlParameter("@ObjectiveId", objective.Id),
                new SqlParameter("@Comment", "Objetivo creado"),
                new SqlParameter("@CreatedBy", objective.ResponsibleUserId),
                new SqlParameter("@CreatedAt", objective.CreatedAt)
            };

            dbHelper.ExecuteNonQuery(commentQuery, CommandType.Text, commentParameters);
        }

        public void UpdateObjective(ObjectiveDTO objective, string comment = "")
        {
            int statusId = 0;
            switch(objective.StatusName)
            {
                case "Pendiente":
                    statusId = 1;
                    break;
                case "En Progreso":
                    statusId = 2;
                    break;
                case "Completado":
                    statusId = 3;
                    break;
                case "En Espera":
                    statusId = 4;
                    break;
            }
            string query = @"
                UPDATE Objectives
                SET StatusId = @StatusId, Progress = @Progress, ReviewDate = @ReviewDate, UpdatedBy = @UpdatedBy, UpdatedAt = @UpdatedAt
                WHERE Id = @Id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StatusId", statusId),
                new SqlParameter("@Progress", objective.Progress),
                new SqlParameter("@ReviewDate", objective.ReviewDate.HasValue ? (object)objective.ReviewDate.Value : DBNull.Value),
                new SqlParameter("@UpdatedBy", SingletonSession.Instancia.User.Id),
                new SqlParameter("@UpdatedAt", DateTime.Now),
                new SqlParameter("@Id", objective.Id)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);

            string historyQuery = @"
                INSERT INTO ObjectiveHistory (ObjectiveId, StatusId, Progress, CreatedBy, CreatedAt)
                VALUES (@ObjectiveId, @StatusId, @Progress, @CreatedBy, @CreatedAt)";



            SqlParameter[] historyParameters = new SqlParameter[]
            {
                new SqlParameter("@ObjectiveId", objective.Id),
                new SqlParameter("@StatusId", statusId),
                new SqlParameter("@Progress", objective.Progress),
                new SqlParameter("@CreatedBy", SingletonSession.Instancia.User.Id),
                new SqlParameter("@CreatedAt", DateTime.Now)
            };

            dbHelper.ExecuteNonQuery(historyQuery, CommandType.Text, historyParameters);

            string commentQuery = @"
                INSERT INTO ObjectiveComments (ObjectiveId, Comment, CreatedBy, CreatedAt)
                VALUES (@ObjectiveId, @Comment, @CreatedBy, @CreatedAt)";
            SqlParameter[] commentParameters = new SqlParameter[]
            {
                new SqlParameter("@ObjectiveId", objective.Id),
                new SqlParameter("@Comment", comment),
                new SqlParameter("@CreatedBy", SingletonSession.Instancia.User.Id),
                new SqlParameter("@CreatedAt", DateTime.Now)
            };

            dbHelper.ExecuteNonQuery(commentQuery, CommandType.Text, commentParameters);
        }

        public void DeleteObjective(int objectiveId)
        {
            string query = "DELETE FROM Objectives WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", objectiveId)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public List<ObjectiveCommentDTO> GetObjectiveComments(int objectiveId)
        {
            List<ObjectiveCommentDTO> comments = new List<ObjectiveCommentDTO>();
            string query = @"
                SELECT oc.Id, oc.Comment, oc.CreatedBy, u.Username AS CreatedByName, oc.CreatedAt
                FROM ObjectiveComments oc
                INNER JOIN Users u ON oc.CreatedBy = u.Id
                WHERE oc.ObjectiveId = @ObjectiveId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ObjectiveId", objectiveId)
            };
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text, parameters);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                comments.Add(new ObjectiveCommentDTO
                {
                    Id = row.Field<int>("Id"),
                    Comment = row.Field<string>("Comment"),
                    CreatedByName = row.Field<string>("CreatedByName"),
                    CreatedAt = row.Field<DateTime>("CreatedAt")
                });
            }

            return comments;
        }
    }
}