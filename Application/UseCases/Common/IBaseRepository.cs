using System.Linq.Expressions;

namespace Application.UseCases.Common;

public interface IBaseRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}