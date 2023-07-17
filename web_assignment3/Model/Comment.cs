    namespace web_assignment3.Model
    {
    public class Comment
    {
        public int Id { get; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }

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
