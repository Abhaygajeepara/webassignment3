using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;

namespace web_assignment3.Controllers.CommentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;

        public CommentsController(MyDatabaseContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        [Route("getUser")]
        public async Task<ActionResult> getUserList()
        {
            var result = _dbContext.comments.ToListAsync();

            return Ok(result.Result);
        }

        [HttpPost]
        [Route("addComment")]
        public async Task<ActionResult> addProduct(string title)
        {


            Comment comment = new Comment();

            comment.Title = title;


            _dbContext.comments.Add(comment);
            _dbContext.SaveChanges();


            return Ok(comment);
        }
    }
}
