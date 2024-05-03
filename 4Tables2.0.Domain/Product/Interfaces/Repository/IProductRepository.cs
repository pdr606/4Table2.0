using _4Tables2._0.Domain.Base.Repository;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task AddRangeAsync(List<Product> products);
        Task<Product> FindByName(string name);
        Task<bool> ActiveDesactive(long id);
        Task<List<Product>> FindAllDesactives();
        Task<List<Product>> FindAllActives();
        Task<IEnumerable<Product>> FindAllByCategory(ProductCategory category);
        Task<Product> FindByCode(int code);
    }
}
