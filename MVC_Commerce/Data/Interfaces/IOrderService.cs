using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Interfaces
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
