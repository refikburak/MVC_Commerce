using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Base;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        private readonly CommerceContext _context;
        public CategoryService(CommerceContext context) : base(context) { }
    }
}
