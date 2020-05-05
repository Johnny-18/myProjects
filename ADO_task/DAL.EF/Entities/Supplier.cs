using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Entities
{
    public class Supplier
    {
        [Key]
        public int ID { get; set; }
        public string NameCompany { get; set; }
        public string City { get; set; }

        public ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products = new List<Product>();
        }
    }
}
