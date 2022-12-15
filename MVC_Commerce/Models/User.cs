using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Display(Name = "Surname")]
        public string UserSurname { get; set; }
        [Display(Name = "E-Mail")]
        public string UserEmail { get; set; }
        [Display(Name = "Phone Number")]
        public string UserPhoneNumber { get; set; }
        [Display(Name = "Balance")]
        public double UserBalance { get; set; }

        //Relationships
        public List<Comment> Comments { get; set; }
        public List<Favourite> Favourites { get; set; }

    }
}
