using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
     where TEntity : class, IEntity
     where TContext : DbContext
    {
        public IQueryable<TEntity> Table => Entities.AsNoTracking();

        private DbSet<TEntity> _entities;

        protected TContext Context { get; }

        public EntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (this._entities == null)
                {

                    _entities = Context.Set<TEntity>();
                }

                return this._entities;
            }
        }

        public TEntity Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            Context.SaveChanges();
            return entities;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
            Context.SaveChanges();
            return entities;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? Context.Set<TEntity>().ToList() : Context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {

            return await (filter == null ? Context.Set<TEntity>().ToListAsync() : Context.Set<TEntity>().Where(filter).ToListAsync());

        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            Context.SaveChanges();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? Context.Set<TEntity>().SingleOrDefault() : Context.Set<TEntity>().Where(filter).SingleOrDefault();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await (filter == null ? Context.Set<TEntity>().SingleOrDefaultAsync() : Context.Set<TEntity>().Where(filter).SingleOrDefaultAsync());
        }

        public TEntity Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
            Context.SaveChanges();
            return entities;
        }
    }
}
