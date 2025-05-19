using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class BackupDAL : IBackupDAL
    {
        private String DefaultBackupPath { get; set; }
        private readonly DatabaseHelper dbHelper;
        public BackupDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }
        private String GetBackupFileName(string databaseName, string path)
        {
            return $"{path}\\{databaseName}_{DateTime.Now:yyyyMMddHHmmss}.bak";
        }

        public void RestoreBackup(string path)
        {
            using (SqlConnection connection = this.dbHelper.GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    String setOfflineStatement = $"USE MASTER ALTER DATABASE {connection.Database} SET OFFLINE WITH ROLLBACK IMMEDIATE; ";
                    String restoreStatement = $"RESTORE DATABASE {connection.Database} FROM DISK = '{path}' WITH REPLACE ";
                    String setOnlineStatement = $"ALTER DATABASE {connection.Database} SET ONLINE WITH ROLLBACK IMMEDIATE;";
                    command.CommandText = $"{setOfflineStatement}{restoreStatement}{setOnlineStatement}";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateBackup(string path)
        {
            using (SqlConnection connection = this.dbHelper.GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = $"BACKUP DATABASE {connection.Database} TO DISK = '{GetBackupFileName(connection.Database, path)}'";
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // If the database engine does not have write permissions on the requested folder, it will attempt to save the backup in the default folder.
                        if (ex.Message.Contains("Cannot open backup device"))
                        {
                            command.CommandText = $"BACKUP DATABASE {connection.Database} TO DISK = '{GetBackupFileName(connection.Database, this.DefaultBackupPath)}'";
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }
            }
        }
    }
}
