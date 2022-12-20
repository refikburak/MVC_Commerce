using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Controllers
{
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _service.GetAllAsync();
            return View(users);
        }

        // GET: User/Details/1
        public async Task<IActionResult> Details(int id)
        {

            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null)
                return NotFound();


            return View(userDetails);
        }

        //GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,UserSurname,UserEmail,UserPhoneNumber,UserBalance,Comments,Favourites")] User user)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        
        //GET: User/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return NotFound();
            return View(userDetails);
        }

        // POST: User/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,UserSurname,UserEmail,UserPhoneNumber,UserBalance,Comments,Favourites")] User user)
        {
            if (ModelState.IsValid)
            {
                if (id == user.Id)
                {
                    await _service.UpdateAsync(id, user);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        //GET: User/Edit
        public async Task<IActionResult> Delete(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return NotFound();
            return View(userDetails);
        }

        // POST: User/Edit/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return NotFound();
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
