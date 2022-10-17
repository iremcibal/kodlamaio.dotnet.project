using Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Core.DataAccess.Paging;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new() 
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context =new())
            {
                EntityEntry<TEntity> entityToAdd = context.Entry(entity);
                entityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new())
            {
                EntityEntry<TEntity> entityToAdd = context.Entry(entity);
                entityToAdd.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true)
        {
            using (TContext context = new())
            {
                IQueryable<TEntity> queryable = context.Set<TEntity>();
                if (!enableTracking) queryable.AsNoTracking();
                if (include is not null) queryable = include(queryable);

                return queryable.SingleOrDefault(predicate);
            }
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                 int index = 0, int size = 10,
                                 bool enableTracking = true)
        {
            using (TContext context = new())
            {
                IQueryable<TEntity> queryable = context.Set<TEntity>();

                if (!enableTracking) queryable.AsNoTracking();
                if (include is not null) queryable = include(queryable);
                if (predicate is not null) queryable = queryable.Where(predicate);
                if (orderBy is not null) queryable = orderBy(queryable);
                return queryable.ToPaginate(index, size);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new())
            {
                EntityEntry<TEntity> entityToAdd = context.Entry(entity);
                entityToAdd.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
