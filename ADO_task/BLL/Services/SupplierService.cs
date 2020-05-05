using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.EF.UnitOfWork;
using DAL.EF.Interfaces;
using AutoMapper;
using BLL.Interfaces;
using BLL;
using BLL.Mapper;
using DAL.EF.Entities;

namespace BLL.Services
{
    public class SupplierService : ISupplierService
    {
        private IUnitOfWork unitOFWork;
        private IMapper mapper;

        public SupplierService()
        {
            unitOFWork = new UnitOfWork(new MyConfiguration().Context);
            mapper = MappingConfiguration.ConfigurationMapper().CreateMapper();
        }

        public SupplierService(IUnitOfWork uof)
        {
            unitOFWork = uof;
            mapper = MappingConfiguration.ConfigurationMapper().CreateMapper();
        }

        public bool Add(SupplierDTO item)
        {
            if (unitOFWork.SupplierRepository.Get(item.ID) != null)
                return false;

            Supplier supplier = mapper.Map<Supplier>(item);

            unitOFWork.SupplierRepository.Create(supplier);
            if (unitOFWork.SupplierRepository.Save())
                return true;

            return false;
        }

        public async Task<SupplierDTO> Get(int id)
        {
            var res = await unitOFWork.SupplierRepository.Get(id);

            return mapper.Map<SupplierDTO>(res);
        }

        public async Task<IEnumerable<SupplierDTO>> GetAll()
        {
            var res = await unitOFWork.SupplierRepository.GetAll();

            return mapper.Map<IEnumerable<SupplierDTO>>(res);
        }

        public async Task<IEnumerable<ProductDTO>> GetListOfProductsBySupplierCity(string city)
        {
            IEnumerable<Supplier> suppliers = await unitOFWork.SupplierRepository.GetAll();

            var result = suppliers.Where(p => p.City == city);

            var listRes = new List<ProductDTO>();
            foreach (var item in result)
            {
                foreach (var prod in item.Products)
                {
                    var toAdd = mapper.Map<ProductDTO>(prod);
                    listRes.Add(toAdd);
                }
            }

            return listRes;
        }

        public async Task<IEnumerable<ProductDTO>> GetListOfProductsBySupplierId(int id)
        {
            IEnumerable<Supplier> suppliers = await unitOFWork.SupplierRepository.GetAll();

            var result = suppliers.Where(p => p.ID == id).Select(p => p.Products).ToList();

            var listRes = new List<ProductDTO>();
            foreach (var item in result)
            {
                foreach (var product in item)
                {
                    listRes.Add(mapper.Map<ProductDTO>(product));
                }
            }

            return listRes;
        }

        public async Task<IEnumerable<SupplierDTO>> GetSuppliersByCityName(string cityName)
        {
            IEnumerable<Supplier> suppliers = await unitOFWork.SupplierRepository.GetAll();

            var result = suppliers.Where(p => p.City == cityName).ToList();

            var listRes = new List<SupplierDTO>();
            foreach (var item in result)
            {
                listRes.Add(mapper.Map<SupplierDTO>(item));
            }

            return listRes;
        }

        public async Task<bool> Remove(int id)
        {
            var supp = await unitOFWork.SupplierRepository.Get(id);

            if(supp == null)
            {
                return false;
            }

            unitOFWork.SupplierRepository.Remove(supp);

            if(unitOFWork.SupplierRepository.Save())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Remove(SupplierDTO item)
        {
            return await Remove(item.ID);
        }

        public bool Update(SupplierDTO item)
        {
            if (unitOFWork.SupplierRepository.Get(item.ID) == null)
                return false;

            Supplier supplier = mapper.Map<Supplier>(item);
            unitOFWork.SupplierRepository.Update(supplier);

            if (unitOFWork.SupplierRepository.Save())
                return true;

            return false;
        }
    }
}
