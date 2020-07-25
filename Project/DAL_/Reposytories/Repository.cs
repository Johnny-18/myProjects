using DAL_.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL_.Context;

namespace DAL_.Reposytories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> set { get; }
        protected BlogContext context { get; }

        public Repository(BlogContext context)
        {
            set = context.Set<T>();
            this.context = context;
        }

        public void Add(T item)
        {
            set.Add(item);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await set.FindAsync(id);
        }

        public void Remove(int id)
        {
            Remove(set.Find(id));
        }

        public void Remove(T item)
        {
            set.Remove(item);
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
