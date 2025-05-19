using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CheckDigitDAL : ICheckDigitDAL
    {
        private DatabaseHelper helper;
        public CheckDigitDAL()
        {
            helper = new DatabaseHelper();
        }

        public void VerifyTable(string tableName)
        {
            string query = $"SELECT * FROM {tableName};";
            DataSet dataSet = helper.ExecuteDataSet(query);

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string concatenatedValues = "";
                    foreach (object value in row.ItemArray)
                    {
                        if (value.ToString() == row["CheckDigitHorizontal"].ToString())
                            continue;

                        concatenatedValues += value.ToString();
                    }

                    string encryptedString = GetSHA256(concatenatedValues);
                    if (row["CheckDigitHorizontal"].ToString() != encryptedString)
                    {
                        throw new Exception($"Data inconsistency detected in table: {tableName} | {concatenatedValues}");
                    }
                }
            }
        }

        public void RecalculateTable(string tableName, string keyField)
        {
            string query = $"SELECT * FROM {tableName};";
            DataSet dataSet = helper.ExecuteDataSet(query);

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string concatenatedValues = "";
                    foreach (object value in row.ItemArray)
                    {
                        if (value.ToString() == row["CheckDigitHorizontal"].ToString())
                            continue;

                        concatenatedValues += value.ToString();
                    }

                    string encryptedString = GetSHA256(concatenatedValues);
                    string updateQuery = $"UPDATE {tableName} SET CheckDigitHorizontal = '{encryptedString}' WHERE {keyField} = '{row[keyField]}';";
                    helper.ExecuteNonQuery(updateQuery);
                }
            }
        }

        public void AddCheckDigit(string tableName, string keyField, string keyValue)
        {
            string query = $"SELECT * FROM {tableName} WHERE {keyField} = '{keyValue}';";
            DataSet dataSet = helper.ExecuteDataSet(query);

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                string concatenatedValues = "";
                foreach (object value in dataSet.Tables[0].Rows[0].ItemArray)
                {
                    if (value.ToString() == dataSet.Tables[0].Rows[0]["CheckDigitHorizontal"].ToString())
                        continue;

                    concatenatedValues += value.ToString();
                }

                string encryptedString = GetSHA256(concatenatedValues);
                string updateQuery = $"UPDATE {tableName} SET CheckDigitHorizontal = '{encryptedString}' WHERE {keyField} = '{keyValue}';";
                helper.ExecuteNonQuery(updateQuery);
            }
        }

        public void RecalculateVerticalDigit(string tableName, string[] columns)
        {
            foreach (string column in columns)
            {
                string query = $"SELECT {column} FROM {tableName};";
                DataSet dataSet = helper.ExecuteDataSet(query);

                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    string concatenatedValues = "";
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        concatenatedValues += row[column].ToString();
                    }

                    string encryptedString = GetSHA256(concatenatedValues);

                    string updateQuery = $"UPDATE {tableName} SET CheckDigitVertical = '{encryptedString}';";
                    helper.ExecuteNonQuery(updateQuery);
                }
            }
        }

        public bool VerifyVerticalDigit(string tableName, string[] columns)
        {
            foreach (string column in columns)
            {
                string query = $"SELECT {column}, CheckDigitVertical FROM {tableName};";
                DataSet dataSet = helper.ExecuteDataSet(query);

                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    string concatenatedValues = "";
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        concatenatedValues += row[column].ToString();
                    }

                    string calculatedDvVertical = GetSHA256(concatenatedValues);

                    if (dataSet.Tables[0].Rows[0]["CheckDigitVertical"].ToString() != calculatedDvVertical)
                    {
                        throw new Exception($"Data inconsistency detected in table: {tableName} | {concatenatedValues}");
                    }
                }
            }

            return true; // Todo está correcto
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
