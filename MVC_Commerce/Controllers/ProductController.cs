using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var products=await _service.GetAllAsync(p=>p.Category);
            return View(products);
        }

        //GET: Product/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetail= await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }
    }
}
