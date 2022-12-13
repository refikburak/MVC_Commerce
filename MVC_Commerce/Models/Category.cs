using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
    }
}
