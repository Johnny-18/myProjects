using System.Collections.Generic;

namespace DAL.ADO.Interfaces
{
    public interface IGateway<T> where T : class
    {
        bool Create(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Remove(int id);
        bool Remove(T item);
        bool Update(T item);
    }
}
