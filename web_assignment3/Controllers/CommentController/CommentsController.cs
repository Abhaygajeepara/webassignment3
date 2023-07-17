using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.Controllers.CommentRepositoryNamespace;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;
using web_assignment3.Model.InputModel;

namespace web_assignment3.Controllers.CommentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;
        private readonly CommentRepository commentRepository;
        public CommentsController(MyDatabaseContext dbContext)
        {
            _dbContext = dbContext;

            commentRepository= new CommentRepository(dbContext);

        }
        [HttpGet]
        [Route("getComments")]
        public async Task<ActionResult> getCommentList(int productId)
        {
            var result = await commentRepository.getAllCommentByProductId(productId);

            return Ok(result);
        }

        [HttpPost]
        [Route("addComment")]
        public async Task<ActionResult> addComment([FromForm] CommentInput commentInput)
        {
            var result =  commentRepository.AddElement(commentInput);

            return Ok(result);
        }

    }
}
