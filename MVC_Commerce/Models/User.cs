using MVC_Commerce.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class User:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage ="Name is required!")]
        public string UserName { get; set; }
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is required!")]
        public string UserSurname { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "E-Mail is required!")]
        public string UserEmail { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required!")]
        public string UserPhoneNumber { get; set; }
        [Display(Name = "Balance")]
        [Required(ErrorMessage ="Balance is required")]
        public double UserBalance { get; set; }

        //Relationships
        public List<Comment>? Comments { get; set; }
        public List<Favourite>? Favourites { get; set; }

    }
}
