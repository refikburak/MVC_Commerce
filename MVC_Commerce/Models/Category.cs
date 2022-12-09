using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
