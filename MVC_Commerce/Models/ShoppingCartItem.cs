using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Products Product { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
