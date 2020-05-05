using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO.Entities
{
    public class Supplier
    {
        public int ID { get; set; }
        public string NameCompany { get; set; }
        // 1 - many
        public ICollection<Product> Product { get; set; }

        public Supplier()
        {
            Product = new List<Product>();
        }
    }
}
