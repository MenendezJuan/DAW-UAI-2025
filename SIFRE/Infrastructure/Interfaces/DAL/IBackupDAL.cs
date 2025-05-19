using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DAL
{
    public interface IBackupDAL
    {
        void CreateBackup(string path);
        void RestoreBackup(string path);
    }
}
