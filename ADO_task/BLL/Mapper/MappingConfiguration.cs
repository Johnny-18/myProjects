using AutoMapper;
using BLL.DTO;
using DAL.EF.Entities;

namespace BLL.Mapper
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration ConfigurationMapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ProductDTO, Product>();
                    cfg.CreateMap<Product, ProductDTO>();
                    cfg.CreateMap<ProductTypeDTO, ProductType>();
                    cfg.CreateMap<ProductType, ProductTypeDTO>();
                    cfg.CreateMap<SupplierDTO, Supplier>();
                    cfg.CreateMap<Supplier, SupplierDTO>();
                });

            return configuration;
        }
    }

}
