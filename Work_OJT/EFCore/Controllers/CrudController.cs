using System.Runtime.InteropServices;
using EFCore.Application.Entities;
using EFCore.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ICrudServices _crudservice;

        public CrudController(ICrudServices crudservice)
        {
            _crudservice = crudservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _crudservice.GetAll();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(int id)
        {
            var products = await _crudservice.GetByIdAsync(id);
            if(products != null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> AddProduct(Product product)
        {
            await _crudservice.AddAsync(product);
            return CreatedAtAction(nameof(AddProduct), product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _crudservice.UpdateAsync(product);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _crudservice.DeleteAsync(id);
            return NoContent();
        }
    }
}
