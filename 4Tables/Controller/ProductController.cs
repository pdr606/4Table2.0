using _4Tables.Base;
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;
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

        [HttpPost("ActiveDesactive/{id:long}")]
        public async Task<ActionResult<BasicResult>> ActiveDesactive([FromRoute] long id)
        {
            var result = await _productService.ActiveDesactive(id);
            return ResponseBase(System.Net.HttpStatusCode.OK, result, "Succes");
        }

        [HttpGet("Actives")]
        public async Task<ActionResult<BasicResult<IEnumerable<ProductResponseDto>>>> FindAllActives()
        {
            var result = await _productService.FindAllActives();
            return ResponseBase(System.Net.HttpStatusCode.OK, result);
        }

        [HttpGet("Desactives")]
        public async Task<ActionResult<BasicResult<IEnumerable<ProductResponseDto>>>> FindAllDesactives()
        {
            var result = await _productService.FindAllDesactives();
            return ResponseBase(System.Net.HttpStatusCode.OK, result);
        }

        [HttpGet("{category:int}")]
        public async Task<ActionResult<BasicResult<IEnumerable<ProductResponseDto>>>> FindAllByCategory(int category)
        {
            var result = await _productService.FindAllByCategory((ProductCategory)category);
            return ResponseBase(System.Net.HttpStatusCode.OK, result);
        }

        [HttpGet("Code/{code:int}")]
        public async Task<ActionResult<BasicResult<ProductResponseDto>>> FindByCode([FromRoute] int code)
        {
            var result = await _productService.FindByCode(code);
            return ResponseBase(System.Net.HttpStatusCode.OK, result);
        }
    }
}
