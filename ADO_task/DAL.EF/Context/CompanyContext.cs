using System.Data.Entity;
using DAL.EF.Entities;
using DAL.EF.ContextInitializer;

namespace DAL.EF.Context
{
    public class CompanyContext: DbContext
    {
        public CompanyContext() : base("DBConnection")
        {
        }

        static CompanyContext()
        {
            Database.SetInitializer(new CompanyInitializer());
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
    }
}
