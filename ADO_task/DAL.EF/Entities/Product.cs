using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ProductType")]
        public int ProductType_id { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_id { get; set; }

        public ProductType ProductType { get; set; }
        public Supplier Supplier { get; set; }
    }
}
