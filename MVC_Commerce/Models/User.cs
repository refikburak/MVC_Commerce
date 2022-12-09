using System.ComponentModel.DataAnnotations;

namespace MVC_Commerce.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public double UserBalance { get; set; }

        //Relationships
        public List<Comment> Comments { get; set; }
        public List<Favourite> Favourites { get; set; }

    }
}
