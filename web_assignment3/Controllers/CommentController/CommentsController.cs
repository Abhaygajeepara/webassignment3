using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.Controllers.CommentRepositoryNamespace;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;

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
        public async Task<ActionResult> getCommentList()
        {
            var result = commentRepository.getAllCommentByProductId();

            return Ok(result);
        }

        [HttpPost]
        [Route("addComment")]
        public async Task<ActionResult> addComment([FromForm] Comment _comment)
        {
            var result = commentRepository.AddElement(_comment);

            return Ok(result);
        }

    }
}
