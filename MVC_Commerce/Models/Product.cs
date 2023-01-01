using MVC_Commerce.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Commerce.Models
{
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Brand")]
        public string ProductBrand { get; set; }
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Display(Name = "Decription")]
        public string ProductDescription { get; set; }
        [Display(Name = "Image")]
        public string ProductImageURL { get; set; }
        [Display(Name = "Price")]
        public double ProductPrice { get; set; }
        [Display(Name = "Quantity")]
        public long  ProductQuantity { get; set; }

        //Category
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public Category Category { get; set; }

        //Relationships
        public List<Comment>? Comments { get; set; }
        public List<Favourite>? Favourites { get; set; }


    }
}
