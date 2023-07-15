

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;

namespace web_assignment3.Controllers.CommentRepositoryNamespace
{
    public class CommentRepository : ICommonInterface
    {
        public MyDatabaseContext dbContext { get; set; }

        public CommentRepository(MyDatabaseContext databaseContext) {
            dbContext = databaseContext;
        }

        

        

        public Task<Object> DeleteElement(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Object>> getAllElements()
        {
            return await dbContext.comments.ToListAsync();
        }
        public async Task<IEnumerable<Object>> getAllCommentByProductId()
        {
            return await dbContext.comments.ToListAsync();
        }

        public Task<Object> GetElementsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Object> UpdateElement(int id,object _object)
        {
            throw new NotImplementedException();
        }

        public  object AddElement(object _comment)
        {
            Comment comment = _comment as Comment ;

            dbContext.comments.Add(comment);
            dbContext.SaveChanges();
            return comment;
        }
    }
}
