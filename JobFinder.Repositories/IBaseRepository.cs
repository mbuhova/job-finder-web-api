using JobFinder.Models;
using JobFinder.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JobFinder.Repositories
{
    public interface IBaseRepository<TEntity, TIDType> where TEntity : IEntity<TIDType>
    {
        ApplicationDbContext Context { get; }

        void Add(TEntity entity);

        void AddAll(IEnumerable<TEntity> entities);

        IQueryable<TEntity> All();

        void Delete(TEntity entity);

        void DeleteAll(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void BatchUpdate(IEnumerable<TEntity> entities);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        bool Any(Expression<Func<TEntity, bool>> expression);
        bool All(Expression<Func<TEntity, bool>> expression);

        TEntity GetById(TIDType id);

        void SaveChanges();
    }
}