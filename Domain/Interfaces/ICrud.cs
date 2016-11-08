using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICrud<T>
    {
        T getElement(long id);

        List<T> getElements();

        bool save(T input);

        bool update(T input);

        bool Delete(long id);
    }
}