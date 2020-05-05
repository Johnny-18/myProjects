using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.EF.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        void Create(T item);
        void Update(T item);
        void Remove(int id);
        void Remove(T id);
        bool Save();
    }
}
