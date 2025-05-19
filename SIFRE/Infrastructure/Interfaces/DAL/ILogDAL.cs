using BE.DTO;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DAL
{
    public interface ILogDAL
    {
        void Save(Log log);
        List<LogDTO> GetLogs(LogType? type, string module, DateTime? dateFrom, DateTime? dateTo);
        void Save(ProductLog productLog);
        List<ProductLog> GetLogs(string? productId, DateTime? dateFrom, DateTime? dateTo);
        void SetProduct(int selectedProductId);
    }
}
