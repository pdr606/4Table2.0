using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Interfaces.Services
{
    public interface IProductService
    {
        Task<BasicResult> AddRange(List<ProductCreateRequestDto> productsDto);
        Task<BasicResult> ActiveDesactive(long id);
        Task<BasicResult<IEnumerable<ProductResponseDto>>> FindAllActives();
        Task<BasicResult<IEnumerable<ProductResponseDto>>> FindAllDesactives();
        Task<BasicResult<IEnumerable<ProductResponseDto>>> FindAllByCategory(ProductCategory category);
        Task<BasicResult<ProductResponseDto>> FindByCode(int code);
        
    }
}
