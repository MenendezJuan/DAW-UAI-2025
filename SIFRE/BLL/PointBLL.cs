using BE.DTO;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PointBLL : IPointBLL
    {
        private readonly IPointDAL pointDAL;
        public PointBLL(IPointDAL pointDAL)
        {
            this.pointDAL = pointDAL;
        }

        public long ExchangePoints(int productId, long userPoints)
        {
            return pointDAL.ExchangePoints(productId, userPoints);
        }

        public long GetPointsByUserId(Guid id)
        {
            return pointDAL.GetPointsByUserId(id);
        }

        public IList<TransactionDTO> GetTransactions(bool getAll = false)
        {
            return pointDAL.GetTransactions(getAll);
        }

        public void TransferPointsToUser(decimal value, Guid id)
        {
            pointDAL.TransferPointsToUser(value, id);
        }

        List<PointTransferDTO> IPointBLL.GetPointTransfers()
        {
            return pointDAL.GetPointTransfers();
        }
    }
}
