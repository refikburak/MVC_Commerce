using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Category GetById(int id);
        void Add(Category category);
        Category Update(int id, Category newCategory);
        void Delete(int id);
    }
}
