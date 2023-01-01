using MVC_Commerce.Models;

namespace MVC_Commerce.Data.ViewModels
{
    public class NewProductDropdownVM
    {
        public NewProductDropdownVM()
        {
            Categories= new List<Category>();
        }
       public List<Category> Categories { get; set; }
    }
}
