using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductBrand { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public List<string> ProductImageURLs { get; set; }
        public double ProductPrice { get; set; }
        public long  ProductQuantity { get; set; }

        //Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Relationships
        public List<Comment> Comments { get; set; }
        public List<Favourite> Favourites { get; set; }


    }
}
