using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.DTO;
using BLL.Interfaces;

namespace API.Controllers
{
    public class SupplierController : ApiController
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        [Route("api/suppliers")]
        public async Task<IHttpActionResult> GetSuppliers()
        {
            var products = await _supplierService.GetAll();

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("api/suppliers/{id}")]
        public async Task<IHttpActionResult> GetProductTypeById(int id)
        {
            var result = await _supplierService.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/suppliers/{id}/products")]
        public async Task<IHttpActionResult> GetListOfProductsBySupplierId(int id)
        {
            if (id < 0)
                return BadRequest("Invalid ID!");

            var products = await _supplierService.GetListOfProductsBySupplierId(id);
            if (products == null)
                return NotFound();

            List<ProductDTO> result = new List<ProductDTO>();
            foreach (var item in products)
            {
                result.Add(item);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("api/suppliers/city/{city}/products")]
        public async Task<IHttpActionResult> GetListOfProductsBySupplierCity(string city)
        {
            if (city == null)
                return BadRequest("Invalid city!");

            var products = await _supplierService.GetListOfProductsBySupplierCity(city);

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("api/suppliers/city/{city}")]
        public async Task<IHttpActionResult> GetSuppliersByCityName(string city)
        {
            if (city == null)
                return BadRequest("Invalid city!");

            var supplier = await _supplierService.GetSuppliersByCityName(city);

            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }

        [HttpPost]
        [Route("api/suppliers")]
        public IHttpActionResult PostProduct([FromBody]SupplierDTO supplier)
        {
            if (supplier == null)
                return BadRequest($"{supplier} is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _supplierService.Add(supplier);
            return Ok();
        }

        [HttpPut]
        [Route("api/suppliers")]
        public IHttpActionResult PutProduct([FromBody] SupplierDTO supplier)
        {
            if (supplier == null)
                return BadRequest($"{supplier} is null");

            if (_supplierService.Get(supplier.ID) == null)
                return NotFound();

            _supplierService.Update(supplier);

            return Ok();
        }

        [HttpDelete]
        [Route("api/suppliers")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (_supplierService.Get(id).Result == null)
                return NotFound();

            await _supplierService.Remove(id);

            return Ok();
        }
    }
}
