using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPowerInc.Infrastructure.Contracts.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TEntity> GetDataAsync(TKey id, CancellationToken token);
        Task AddDataAsync(TEntity entity, CancellationToken token);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token);
        Task UpdateDataAsync(TEntity entity, CancellationToken token);
        Task RemoveDataAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
