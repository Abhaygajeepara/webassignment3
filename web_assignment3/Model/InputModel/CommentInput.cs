namespace web_assignment3.Model.InputModel
{
    public class CommentInput
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }
       
        public string CommentText { get; set; }


        public List<IFormFile> ImageFiles { get; set; }
    }
}
