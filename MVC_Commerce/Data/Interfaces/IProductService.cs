using MVC_Commerce.Data.Base;
using MVC_Commerce.Data.ViewModels;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Interfaces
{
    public interface IProductService:IEntityBaseRepository<Products>
    {
        Task<Products> GetProductByIdAsync(int id);
        Task<NewProductDropdownVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
