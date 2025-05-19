using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BackupBLL : IBackupBLL
    {
        private IBackupDAL backupDAL;
        public BackupBLL(IBackupDAL backupDAL)
        {
            this.backupDAL = backupDAL;
        }

        public void CreateBackup(string path)
        {
            backupDAL.CreateBackup(path);
        }

        public void RestoreBackup(string path)
        {
            backupDAL.RestoreBackup(path);
        }
    }
}
