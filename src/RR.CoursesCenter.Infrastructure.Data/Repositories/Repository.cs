using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RR.CoursesCenter.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected DataContext Context;
        protected DbSet<TEntity> DbSet;

        protected Repository(DataContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            var newObj = DbSet.Add(obj);

            return newObj;
        }

        public virtual TEntity Update(TEntity obj)
        {
            var objEntry = Context.Entry(obj);
            DbSet.Attach(obj);
            objEntry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remove(Guid id)
        {
            var student = DbSet.Find(id);
            DbSet.Remove(student);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}