using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private CommerceContext _context;

        public CategoryController(CommerceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories=await _context.Categories.ToListAsync();
            return View();
        }
    }
}
