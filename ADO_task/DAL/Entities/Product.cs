using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Type")]
        public int Type_id { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_id { get; set; }

        public ProductType Type { get; set; }
        public Supplier Supplier { get; set; }
    }
}
