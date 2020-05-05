    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DAL.ADO.Entities;

    namespace DAL.ADO
{

    public partial class DatabaseContex : DbContext
    {
        public DatabaseContex() : base("DBConnection")
        {
        }

        public DatabaseContex(string connectionString)
            : base(connectionString)
        {
        }

        static DatabaseContex()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

    }
}
