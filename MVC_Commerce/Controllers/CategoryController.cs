using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Data.Services;
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
            var categories = await _service.GetAllAsync();
            return View(categories);
        }

        //GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["YazarID"] = new SelectList(_context.Yazarlar, "YazarID", "YazarAd", kitap.YazarID);
            return View(category);
        }

        // GET: Category/Details/1
        public async Task<IActionResult> Details(int id)
        {

            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null)
                return NotFound();


            return View(categoryDetails);
        }

        //GET: Category/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null)
                return NotFound();
            return View(categoryDetails);
        }

        // POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //GET: Category/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null)
                return NotFound();
            return View(categoryDetails);
        }

        // POST: Category/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null) return NotFound();
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
