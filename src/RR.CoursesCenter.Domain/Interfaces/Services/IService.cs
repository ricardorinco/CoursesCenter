using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Remove(Guid id);

        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetByIdentification(string identification);
        IEnumerable<TEntity> GetActive();
        IEnumerable<TEntity> GetInactive();
    }
}
