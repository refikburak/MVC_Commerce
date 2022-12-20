using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Base;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly CommerceContext _context;
        public ProductService(CommerceContext context) : base(context) {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = _context.Products
                            .Include(c => c.Category)
                            .Include(c => c.Comments)
                            .Include(f => f.Favourites)
                            .ThenInclude(u => u.User)
                            .FirstOrDefaultAsync(n=>n.Id==id);
            return await productDetails;
                }
    }
}
