using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ADO.Entities;
using DAL.ADO.Gateways;

namespace BLL.ADO
{
    public class BusinessService
    {
        private ProductGateway productGateway = new ProductGateway();
        private ProductTypeGateway productTypeGateway = new ProductTypeGateway();
        private SupplierGateway supplierGateway = new SupplierGateway();

        public IEnumerable<Product> GetListOfProductByTypeName(string type)
        {
            var types = productTypeGateway.GetAll();

            foreach (var item in types)
            {
                if (item.TypeName == type)
                    return item.Products;
            }

            return null;
        }

        public IEnumerable<Supplier> GetListSupplierByType(string type)
        {
            var products = productGateway.GetAll();
            var types = productTypeGateway.GetAll();
            var suppliers = supplierGateway.GetAll();

            var result = new List<Supplier>();

            foreach (var item in types)
            {
                if (item.TypeName == type)
                {
                    foreach (var prod in item.Products)
                    {
                        if (item.ID == prod.Type_id)
                            result.Add(prod.Supplier);
                    }
                }
            }

            return result;
        }

        public IEnumerable<Product> GetListOfProductBySupplierName(string suppName)
        {
            var supp = supplierGateway.GetAll();

            foreach (var item in supp)
            {
                if (item.NameCompany == suppName)
                    return item.Product;
            }

            return null;
        }
    }
}

