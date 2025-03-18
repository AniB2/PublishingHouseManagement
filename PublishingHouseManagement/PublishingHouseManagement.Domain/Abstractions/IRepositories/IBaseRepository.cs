using System.Linq.Expressions;

namespace PublishingHouseManagement.Domain.Abstractions.IRepositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetWithRelatedEntitiesAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>? includeProperty = null, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetPagedResultAsync(Expression<Func<TEntity, bool>>? filter = null,
          int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default);
    }
}