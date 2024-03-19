using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;

namespace _4Tables2._0.Domain.ProductDomain.Interfaces.Services
{
    public interface IProductService
    {
        Task<BasicResult> AddRange(List<ProductCreateRequestDto> productsDto);
    }
}
