using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Base;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Data.ViewModels;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services
{
    public class ProductService : EntityBaseRepository<Products>, IProductService
    {
        private readonly CommerceContext _context;
        public ProductService(CommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Products()
            {
                ProductName = data.ProductName,
                ProductDescription = data.ProductDescription,
                ProductBrand = data.ProductBrand,
                ProductPrice = data.ProductPrice,
                ProductImageURL = data.ProductImageURL,
                ProductQuantity = data.ProductQuantity,
                CategoryId = data.CategoryId
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<NewProductDropdownVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownVM();
            response.Categories = await _context.Categories.OrderBy(c => c.CategoryName).ToListAsync();
            return response;
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                            .Include(c => c.Category).Include(c => c.Comments).Include(f => f.Favourites).ThenInclude(u => u.User).FirstOrDefaultAsync(n => n.Id == id);
            return productDetails;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == data.Id);

            if (dbProduct != null)
            {

                dbProduct.ProductName = data.ProductName;
                dbProduct.ProductDescription = data.ProductDescription;
                dbProduct.ProductBrand = data.ProductBrand;
                dbProduct.ProductPrice = data.ProductPrice;
                dbProduct.ProductImageURL = data.ProductImageURL;
                dbProduct.ProductQuantity = data.ProductQuantity;
                dbProduct.CategoryId = data.CategoryId;
                await _context.SaveChangesAsync();
            };

        }
    }
}

