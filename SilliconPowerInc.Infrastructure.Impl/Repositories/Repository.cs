using Microsoft.EntityFrameworkCore;
using SilliconPowerInc.Infrastructure.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPowerInc.Infrastructure.Impl.Repositories
{
    public class Repository<TContext, TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
                                                                                      where TContext : DbContext
    {
        protected TContext Context { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual async Task AddDataAsync(TEntity entity, CancellationToken token)
        {
            await DbSet.AddAsync(entity, token);
        }

        public virtual async Task<TEntity> GetDataAsync(TKey id, CancellationToken token)
        {
            return await DbSet.FindAsync(keyValues: new object[] { id }, cancellationToken: token);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
        {
            return await DbSet.Where(predicate).FirstOrDefaultAsync(token);
        }

        public virtual async Task UpdateDataAsync(TEntity entity, CancellationToken token)
        {
            await Task.Run(() =>
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }, token);
        }

        public virtual async Task RemoveDataAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
