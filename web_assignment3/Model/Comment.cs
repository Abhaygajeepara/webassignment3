namespace web_assignment3.Model
{
    public class Comment
    {
        public int Id { get; set; } 

        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public ICollection<CommentImage> Images { get; set; } // Collection of CommentImage entities
        public string CommentText { get; set; }
    }

    public class CommentImage
    {
        public int Id { get; set; } // Primary key
        public string ImageUrl { get; set; }
        public int CommentId { get; set; } 

        public Comment Comment { get; set; } 
    }
}
