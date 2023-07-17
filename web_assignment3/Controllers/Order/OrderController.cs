using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_assignment3.DatabaseContext;
using web_assignment3.Model.InputModel;

namespace web_assignment3.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    
    {
        private readonly MyDatabaseContext _dbContext;
        private readonly OrderRepository _orderRepository;  
        public OrderController(MyDatabaseContext myDatabase) {

            _dbContext = myDatabase;
            _orderRepository = new OrderRepository(myDatabase);
        }
        [HttpPost]
        [Route("addOrder")]
        public async Task<object> addOrder([FromForm] OrderInputModel orderInput)
        {
            var result = _orderRepository.AddElement(orderInput);
            return Ok(result);
        }
        [HttpGet]
        [Route("getOrderByID")]
        public async Task<object> getOrderByID( int id)
        {
            var result = await _orderRepository.GetElementsById(id);
            return Ok(result);
        }
    }

}
