using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.DTO;
using BLL.Interfaces;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<IHttpActionResult> GetProducts()
        {
            var products = await _productService.GetAll();

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            var product = await _productService.Get(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("api/products/{name}/suppliers")]
        public async Task<IHttpActionResult> GetListOfSuppliersByTypeName(string name)
        {
            if (name == null)
                return NotFound();

            var suppliers = await _productService.GetListOfSupplierByTypeName(name);

            if (suppliers == null)
                return NotFound();

            return Ok(suppliers);
        }

        [HttpGet]
        [Route("api/products/min_price")]
        public async Task<IHttpActionResult> GetProductByMinPrice()
        {
            var product = await _productService.GetProductByMinPrice();

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("api/products/max_price")]
        public async Task<IHttpActionResult> GetProductByMaxPrice()
        {
            var product = await _productService.GetProductByMaxPrice();

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("api/products/name/{name}")]
        public async Task<IHttpActionResult> GetProductByName( string name)
        {
            var product = await _productService.GetProductByName(name);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("api/products/price/{price}")]
        public async Task<IHttpActionResult> GetProductByMinPrice(decimal price)
        {
            var product = await _productService.GetProductsByPrice(price);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Route("api/products")]
        public IHttpActionResult PostProduct([FromBody]ProductDTO product)
        {
            if (product == null)
                return BadRequest($"{product} is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productService.Add(product);
            return Ok();
        }

        [HttpPut]
        [Route("api/products")]
        public IHttpActionResult PutProduct([FromBody] ProductDTO product)
        {
            if (product == null)
                return BadRequest($"{product} is null");

            if (_productService.Get(product.ID) == null)
                return NotFound();

            _productService.Update(product);

            return Ok();
        }

        [HttpDelete]
        [Route("api/products")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (_productService.Get(id).Result == null)
                return NotFound();

            await _productService.Remove(id);

            return Ok();
        }

        
    }
}
