using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL;
using DAL.EF.UnitOfWork;
using DAL.EF.Interfaces;
using AutoMapper;
using BLL.Interfaces;
using BLL.Mapper;
using DAL.EF.Entities;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOFWork;
        private IMapper mapper;

        public ProductService()
        {
            unitOFWork = new UnitOfWork(new MyConfiguration().Context);
            mapper = MappingConfiguration.ConfigurationMapper().CreateMapper();
        }

        public ProductService(UnitOfWork uof)
        {
            unitOFWork = uof;
            mapper = MappingConfiguration.ConfigurationMapper().CreateMapper();
        }

        public async Task<ProductDTO> GetProductByMaxPrice()
        {
            IEnumerable<Product> products = await unitOFWork.ProductRepository.GetAll();
            var maxPrice = products.Max(p => p.Price);
            Product maxProduct = products.Where(p => p.Price == maxPrice).First();

            return mapper.Map<ProductDTO>(maxProduct);
        }

        public async Task<IEnumerable<SupplierDTO>> GetListOfSupplierByTypeName(string productType)
        {
            List<Supplier> result = new List<Supplier>();
            IEnumerable<Product> products = await unitOFWork.ProductRepository.GetAll();
            IEnumerable<ProductType> productTypes = await unitOFWork.ProductTypeRepository.GetAll();

            foreach (var item in productTypes)
            {
                if(item.TypeName == productType)
                {
                    var toAdd = products.Where(p => p.ProductType_id == item.ID).Select(p => p.Supplier);
                    result.AddRange(toAdd);
                }
            }

            return mapper.Map<List<SupplierDTO>>(result);
        }

        public async Task<ProductDTO> GetProductByMinPrice()
        {
            IEnumerable<Product> products = await unitOFWork.ProductRepository.GetAll();
            var minPrice = products.Min(p => p.Price);
            Product minProduct = products.Where(p => p.Price == minPrice).First();

            return mapper.Map<ProductDTO>(minProduct);
        }

        public async Task<ProductDTO> GetProductByName(string productName)
        {
            IEnumerable<Product> products = await unitOFWork.ProductRepository.GetAll();
            var result = products.Where(p => p.Name == productName).First();

            return mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByPrice(decimal price)
        {
            IEnumerable<Product> products = await unitOFWork.ProductRepository.GetAll();

            var result = products.Where(p => p.Price == price);

            return mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await unitOFWork.ProductRepository.GetAll();

            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> Get(int id)
        {
            var product = await unitOFWork.ProductRepository.Get(id);

            return mapper.Map<ProductDTO>(product);
        }

        public bool Add(ProductDTO item)
        {
            if (unitOFWork.ProductRepository.Get(item.ID) != null)
                return false;

            Product product = mapper.Map<Product>(item);

            unitOFWork.ProductRepository.Create(product);

            if (unitOFWork.ProductRepository.Save())
                return true;

            return false;
        }

        public bool Update(ProductDTO item)
        {
            if (unitOFWork.ProductRepository.Get(item.ID) == null)
                return false;

            Product product = mapper.Map<Product>(item);

            unitOFWork.ProductRepository.Update(product);

            if (unitOFWork.ProductRepository.Save())
                return true;

            return false;
        }

        public async Task<bool> Remove(int id)
        {
            var product = await unitOFWork.ProductRepository.Get(id);

            if (product == null)
                return false;

            unitOFWork.ProductRepository.Remove(id);

            if (unitOFWork.ProductRepository.Save())
                return true;

            return false;
        }

        public async Task<bool> Remove(ProductDTO item)
        {
            return await Remove(item.ID);
        }
    }
}
