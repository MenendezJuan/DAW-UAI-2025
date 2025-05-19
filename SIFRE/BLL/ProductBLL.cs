using BE.DTO;
using BE.Entities;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductBLL : IProductBLL
    {
        private IProductDAL productDAL;
        public ProductBLL(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }

        public int AddProduct(ProductDTO productDTO)
        {
            return productDAL.AddProduct(productDTO);
        }

        public void DeleteProduct(int id)
        {
            productDAL.DeleteProduct(id);
        }

        public IList<Category> GetCategories()
        {
            return productDAL.GetCategories();
        }

        IList<ProductDTO> IProductBLL.GetProducts(bool isBenefit, bool showAll = true)
        {
            return productDAL.GetProducts(isBenefit, showAll);
        }
    }
}
