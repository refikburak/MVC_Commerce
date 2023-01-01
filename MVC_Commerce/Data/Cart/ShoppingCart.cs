using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Cart
{
    public class ShoppingCart
    {
        public CommerceContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(CommerceContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context=services.GetService<CommerceContext>();

            string cartId=session.GetString("CartId")??Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId,
            };
        }

        public void AddItemToCart(Products product)
        {
            var shoppingCartItem=_context.ShoppingCartItems.FirstOrDefault(n=>n.Product.Id== product.Id&& n.ShoppingCartId==ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem=new ShoppingCartItem()
                {
                    ShoppingCartId=ShoppingCartId,
                    Product=product,
                    Amount=1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Products product)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);

                }
            }
            _context.SaveChanges();
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Product).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Product.ProductPrice * n.Amount).Sum();

        public  async Task ClearShoppingCartAsync()
        {
            var items =await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Product).ToListAsync();

            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }

}
