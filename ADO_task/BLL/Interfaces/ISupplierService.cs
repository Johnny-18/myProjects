using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Entities;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ISupplierService : IService<SupplierDTO>
    {
        Task<IEnumerable<ProductDTO>> GetListOfProductsBySupplierId(int id);
        Task<IEnumerable<ProductDTO>> GetListOfProductsBySupplierCity(string city);
        Task<IEnumerable<SupplierDTO>> GetSuppliersByCityName(string cityName);
    }
}
