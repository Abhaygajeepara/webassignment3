

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;
using web_assignment3.Model.InputModel;

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
        public async Task<Object> getAllCommentByProductId(int id)
        {
            List<object> reqturnList = new List<object>();
            var commentList = await dbContext.comments.Where(c => c.ProductId == id).ToListAsync();
            for (int i = 0; i < commentList.Count; i++) {
                var cam = commentList[i] as Comment;
                var imageList = await dbContext.CommentImages.Where(c => c.CommentId == cam.Id).ToListAsync();

                if (cam != null && imageList != null)
                {
                    var commentFullData = new
                    {
                        Comments = cam,
                        Images = imageList
                    };
                    reqturnList.Add(commentFullData);

                    
                }
            }
            return reqturnList;
            return null;
        }

        public Task<Object> GetElementsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Object> UpdateElement(int id,object _object)
        {
            throw new NotImplementedException();
        }

        public  object AddElement(object _object)
        {

            CommentInput commentInput = _object as CommentInput;

            Comment comment = new Comment();
            comment.UserId = commentInput.UserId;
            comment.ProductId = commentInput.ProductId;
            comment.Rating = commentInput.Rating;
            comment.CommentText = commentInput.CommentText;

            dbContext.comments.Add(comment);
            dbContext.SaveChanges();

            List<CommentImage> commentImages = new List<CommentImage>();
            if (commentInput.ImageFiles != null && commentInput.ImageFiles.Count > 0)
            {
                

                foreach (var imageFile in commentInput.ImageFiles)
                {
                    if (imageFile.Length > 0)
                    {
                        string imagePath = SaveImageFile(imageFile);
                        CommentImage commentImage = new CommentImage
                        {
                            ImageUrl = imagePath,
                            CommentId = comment.Id  
                        };
                        commentImages.Add(commentImage);
                    }
                }

                dbContext.CommentImages.AddRange(commentImages);
                dbContext.SaveChanges();
            }

            return  new
            {
                Comments = comment,
                Images = commentImages
            }; ;

          
        }

        private string SaveImageFile(IFormFile file)
        {
           
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);


            string directoryPath = @"F:\study\Conestoga\sem2\web\assignment\error-free\UploadedImages";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName);

           
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filePath;
        }
    }
}
