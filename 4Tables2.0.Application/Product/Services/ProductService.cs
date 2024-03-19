using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Repository;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Tables2._0.Application.ProductDomain.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BasicResult> Add(Domain.ProductDomain.Entity.Product product)
        {
            await _productRepository.AddAsync(product);
            return BasicResult.Success();
        }
    }
}
