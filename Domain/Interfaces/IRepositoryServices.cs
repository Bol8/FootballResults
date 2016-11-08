using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryServices<T> : IDisposable
    {
        List<T> getElements();
        void add(T element);
        void saveChanges();
        void edit(T elemnt);
        void Delete(T element);
        
    }
}
