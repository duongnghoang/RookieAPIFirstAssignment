using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public interface IApplicationDbContext
{
    DbSet<Todo> Todos { get; set; }
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}