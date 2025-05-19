using BE.DTO;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.BLL
{
    public interface IProductBLL
    {
        IList<Category> GetCategories();
        IList<ProductDTO> GetProducts(bool isBenefit, bool showAll = true);
        void DeleteProduct(int id);
        int AddProduct(ProductDTO productDTO);
    }
}
