using _4Tables2._0.Application.Base.Repository;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Repository;
using _4Tables2._0.Infra.Data.DbConfig;
using Microsoft.EntityFrameworkCore;

namespace _4Tables2._0.Infra.ProductDomain.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task AddRangeAsync(List<Product> products)
        {
            await _db.Set<Product>().AddRangeAsync(products);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> FindByName(string name)
        {
            return await _db.Set<Product>().AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
