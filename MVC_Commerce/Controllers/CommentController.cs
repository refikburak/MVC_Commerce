using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class CommentController : Controller
    {
        private CommerceContext _context;

        public CommentController(CommerceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var comments=await _context.Comments.Include(n=>n.User).Include(n=>n.Product).ToListAsync();
            return View(comments);
        }
    }
}
