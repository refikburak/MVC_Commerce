using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class UserController : Controller
    {
        private CommerceContext _context;

        public UserController(CommerceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View();
        }
    }
}
