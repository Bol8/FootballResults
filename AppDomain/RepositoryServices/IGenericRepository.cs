using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.RepositoryServices
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();

        /// <summary>
        /// Método que resetea el contexto de las posibles excepciones que pueda tener.
        /// </summary>
        void Reset();

        /// <summary>
        /// Método que resetea el contexto de las posibles excepciones que pueda tener.
        /// Indicandole el tipo se operación que de está realizando en el contexto.
        /// </summary>
        /// <param name="State"></param>
        void Reset(EntityState State);
    }
}
