using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data.Base;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        private readonly CommerceContext _context;
        public UserService(CommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var userDetails = _context.Users
                            .Include(c => c.Comments)
                            .Include(f => f.Favourites)
                            .ThenInclude(p=>p.Product)
                            .FirstOrDefaultAsync(n => n.Id == id);
            return await userDetails;
        }
    }

}
