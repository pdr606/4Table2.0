using _4Tables2._0.Application.Base.Repository;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;
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

        public async Task<bool> ActiveDesactive(long id)
        {
            var product = await _db.Set<Product>().FirstOrDefaultAsync(x => x.Id == id);
            
            if(product != null)
            {
                product.ActiveOrDesactive(!product.Available);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Product>> FindAllDesactives()
        {
            return await _db.Set<Product>().Where(x => !x.Available).AsNoTracking().ToListAsync();
        }

        public async Task<List<Product>> FindAllActives()
        {
            return await _db.Set<Product>().Where(x => x.Available).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindAllByCategory(ProductCategory category)
        {
            return await _db.Set<Product>().Where(x => x.Category == category).AsNoTracking().ToListAsync();
        }

        public async Task<Product> FindByCode(int code)
        {
            return await _db.Set<Product>().AsNoTracking().FirstOrDefaultAsync(x => x.Code == code);
        }
    }
}
