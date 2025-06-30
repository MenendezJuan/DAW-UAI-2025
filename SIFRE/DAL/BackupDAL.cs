using DAL.Helper;
using Infrastructure.Interfaces.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DAL
{
    public class BackupDAL : IBackupDAL
    {
        private readonly DatabaseHelper helper;

        public BackupDAL()
        {
            helper = new DatabaseHelper();
        }

        public void CreateBackup(string path)
        {
            var fileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            var backupPath = System.IO.Path.Combine(path, fileName);

            string sql = $@"
                BACKUP DATABASE [DB_SIFRE] 
                TO DISK = @BackupPath 
                WITH FORMAT, INIT, NAME = 'Full Backup of DB_SIFRE';";

            var parameters = new[]
            {
                new SqlParameter("@BackupPath", SqlDbType.NVarChar) { Value = backupPath }
            };

            helper.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public void RestoreBackup(string filePath)
        {
            // Desconectar usuarios activos antes de restaurar
            string setSingleUser = "ALTER DATABASE [DB_SIFRE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            string restore = @"
                RESTORE DATABASE [DB_SIFRE] 
                FROM DISK = @BackupPath 
                WITH REPLACE;";
            string setMultiUser = "ALTER DATABASE [DB_SIFRE] SET MULTI_USER;";

            var param = new[]
            {
                new SqlParameter("@BackupPath", SqlDbType.NVarChar) { Value = filePath }
            };

            helper.ExecuteNonQuery(setSingleUser);
            helper.ExecuteNonQuery(restore, CommandType.Text, param);
            helper.ExecuteNonQuery(setMultiUser);
        }
    }
}
