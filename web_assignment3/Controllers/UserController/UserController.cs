using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;

namespace web_assignment3.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;
        private UserRepository userRepository;

        public UserController(MyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            userRepository = new UserRepository(dbContext);
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<ActionResult> getUserList()
        {
            

            try
            {
                var result = userRepository.getAllElements();

                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                // Throw custom exception if needed
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult> addUser([FromForm] UserInputModel userInputModel)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }
            var userModel = userRepository.AddElement(userInputModel);

            return Ok(userModel);
        }

        [HttpGet]
        [Route("getUserByID")]
        public async Task<ActionResult> getUserByID(int id)
        {

            var result = await userRepository.GetElementsById(id);

            if (result != null)
                return Ok(result);

            return NotFound();


        }

        [HttpPut]
        [Route("updateUser")]
        public async Task<ActionResult> updateUser([FromForm] int id, [FromForm] UserInputModel userInputModel)
        {
            
            var result = await userRepository.UpdateElement(id, userInputModel);

            if (result != null)
                return Ok(result);

            return NotFound();


        }
    }
}
