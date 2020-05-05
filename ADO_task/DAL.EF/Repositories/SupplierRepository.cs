using System.Collections.Generic;
using DAL.EF.Interfaces;
using DAL.EF.Entities;
using DAL.EF.Context;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private CompanyContext _context;

        public SupplierRepository(CompanyContext context)
        {
            _context = context;
        }

        public void Create(Supplier item)
        {
            _context.Supplier.Add(item);
        }

        public async Task<Supplier> Get(int id)
        {
            return await _context.Supplier.FindAsync(id);
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _context.Supplier.ToListAsync();
        }

        public void Remove(int id)
        {
            _context.Supplier.Remove(_context.Supplier.Find(id));
        }

        public void Remove(Supplier item)
        {
            _context.Supplier.Remove(item);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(Supplier item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
