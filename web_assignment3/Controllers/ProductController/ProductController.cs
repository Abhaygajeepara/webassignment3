using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;

namespace web_assignment3.Controllers.ProductController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;
        private ProductRepository productRepository;

        public ProductController(MyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            productRepository = new ProductRepository(dbContext);
        }

        [HttpGet]
        [Route("getProducts")]
        public async Task<ActionResult> getProductList()
        {
            var result = productRepository.getAllElements();

            return Ok(result.Result);
        }

        [HttpPost]
        [Route("addProduct")]
        public async Task<ActionResult> addProduct([FromForm]ProductInputModel productInputModel)
        {
            var productModel = productRepository.AddElement(productInputModel);

            return Ok(productModel);
        }

        [HttpGet]
        [Route("getProductByID")]
        public async Task<ActionResult> getProductByID(int id)
        {

            var result = await productRepository.GetElementsById(id);

            if (result != null)
                return Ok(result);

            return NotFound();


        }

        [HttpPut]
        [Route("updateProduct")]
        public async Task<ActionResult> updateProduct([FromForm]int id, [FromForm] ProductInputModel productInputModel)
        {

            var result = await productRepository.UpdateElement(id, productInputModel);

            if (result != null)
                return Ok(result);

            return NotFound();


        }
    }
}
