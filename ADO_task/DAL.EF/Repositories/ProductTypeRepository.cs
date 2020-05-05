using System.Collections.Generic;
using DAL.EF.Interfaces;
using DAL.EF.Entities;
using DAL.EF.Context;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        private CompanyContext _context;

        public ProductTypeRepository(CompanyContext context)
        {
            _context = context;
        }

        public void Create(ProductType item)
        {
            _context.ProductType.Add(item);
        }

        public void Remove(int id)
        {
            _context.ProductType.Remove(_context.ProductType.Find(id));
        }

        public void Remove(ProductType item)
        {
            _context.ProductType.Remove(item);
        }

        public async Task<ProductType> Get(int id)
        {
            return await _context.ProductType.FindAsync(id);
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
            var res = await _context.ProductType.ToListAsync();

            return res;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(ProductType item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
