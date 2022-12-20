using MVC_Commerce.Data.Base;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Interfaces
{
    public interface IProductService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
    }
}
