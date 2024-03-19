using _4Tables2._0.Application.ProductApplication.Adapter;
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Repository;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;

namespace _4Tables2._0.Application.ProductDomain.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BasicResult> AddRange(List<ProductCreateRequestDto> productsDto)
        {
            var products = await RemoveDuplicateProducts(productsDto);
            await _productRepository.AddRangeAsync(products);
            return BasicResult.Success();
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
