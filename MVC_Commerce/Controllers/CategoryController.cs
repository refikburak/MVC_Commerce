using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Services;
using MVC_Commerce.Data.Services.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var categories=await _service.GetAll();
            return View(categories);
        }

        //GET: Category/Create
        public  IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                _service.Add(category);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["YazarID"] = new SelectList(_context.Yazarlar, "YazarID", "YazarAd", kitap.YazarID);
            return View(category);
        }
    }
}
