using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Base;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {        public CategoryService(CommerceContext context) : base(context) { }
    }
}
