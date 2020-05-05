using System.Collections.Generic;
using DAL.EF.Context;
using DAL.EF.Entities;
using System.Data.Entity;

namespace DAL.EF.ContextInitializer
{
    public class CompanyInitializer : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext db)
        {
            ProductType productType1 = new ProductType { ID = 1, TypeName = "Food" };
            ProductType productType2 = new ProductType { ID = 2, TypeName = "Clothes" };
            ProductType productType3 = new ProductType { ID = 3, TypeName = "Electronic devices" };

            Supplier supplier1 = new Supplier { ID = 1, NameCompany = "RNB", City = "New York"};
            Supplier supplier2 = new Supplier { ID = 2, NameCompany = "Food", City = "Kyiv"};
            Supplier supplier3 = new Supplier { ID = 3, NameCompany = "GodOFClothes",City = "Chernihiv"};
            Supplier supplier4 = new Supplier { ID = 4, NameCompany = "Cucci", City = "Moskov"};
            Supplier supplier5 = new Supplier { ID = 5, NameCompany = "Rapple", City = "Mehico"};

            Product product1 = new Product { ID = 1, Name = "Potato", ProductType_id = 1, Supplier_id = 2, Price = 10 };
            Product product2 = new Product { ID = 2, Name = "Icecream", ProductType_id = 1, Supplier_id = 2, Price = 15 };
            Product product3 = new Product { ID = 3, Name = "T-shirt", ProductType_id = 2, Supplier_id = 4, Price = 200 };
            Product product4 = new Product { ID = 4, Name = "Hat", ProductType_id = 2, Supplier_id = 4, Price = 250 };
            Product product5 = new Product { ID = 5, Name = "TV", ProductType_id = 3, Supplier_id = 5, Price = 1000 };
            Product product6 = new Product { ID = 6, Name = "PC", ProductType_id = 3, Supplier_id = 5, Price = 1500 };
            Product product7 = new Product { ID = 7, Name = "IPhone", ProductType_id = 3, Supplier_id = 5, Price = 1 };
            Product product8 = new Product { ID = 8, Name = "Samsung S8", ProductType_id = 3, Supplier_id = 1,Price = 900 };
            Product product9 = new Product { ID = 9, Name = "Xiomi Redmi Note 8", ProductType_id = 3, Supplier_id = 1, Price = 600 };
            Product product10 = new Product { ID = 10, Name = "Pizza", ProductType_id = 1, Supplier_id = 2, Price = 25 };
            Product product11 = new Product { ID = 11, Name = "Cucumber", ProductType_id = 1, Supplier_id = 2, Price = 5 };

            List<Supplier> suppliers = new List<Supplier>
            {
                supplier1,supplier2,supplier3,supplier4,supplier5
            };

            List<ProductType> productTypes = new List<ProductType>
            {
                productType1,productType2,productType3
            };

            List<Product> products = new List<Product>
            { product1, product2, product3, product4, product5,
              product6, product7, product8, product9, product10,
              product11 };

            foreach (var item in products)
            {
                if (item.ProductType_id == productType1.ID)
                {
                    productType1.Products.Add(item);
                    item.ProductType = productType1;
                }
                else if (item.ProductType_id == productType2.ID)
                {
                    productType2.Products.Add(item);
                    item.ProductType = productType2;
                }
                else if (item.ProductType_id == productType3.ID)
                {
                    productType3.Products.Add(item);
                    item.ProductType = productType3;
                }
            }

            foreach (var item in products)
            {
                if (item.Supplier_id == supplier1.ID)
                {
                    supplier1.Products.Add(item);
                    item.Supplier = supplier1;
                }
                else if (item.Supplier_id == supplier2.ID)
                {
                    supplier2.Products.Add(item);
                    item.Supplier = supplier2;
                }
                else if (item.Supplier_id == supplier3.ID)
                {
                    supplier3.Products.Add(item);
                    item.Supplier = supplier3;
                }
                else if (item.Supplier_id == supplier4.ID)
                {
                    supplier4.Products.Add(item);
                    item.Supplier = supplier4;
                }
                else if (item.Supplier_id == supplier5.ID)
                {
                    supplier5.Products.Add(item);
                    item.Supplier = supplier5;
                }
            }

            db.Supplier.AddRange(suppliers);
            db.ProductType.AddRange(productTypes);
            db.Product.AddRange(products);
            
            db.SaveChanges();
        }
    }
}
