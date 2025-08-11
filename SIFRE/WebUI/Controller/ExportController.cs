using System.Text;
using System.Collections.Generic;
using BE.DTO;
using Infrastructure.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using WebUI.Services;

namespace WebUI.Controller
{
    [ApiController]
    [Route("api/export")]
    public class ExportController : ControllerBase
    {
        private readonly IProductBLL _productBLL;
        private readonly ISerializationService _serializationService;

        public ExportController(IProductBLL productBLL, ISerializationService serializationService)
        {
            _productBLL = productBLL;
            _serializationService = serializationService;
        }

        [HttpGet("products/json")]
        public IActionResult ExportProductsJson()
        {
            var list = _productBLL.GetProducts(isBenefit: false, showAll: true);
            var concrete = new List<ProductDTO>(list);
            var content = _serializationService.SerializeToJson(concrete);
            var bytes = Encoding.UTF8.GetBytes(content);
            return File(bytes, "application/json", "productos.json");
        }

        [HttpGet("products/xml")]
        public IActionResult ExportProductsXml()
        {
            var list = _productBLL.GetProducts(isBenefit: false, showAll: true);
            var concrete = new List<ProductDTO>(list);
            var content = _serializationService.SerializeToXml(concrete);
            var bytes = Encoding.UTF8.GetBytes(content);
            return File(bytes, "application/xml", "productos.xml");
        }
    }
}


