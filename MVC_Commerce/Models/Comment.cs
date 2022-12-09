namespace MVC_Commerce.Models
{
    public class Comment
    {
       public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
