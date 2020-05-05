using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO.Entities
{
    public class ProductType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }

        public ICollection<Product> Products { get; set; }

        public ProductType()
        {
            Products = new List<Product>();
        }
    }
}
