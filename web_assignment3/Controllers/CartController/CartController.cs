using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;
using web_assignment3.Model.InputModel;

namespace web_assignment3.Controllers.CartController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository _cartRepository;

        public CartController(MyDatabaseContext myDatabase)
        {
            _cartRepository = new CartRepository(myDatabase);
        }

        [HttpGet]
        [Route("getCart")]
        public async Task<ActionResult> GetCart(int userId)
        {
            var cart = await _cartRepository.GetElementsById(userId);
            if (cart != null)
            {
                return Ok(cart);
                
            }
            return NotFound();
        }
        [HttpPost]
        [Route("addCart")]
        public async Task<ActionResult> addCart([FromForm] CartInputModel cartInputModel) {
            var result =  _cartRepository.AddElement(cartInputModel);
            if (result != null) {
            return Ok(result);
            }
            else { 
            return Ok();    
            }
        }
        [HttpDelete]
        [Route("deleteCart")]
        public async Task<ActionResult> deleteCartItem([FromForm] int id)
        {
            var result =await _cartRepository.DeleteElement(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }


    }
}
