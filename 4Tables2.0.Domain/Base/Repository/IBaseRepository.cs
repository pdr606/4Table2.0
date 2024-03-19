using _4Tables2._0.Domain.Base.Entity;

namespace _4Tables2._0.Domain.Base.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsyncNoTracking();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
