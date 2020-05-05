using System;
using System.Collections.Generic;
using BLL.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductTypeService : IService<ProductTypeDTO>
    {
        Task<IEnumerable<ProductDTO>> GetListOfProductsByTypeName(string typeName);
        Task<ProductTypeDTO> GetProductTypeByName(string typeName);
    }
}
