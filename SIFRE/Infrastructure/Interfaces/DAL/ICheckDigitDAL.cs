using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DAL
{
    public interface ICheckDigitDAL
    {
        void VerifyTable(string tableName);
        void RecalculateTable(string tableName, string keyField);
        void AddCheckDigit(string tableName, string keyField, string keyValue);
        void RecalculateVerticalDigit(string tableName, string[] columns);
        bool VerifyVerticalDigit(string tableName, string[] columns);
    }
}
