using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Commerce.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        //User
        public int UserId { get; set; }
        public User User { get; set; }

        //Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


    }
}
