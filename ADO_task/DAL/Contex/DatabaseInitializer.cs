using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using DAL.ADO.Entities;
using System.Threading.Tasks;

namespace DAL.ADO
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContex>
    {
        protected override void Seed(DatabaseContex db)
        {
            ProductType productType1 = new ProductType { ID = 1, TypeName = "Food"};
            ProductType productType2 = new ProductType { ID = 2, TypeName = "Clothes"};
            ProductType productType3 = new ProductType { ID = 3, TypeName = "Electronic devices"};

            Supplier supplier1 = new Supplier { ID = 1, NameCompany = "RNB" };
            Supplier supplier2 = new Supplier { ID = 2, NameCompany = "Food" };
            Supplier supplier3 = new Supplier { ID = 3, NameCompany = "GodOFClothes" };
            Supplier supplier4 = new Supplier { ID = 4, NameCompany = "Cucci" };
            Supplier supplier5 = new Supplier { ID = 5, NameCompany = "Rapple" };

            Product product1 = new Product { ID = 1, Name = "Potato", Type_id = 1, Supplier_id = 2, Price = 10};
            Product product2 = new Product { ID = 2, Name = "Icecream", Type_id = 1, Supplier_id = 2, Price = 15 };
            Product product3 = new Product { ID = 3, Name = "T-shirt", Type_id = 2, Supplier_id = 4, Price = 200 };
            Product product4 = new Product { ID = 4, Name = "Hat", Type_id = 2, Supplier_id = 4, Price = 250 };
            Product product5 = new Product { ID = 5, Name = "TV", Type_id = 3, Supplier_id = 5, Price = 1000 };
            Product product6 = new Product { ID = 6, Name = "PC", Type_id = 3, Supplier_id = 5, Price = 1500 };
            Product product7 = new Product { ID = 7, Name = "IPhone", Type_id = 3,Supplier_id = 5, Price = 1 };
            Product product8 = new Product { ID = 8, Name = "Samsung S8", Type_id = 3, Supplier_id = 1, Price = 700 };
            Product product9 = new Product { ID = 9, Name = "Xiomi Redmi Note 8", Type_id = 3, Supplier_id = 1, Price = 500 };
            Product product10 = new Product { ID = 10, Name = "Pizza", Type_id = 1, Supplier_id = 2, Price = 35 };
            Product product11 = new Product { ID = 11, Name = "Cucumber", Type_id = 1, Supplier_id = 2, Price = 5 };

            List<Product> products = new List<Product>
            { product1, product2, product3, product4, product5,
              product6, product7, product8, product9, product10,
              product11 };

            foreach (var item in products)
            {
                if (item.Type_id == productType1.ID) productType1.Products.Add(item);
                else if(item.Type_id == productType2.ID) productType2.Products.Add(item);
                else if(item.Type_id == productType3.ID) productType3.Products.Add(item);
            }

            foreach (var item in products)
            {
                if (item.Supplier_id == supplier1.ID) supplier1.Product.Add(item);
                else if (item.Supplier_id == supplier2.ID) supplier2.Product.Add(item);
                else if (item.Supplier_id == supplier3.ID) supplier3.Product.Add(item);
                else if (item.Supplier_id == supplier4.ID) supplier4.Product.Add(item);
                else if (item.Supplier_id == supplier5.ID) supplier5.Product.Add(item);
            }

            db.Supplier.AddRange(new List<Supplier> { supplier1, supplier2, supplier3, supplier4, supplier5 });
            db.ProductType.AddRange(new List<ProductType> { productType1, productType2, productType3 });
            db.Product.AddRange(products);
            db.SaveChanges();
        }
    }
}
