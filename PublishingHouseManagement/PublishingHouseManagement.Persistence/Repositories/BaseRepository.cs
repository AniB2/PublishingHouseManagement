using Microsoft.EntityFrameworkCore;
using PublishingHouseManagement.Domain.Abstractions.IRepositories;
using PublishingHouseManagement.Persistence.Context;
using System.Linq.Expressions;

namespace PublishingHouseManagement.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PublishingHouseManagementContext _context;
        private readonly DbSet<TEntity> _set;

        protected BaseRepository(PublishingHouseManagementContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) =>
            _set.FirstOrDefaultAsync(expression, cancellationToken);
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) =>
            await _set.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entityEntry = await _set.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return entityEntry.Entity;
        }
        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        public async Task<TEntity?> GetWithRelatedEntitiesAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>? includeProperty = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperty != null)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<List<TEntity>> GetPagedResultAsync(Expression<Func<TEntity, bool>>? filter = null, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return items;
        }
    }
}