using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;
using System.Diagnostics;

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
            var products = await _service.GetAllAsync(p => p.Category);
            return View(products);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var products = await _service.GetAllAsync(p => p.Category);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult=(from p in products
                                    where p.ProductBrand.ToLower().Contains(searchString.ToLower()) 
                                    || p.ProductName.ToLower().Contains(searchString.ToLower())
                                    || p.ProductDescription.ToLower().Contains(searchString.ToLower())
                                    orderby(p.ProductBrand) descending 
                                    select p).ToList();
                return View("Index",filteredResult);
            }
            return View("Index",products);
        }

        //GET: Product/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }

        //GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: Product/Create
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (ModelState.IsValid)
            {
                await _service.AddNewProductAsync(product);
                return RedirectToAction(nameof(Index));

            }
            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
            return View(product);
        }

        //GET: Product/Edit
        public async Task<IActionResult> Edit(int id)
        {

            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                ProductName = productDetails.ProductName,
                ProductDescription = productDetails.ProductDescription,
                ProductPrice = productDetails.ProductPrice,
                ProductBrand = productDetails.ProductBrand,
                CategoryId = productDetails.CategoryId,
                ProductImageURL = productDetails.ProductImageURL,
                ProductQuantity = productDetails.ProductQuantity,
            };
            
            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: Product/Edit/1
        public async Task<IActionResult> Edit(int id,NewProductVM product)
        {

            if(id!=product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdateProductAsync(product);
                return RedirectToAction(nameof(Index));

            }
            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
            return View(product);
        }


    }
}
