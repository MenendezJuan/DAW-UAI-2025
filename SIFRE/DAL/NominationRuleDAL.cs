using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BE.Entities;
using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using BE.DTO;

namespace DAL
{
    public class NominationRuleDAL : INominationRuleDAL
    {
        private readonly DatabaseHelper dbHelper;

        public NominationRuleDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        public void UpdateNominationRule(NominationRule rule)
        {
            string query = "UPDATE NominationRules SET RuleValue = @RuleValue, UpdatedAt = @UpdatedAt, UpdatedBy = @UpdatedBy WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RuleValue", rule.RuleValue),
                new SqlParameter("@UpdatedAt", rule.UpdatedAt),
                new SqlParameter("@UpdatedBy", rule.UpdatedBy.Id),
                new SqlParameter("@Id", rule.Id)
            };

            dbHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public List<NominationRuleDTO> GetNominationRules()
        {
            List<NominationRuleDTO> rules = new List<NominationRuleDTO>();
            string query = @"
                SELECT nr.Id, nr.RuleName, nr.RuleValue, nr.Description, nr.IsActive, nr.CreatedAt, u1.Username AS CreatedBy, nr.UpdatedAt, u2.Username AS UpdatedBy
                FROM NominationRules nr
                LEFT JOIN Users u1 ON nr.CreatedBy = u1.Id
                LEFT JOIN Users u2 ON nr.UpdatedBy = u2.Id";
            DataSet ds = dbHelper.ExecuteDataSet(query, CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rules.Add(new NominationRuleDTO
                {
                    Id = row.Field<int>("Id"),
                    RuleName = row.Field<string>("RuleName"),
                    RuleValue = row.Field<string>("RuleValue"),
                    Description = row.Field<string>("Description"),
                    IsActive = row.Field<bool>("IsActive"),
                    CreatedAt = row.Field<DateTime>("CreatedAt"),
                    CreatedBy = row.Field<string>("CreatedBy"),
                    UpdatedAt = row.Field<DateTime?>("UpdatedAt"),
                    UpdatedBy = row.Field<string>("UpdatedBy")
                });
            }

            return rules;
        }
    }
}