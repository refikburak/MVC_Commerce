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
        [Display(Name = "User Full Name")]
        public User User { get; set; }

        //Product
        public int ProductId { get; set; }
        [Display(Name = "Product Full Name")]
        public Products Product { get; set; }

        [Display(Name ="Title")]
        public string Title { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }


    }
}
