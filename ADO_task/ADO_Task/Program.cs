using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using BLL.Services;
using BLL.DTO;
using DAL.ADO;
using DAL.EF.Context;
using BLL.Mapper;
using System.Data.Entity;
using System.Threading.Tasks;
using BLL;
using BLL.ADO;
using DAL.EF.UnitOfWork;

namespace Task_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.
                ConnectionStrings["DBConnection"].
                ConnectionString;

            using (CompanyContext context = new CompanyContext())
            {
                MyConfiguration con = new MyConfiguration();
                ProductService productService = new ProductService((UnitOfWork)con.UnitOfWork);
                ProductTypeService typ = new ProductTypeService((UnitOfWork)con.UnitOfWork);
                SupplierService sup = new SupplierService((UnitOfWork)con.UnitOfWork);

                Console.WriteLine(productService.GetProductByMaxPrice().Result.Price);
                Console.WriteLine(productService.GetProductByMinPrice().Result.Price);
                Console.WriteLine(productService.GetProductByName("Pizza").Result.Name);
                Console.WriteLine(productService.GetProductsByPrice(1).Result.First().Name);
                var prServ = productService.GetListOfSupplierByTypeName("Food").Result;

                var typServ1 = typ.GetListOfProductsByTypeName("Food").Result;
                var typServ2 = typ.GetProductTypeByName("Food").Result;

                var list1 = sup.GetListOfProductsBySupplierCity("Mehico").Result;
                var list2 = sup.GetSuppliersByCityName("Mehico").Result;
                var list3 = sup.GetSuppliersByCityName("New York").Result;
                Console.WriteLine();
            }

            //using (DatabaseContex contex = new DatabaseContex())
            //{
            //    BusinessService businessService = new BusinessService();
            //    var res1 = businessService.GetListOfProductBySupplierName("Cucci");
            //    var res2 = businessService.GetListOfProductByTypeName("Food");
            //    var res3 = businessService.GetListSupplierByType("Clothes");
            //    Console.WriteLine();
            //}

            Console.WriteLine("End");
            Console.Read();
        }
    }
}
