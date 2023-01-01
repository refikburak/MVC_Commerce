using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
