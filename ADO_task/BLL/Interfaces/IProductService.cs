using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService : IService<ProductDTO>
    {
        Task<IEnumerable<ProductDTO>> GetProductsByPrice(decimal price);
        Task<ProductDTO> GetProductByMinPrice();
        Task<ProductDTO> GetProductByMaxPrice();
        Task<ProductDTO> GetProductByName(string productName);
        Task<IEnumerable<SupplierDTO>> GetListOfSupplierByTypeName(string productType);
    }
}
