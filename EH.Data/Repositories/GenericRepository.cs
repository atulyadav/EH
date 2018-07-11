namespace EH.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = context.Set<T>().ToList();
            return query;
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = context.Set<T>().Where(predicate).ToList();
            return query;
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
                if (disposing)
                    context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
