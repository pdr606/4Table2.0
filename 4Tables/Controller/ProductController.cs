using _4Tables.Base;
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.ControllerProduct
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<BasicResult>> Add([FromBody] Product product)
        {
            var result = await _productService.Add(product);
            return ResponseBase(System.Net.HttpStatusCode.Created, result, "Succes");
        }
    }
}
