using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabaty.Core.Entity;
using Talabaty.Core.Repository;

namespace Talabaty.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customerbasket>> GetCustomerBasket(string BasketId)
        {
            var basket = await _basketRepository.GetBasketAsync(BasketId);
            if (basket == null)
            {
                return new Customerbasket(BasketId);
            }
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<Customerbasket>> UpdateBasket(Customerbasket basket)
        {
            var CreatedOrUpdated = await _basketRepository.UpdateBasketAsync(basket);
            if (CreatedOrUpdated == null)
            {
                return BadRequest("Unable to update the basket.");
            }
            return Ok(CreatedOrUpdated);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string BasketId)
        {
            return await _basketRepository.DeleteBasketAsync(BasketId);
          
        }
    }
       
}
