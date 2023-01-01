using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Commerce.Data.ViewModels;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly CommerceContext _commerceContext;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, CommerceContext commerceContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _commerceContext = commerceContext;
        }
        public IActionResult Login()
        { 
            return View(new LoginVM());
        }
    }
}
