using Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext context = new())
            {
                return context.Set<TEntity>().FirstOrDefault(predicate);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null)
        {
            using (TContext context = new())
            {
                return predicate != null 
                    ? context.Set<TEntity>().Where(predicate).ToList() 
                    : context.Set<TEntity>().ToList(); 
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
