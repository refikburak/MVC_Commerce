using MVC_Commerce.Data.Base;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data.Services
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        public UserService(CommerceContext context) : base(context)
        {
        }
    }
}
