namespace MVC_Commerce.Models
{
    public class Favourite
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
    }
}
