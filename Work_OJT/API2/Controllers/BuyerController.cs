using API2.Application.Entities;
using API2.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;


namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        // GET: api/<BuyerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buyer>>> Get()
        {
            var buyers = await _buyerService.GetAllBuyers();
            return Ok(buyers);
        }

        // GET api/<BuyerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buyer>> Get(int id)
        {
            var buyer = await _buyerService.GetBuyerById(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return Ok(buyer);
        }

        // POST api/<BuyerController>
        [HttpPost]
        public IActionResult Post(Buyer buyer)
        {
            _buyerService.AddBuyer(buyer);
            return Ok("Add thanh cong");
        }

        // PUT api/<BuyerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Buyer buyer)
        {
            _buyerService.UpdateBuyer(buyer);
            return Ok("Update thanh cong");
        }

        // DELETE api/<BuyerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _buyerService.DeleteBuyer(id);
            return Ok("Xoa thanh cong");
        }
    }
}
