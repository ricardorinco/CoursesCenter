using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RR.CoursesCenter.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Remove(Guid id);

        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
