using System.Linq.Expressions;

namespace Application.UseCases.Common;

public interface IBaseRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    void Delete(TEntity entity);
    Task BulkAddAsync(IEnumerable<TEntity> entities);

    Task<int> SaveChangesAsync();
}