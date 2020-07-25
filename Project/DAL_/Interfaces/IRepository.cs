using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Add(T item);
        void Remove(int id);
        void Remove(T id);

        void Update(T item);
    }
}
