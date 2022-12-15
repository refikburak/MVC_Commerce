using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private CommerceContext _context;

        public ProductController(CommerceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products=await _context.Products.Include(n=>n.Category).ToListAsync();
            return View(products);
        }
    }
}
