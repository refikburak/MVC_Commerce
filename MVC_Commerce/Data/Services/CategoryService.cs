using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Services.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CommerceContext _context;
        public CategoryService(CommerceContext context)
        {
            _context = context;
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var result= await _context.Categories.ToListAsync();
            return  result;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(int id, Category newCategory)
        {
            throw new NotImplementedException();
        }
    }
}
