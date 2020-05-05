using System.Collections.Generic;
using DAL.EF.Interfaces;
using DAL.EF.Entities;
using DAL.EF.Context;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly CompanyContext _context;
        private readonly DbSet<Product> dbSet;

        public ProductRepository(CompanyContext context)
        {
            _context = context;
            dbSet = context.Product;
        }

        public void Create(Product item)
        {
            _context.Product.Add(item);
        }

        public void Remove(int id)
        {
            _context.Product.Remove(_context.Product.Find(id));
        }

        public void Remove(Product item)
        {
            _context.Product.Remove(item);
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var res = await dbSet.ToListAsync();

            return res;
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
