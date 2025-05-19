using BE.DTO;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.BLL
{
    public interface ILogBLL
    {
        void Save(Log log);
        void Save(ProductLog productLog);
        List<LogDTO> GetLogs(LogType? type, string module, DateTime? dateFrom, DateTime? dateTo);
        List<ProductLog> GetLogs(string? productId, DateTime? dateFrom, DateTime? dateTo);
        void SetProduct(int selectedProductId);
    }
}
