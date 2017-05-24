using RR.CoursesCenter.Infrastructure.Data.Context;
using RR.CoursesCenter.Infrastructure.Data.Interfaces;
using System;

namespace RR.CoursesCenter.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        private bool disposed;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
            disposed = false;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
