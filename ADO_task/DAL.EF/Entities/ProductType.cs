using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Entities
{
    public class ProductType
    {
        [Key]
        public int ID { get; set; }
        public string TypeName { get; set; }

        public ICollection<Product> Products { get; set; }

        public ProductType()
        {
            Products = new List<Product>();
        }
    }
}
