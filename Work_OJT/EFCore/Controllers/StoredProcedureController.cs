using EFCore.Application.Entities;
using EFCore.Application.Repositories;
using EFCore.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredProcedureController : ControllerBase
    {
        private readonly ISpServices _spservice;

        public StoredProcedureController(ISpServices spservice)
        {
            _spservice = spservice;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var product = await _spservice.GetAllProductAsync(id);
            if (product != null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            await _spservice.DeleteProductByIdAsync(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Product>> InsertProducts(Product product)
        {
            await _spservice.InsertProduct(product);
            return CreatedAtAction(nameof(InsertProducts), product);
        }
    }
}
