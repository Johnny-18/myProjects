using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Remove(int id);
        Task<bool> Remove(T item);
    }
}
