namespace WebAlbum.Models
{
    public class CommentModel
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string body { get; set; }
    }
}