using JobFinder.Models;
using JobFinder.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JobFinder.Repositories
{
    public abstract class BaseRepository<TEntity, TIDType> : IBaseRepository<TEntity, TIDType>
    where TEntity : class, IEntity<TIDType>
    {
        private ApplicationDbContext _context;

        internal BaseRepository(ApplicationDbContext context)
        {
            DbSet = context.Set<TEntity>();
            _context = context;
        }

        public ApplicationDbContext Context { get { return _context; } }

        protected DbSet<TEntity> DbSet { get; set; }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void AddAll(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void BatchUpdate(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public virtual IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void DeleteAll(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.Where(expression);
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.Any(expression);
        }

        public virtual bool All(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.All(expression);
        }

        public virtual TEntity GetById(TIDType id)
        {
            return DbSet.Find(id);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
