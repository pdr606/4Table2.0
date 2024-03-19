using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.ProductDomain.Entity;

namespace _4Tables2._0.Domain.ProductDomain.Interfaces.Services
{
    public interface IProductService
    {
        Task<BasicResult> Add(Product product);
    }
}
