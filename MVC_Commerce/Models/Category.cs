using MVC_Commerce.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class Category:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage ="Name is required!")]
        [StringLength(20,ErrorMessage ="Name must be lower than 20 characters!")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Description")]
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(50, ErrorMessage = "Name must be lower than 50 characters!")]
        public string CategoryDescription { get; set; }
    }
}
