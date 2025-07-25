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
    // Asegurate de que esta conexión apunte a master, no a DB_SIFRE
    var connectionString = "Data Source=(local);Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True;Pooling=false";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();

        // 1. Matar conexiones activas a DB_SIFRE
        string killConnections = @"
            DECLARE @killCommand NVARCHAR(MAX) = '';
            SELECT @killCommand += 'KILL ' + CAST(session_id AS NVARCHAR) + ';'
            FROM sys.dm_exec_sessions
            WHERE database_id = DB_ID('DB_SIFRE') AND session_id <> @@SPID;
            EXEC sp_executesql @killCommand;
        ";

        using (var cmd = new SqlCommand(killConnections, connection))
        {
            cmd.ExecuteNonQuery();
        }

        // 2. Poner la base en modo SINGLE_USER
        using (var cmd = new SqlCommand("ALTER DATABASE [DB_SIFRE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", connection))
        {
            cmd.ExecuteNonQuery();
        }

        // 3. Restaurar el backup
        string restore = @"
            RESTORE DATABASE [DB_SIFRE] 
            FROM DISK = @BackupPath 
            WITH REPLACE;
        ";

        using (var cmd = new SqlCommand(restore, connection))
        {
            cmd.Parameters.AddWithValue("@BackupPath", filePath);
            cmd.ExecuteNonQuery();
        }

        // 4. Volver a MULTI_USER
        using (var cmd = new SqlCommand("ALTER DATABASE [DB_SIFRE] SET MULTI_USER;", connection))
        {
            cmd.ExecuteNonQuery();
        }
    }
}


        public void RestoreBackup3(string filePath)
        {
            var connectionString = "Data Source=(local);Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var setSingleUser = "ALTER DATABASE [DB_SIFRE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                var restore = @"
            RESTORE DATABASE [DB_SIFRE] 
            FROM DISK = @BackupPath 
            WITH REPLACE;";
                var setMultiUser = "ALTER DATABASE [DB_SIFRE] SET MULTI_USER;";

                using (var cmd = new SqlCommand(setSingleUser, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqlCommand(restore, connection))
                {
                    cmd.Parameters.AddWithValue("@BackupPath", filePath);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqlCommand(setMultiUser, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RestoreBackup2(string filePath)
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
