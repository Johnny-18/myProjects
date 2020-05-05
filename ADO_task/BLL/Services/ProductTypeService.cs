using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Mapper;
using BLL;
using DAL.EF.UnitOfWork;
using DAL.EF.Interfaces;
using AutoMapper;

using DAL.EF.Entities;

namespace BLL.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private IUnitOfWork unitOFWork;
        private IMapper mapper;

        public ProductTypeService()
        {
            unitOFWork = new UnitOfWork(new MyConfiguration().Context);
            mapper = MappingConfiguration.ConfigurationMapper().CreateMapper();
        }

        public ProductTypeService(IUnitOfWork uof)
        {
            unitOFWork = uof;
            mapper = MappingConfiguration.ConfigurationMapper().CreateMapper();
        }

        public bool Add(ProductTypeDTO item)
        {
            if (unitOFWork.ProductTypeRepository.Get(item.ID) != null)
                return false;

            ProductType productType = mapper.Map<ProductType>(item);
            unitOFWork.ProductTypeRepository.Create(productType);

            if (unitOFWork.ProductTypeRepository.Save())
                return true;

            return false;

        }

        public async Task<ProductTypeDTO> Get(int id)
        {
            var type = await unitOFWork.ProductTypeRepository.Get(id);

            return mapper.Map<ProductTypeDTO>(type);
        }

        public async Task<IEnumerable<ProductTypeDTO>> GetAll()
        {
            var types = await unitOFWork.ProductTypeRepository.GetAll();

            return mapper.Map<IEnumerable<ProductTypeDTO>>(types);
        }

        public async Task<IEnumerable<ProductDTO>> GetListOfProductsByTypeName(string typeName)
        {
            IEnumerable<ProductType> productTypes = await unitOFWork.ProductTypeRepository.GetAll();
            IEnumerable<Product> products = await unitOFWork.ProductRepository.GetAll();

            IEnumerable<Product> selectedProductTypes = productTypes.Where(p => p.TypeName == typeName)
                .Join(products,p => p.ID, t => t.ProductType_id, (p,t) => 
                new Product { Name = t.Name, Price = t.Price, Supplier_id = t.Supplier_id, ProductType_id = t.ProductType_id });

            
            return mapper.Map<IEnumerable<ProductDTO>>(selectedProductTypes);
        }

        public async Task<ProductTypeDTO> GetProductTypeByName(string typeName)
        {
            IEnumerable<ProductType> productType = await unitOFWork.ProductTypeRepository.GetAll();
            var result = productType.Where(p => p.TypeName == typeName);

            return mapper.Map<ProductTypeDTO>(productType.Where(p => p.TypeName == typeName).First());
        }

        public async Task<bool> Remove(int id)
        {
            var toRemove = await unitOFWork.ProductTypeRepository.Get(id);

            if (toRemove == null)
                return false;

            unitOFWork.ProductTypeRepository.Remove(toRemove);

            if (unitOFWork.ProductTypeRepository.Save())
                return true;

            return false;
        }

        public async Task<bool> Remove(ProductTypeDTO item)
        {
            return await Remove(item.ID);
        }

        public bool Update(ProductTypeDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
