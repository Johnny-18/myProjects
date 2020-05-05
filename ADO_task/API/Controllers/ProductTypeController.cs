using System.Threading.Tasks;
using System.Web.Http;
using BLL.DTO;
using BLL.Services;
using BLL.Interfaces;

namespace API.Controllers
{
    public class ProductTypeController : ApiController
    {
        private readonly IProductTypeService _typeService;

        public ProductTypeController(IProductTypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        [Route("api/productTypes")]
        public async Task<IHttpActionResult> GetProductTypes()
        {
            var products = await _typeService.GetAll();

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("api/productTypes/{id}")]
        public async Task<IHttpActionResult> GetProductTypeById(int id)
        {
            var result = await _typeService.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/productTypes/{id}/products")]
        public async Task<IHttpActionResult> GetProductByCategory([FromUri] int id)
        {
            var typeName = _typeService.Get(id).Result.TypeName;

            var types = await _typeService.GetListOfProductsByTypeName(typeName);

            if (types == null)
                return NotFound();

            return Ok(types);
        }

        [HttpGet]
        [Route("api/productTypes/name/{name}")]
        public async Task<IHttpActionResult> GetProductTypeByName(string name)
        {
            var productType = await _typeService.GetProductTypeByName(name);

            if (productType == null)
                return NotFound();

            return Ok(productType);
        }

        [HttpPost]
        [Route("api/productTypes")]
        public IHttpActionResult PostProduct([FromBody]ProductTypeDTO productType)
        {
            if (productType == null)
                return BadRequest($"{productType} is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _typeService.Add(productType);
            return Ok();
        }

        [HttpPut]
        [Route("api/productTypes")]
        public IHttpActionResult PutProduct([FromBody] ProductTypeDTO productType)
        {
            if (productType == null)
                return BadRequest($"{productType} is null");

            if (_typeService.Get(productType.ID) == null)
                return NotFound();

            _typeService.Update(productType);

            return Ok();
        }

        [HttpDelete]
        [Route("api/productTypes")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (_typeService.Get(id).Result == null)
                return NotFound();

            await _typeService.Remove(id);

            return Ok();
        }

    }
}
