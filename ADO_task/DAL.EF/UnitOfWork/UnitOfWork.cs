using System;
using DAL.EF.Entities;
using DAL.EF.Interfaces;
using DAL.EF.Context;
using DAL.EF.Repositories;

namespace DAL.EF.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private CompanyContext _context;

        private IRepository<Product> productRepository;
        private IRepository<ProductType> productTypeRepository;
        private IRepository<Supplier> supplierRepository;

        public UnitOfWork(CompanyContext context)
        {
            _context = context;
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if(productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
                }

                return productRepository;
            }
        }

        public IRepository<ProductType> ProductTypeRepository
        {
            get
            {
                if (productTypeRepository == null)
                {
                    productTypeRepository = new ProductTypeRepository(_context);
                }

                return productTypeRepository;
            }
        }

        public IRepository<Supplier> SupplierRepository
        {
            get
            {
                if (supplierRepository == null)
                {
                    supplierRepository = new SupplierRepository(_context);
                }

                return supplierRepository;
            }
        }

        private bool dispose = false;

        protected virtual void Dispose(bool dispose)
        {
            if (!this.dispose)
            {
                if (dispose)
                {
                    _context.Dispose();
                }
            }

            dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
