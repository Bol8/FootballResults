using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public void Reset()
        {
            foreach (DbEntityEntry dbEntityEntry in _context.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    switch (dbEntityEntry.State)
                    {
                        case EntityState.Added:
                            dbEntityEntry.State = EntityState.Detached;
                            break;

                        case EntityState.Modified:
                            dbEntityEntry.State = EntityState.Detached;
                            break;

                        case EntityState.Deleted:
                            dbEntityEntry.State = EntityState.Detached;
                            break;
                    }
                }
            }
        }

        public void Reset(EntityState State)
        {
            var objecStateEntries = ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.GetObjectStateEntries(State);

            foreach (var objectStateEntry in objecStateEntries)
            {
                if (objectStateEntry != null)
                {
                    ((IObjectContextAdapter)_context).ObjectContext.Detach(objectStateEntry.Entity);
                }
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
