using BE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DAL
{
    public interface IPointDAL
    {
        long ExchangePoints(int productId, long userPoints);
        long GetPointsByUserId(Guid id);
        IList<TransactionDTO> GetTransactions(bool getAll = false);
        void TransferPointsToUser(decimal value, Guid id);
        List<PointTransferDTO> GetPointTransfers();
    }
}
