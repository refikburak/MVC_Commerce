using MVC_Commerce.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Commerce.Models
{
    public class NewProductVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Brand is required")]
        [Display(Name = "Product Brand")]
        public string ProductBrand { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Product Decription")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Display(Name = "Product Image URL")]
        public string ProductImageURL { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Product Quantity")]
        public long  ProductQuantity { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Select Category")]
        public int CategoryId { get; set; }

        //Relationships
        public List<int>? CommentIds { get; set; }
        public List<int>? FavouriteIds { get; set; }


    }
}
