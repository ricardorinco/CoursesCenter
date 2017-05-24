using RR.CoursesCenter.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Interfaces
{
    public interface IAppService<TEntity> : IDisposable where TEntity : EntityViewModel
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Remove(Guid id);

        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
    }
}
