using DAL;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CheckDigitBLL : ICheckDigitBLL
    {
        private ICheckDigitDAL _checkDigitDAL;
        public CheckDigitBLL(ICheckDigitDAL checkDigitDAL)
        {
            _checkDigitDAL = checkDigitDAL;
        }

        public string GetIdByTable(string tableName)
        {
            switch (tableName)
            {
                case "Products":
                    return "Id";
                case "Transactions":
                    return "Id";
                case "PointTransfers":
                    return "Id";
                default:
                    return "";
            }
        }

        public void RecalculateTable(string tableName, string keyField)
        {
            _checkDigitDAL.RecalculateTable(tableName, keyField);
        }

        public string VerifyTable(string tableName)
        {
            try
            {
                _checkDigitDAL.VerifyTable(tableName);
                // Si verifica la tabla no retorna nada.
                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message + "|" + tableName;
            }
        }
    }
}
