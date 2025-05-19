using BE.DTO;
using BE.Entities;
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
    public class LogBLL : ILogBLL
    {
        private ILogDAL _logDAL;
        public LogBLL(ILogDAL logDAL)
        {
            _logDAL = logDAL;
        }

        public void Save(Log log)
        {
            _logDAL.Save(log);
        }

        public List<LogDTO> GetLogs(LogType? type, string module, DateTime? dateFrom, DateTime? dateTo)
        {
            return _logDAL.GetLogs(type, module, dateFrom, dateTo);
        }

        public void Save(ProductLog productLog)
        {
            _logDAL.Save(productLog);
        }

        public List<ProductLog> GetLogs(string? productId, DateTime? dateFrom, DateTime? dateTo)
        {
            return _logDAL.GetLogs(productId, dateFrom, dateTo);
        }

        public void SetProduct(int selectedProductId)
        {
            _logDAL.SetProduct(selectedProductId);
        }
    }
}
