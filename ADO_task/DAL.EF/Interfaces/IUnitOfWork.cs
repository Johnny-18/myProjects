using System;
using DAL.EF.Entities;

namespace DAL.EF.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<ProductType> ProductTypeRepository { get; }
        IRepository<Supplier> SupplierRepository { get; }
    }
}
