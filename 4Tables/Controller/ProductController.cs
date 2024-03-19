using _4Tables.Base;
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Dto;
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
        public async Task<ActionResult<BasicResult>> Add([FromBody] List<ProductCreateRequestDto> productsDto)
        {
            var result = await _productService.AddRange(productsDto);
            return ResponseBase(System.Net.HttpStatusCode.Created, result, "Succes");
        }
    }
}
