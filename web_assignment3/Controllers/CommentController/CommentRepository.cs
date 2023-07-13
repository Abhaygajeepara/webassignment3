

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.DatabaseContext;

namespace web_assignment3.Controllers.CommentRepository
{
    public class CommentRepository : ICommonInterface
    {
        public MyDatabaseContext dbContext { get; set; }

        public CommentRepository(MyDatabaseContext databaseContext) {
            dbContext = databaseContext;
        }

        

        public Task<ActionResult> AddElement(object _object)
        {
            throw new NotImplementedException();
        }

        public void DeleteElement(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Object>> getAllElements()
        {
            return await dbContext.comments.ToListAsync();
        }

        public Task<ActionResult> GetElementsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> UpdateElement(object _object)
        {
            throw new NotImplementedException();
        }
    }
}
