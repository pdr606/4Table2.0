using _4Tables2._0.Application.ProductApplication.Adapter;
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Repository;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using Npgsql.Replication.PgOutput.Messages;
using System.Net;

namespace _4Tables2._0.Application.ProductDomain.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BasicResult> ActiveDesactive(long id)
        {
            var succes = await _productRepository.ActiveDesactive(id);
            if (!succes)
                return BasicResult.Failure(new(System.Net.HttpStatusCode.NotFound, $"Produto com ID {id} não encontrado."));
            else
                return BasicResult.Success();
        }

        public async Task<BasicResult> AddRange(List<ProductCreateRequestDto> productsDto)
        {
            var products = await RemoveDuplicateProducts(productsDto);
            await _productRepository.AddRangeAsync(products);
            return BasicResult.Success();
        }

        public async Task<BasicResult<IEnumerable<ProductResponseDto>>> FindAllActives()
        {
            var products = await _productRepository.FindAllActives();
            var productsDto = ProductAdapter.ToDto(products);
            return BasicResult.Success(productsDto);
        }

        public async Task<BasicResult<IEnumerable<ProductResponseDto>>> FindAllByCategory(ProductCategory category)
        {
            if (!Enum.IsDefined(typeof(ProductCategory), category))
            {
                return BasicResult.Failure<IEnumerable<ProductResponseDto>>(new(HttpStatusCode.NotFound, "Categoria não existe no sistema."));
            }

            var products = await _productRepository.FindAllByCategory(category);
            return BasicResult.Success(ProductAdapter.ToDto(products));
            
        }

        public async Task<BasicResult<IEnumerable<ProductResponseDto>>> FindAllDesactives()
        {
            var products = await _productRepository.FindAllDesactives();
            var productsDto = ProductAdapter.ToDto(products);
            return BasicResult.Success(productsDto);
        }

        public async Task<BasicResult<ProductResponseDto>> FindByCode(int code)
        {
            var product = await _productRepository.FindByCode(code);
            if (product == null)
                return BasicResult.Failure<ProductResponseDto>(new(HttpStatusCode.BadRequest, $"Produto com id {code} não encontrado."));

            return BasicResult.Success<ProductResponseDto>(ProductAdapter.ToDto(product));
        }

        private async Task<List<Product>> RemoveDuplicateProducts(List<ProductCreateRequestDto> productsDto)
        {
            var products = new List<Product>();
            foreach(var productDto in productsDto)
            {
                var product = await _productRepository.FindByName(productDto.name.ToUpper());

                if(product == null)
                    products.Add(ProductAdapter.ToEntity(productDto));
            }
            return products;
        }
    }
}
